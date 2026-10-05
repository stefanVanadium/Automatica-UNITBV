%% Definire sistem open-loop Gd(s) = 750 / (s^3 + 36s^2 + 205s + 705)
num_open = 750;
den_open = [1 36 205 705];
Gd = tf(num_open, den_open);

% Sistem in bucla inchisa cu feedback unitar negativ
G = feedback(Gd, 1);  % G(s) = Gd / (1 + Gd)

% 1. Polii sistemului (in bucla inchisa)
poli = pole(G);
disp('Polii sistemului in bucla inchisa:');
disp(poli);

% 2. Reducerea ordinului (aproximare prin poli dominanti)
% Gasim radacinile numitorului bucla inchisa: s^3 + 36s^2 + 205s + 1455
den_closed = [1 36 205 705 + 750];  % 705 + 750 = 1455
radacini = roots(den_closed);

% Sortam dupa distanta fata de origine (polul cel mai departat e rapid, il ignoram)
[~, idx] = sort(abs(real(radacini)), 'descend');  % cel mai mare |Re| primul
pol_rapid = radacini(idx(1));
poli_dominanti = radacini(idx(2:3));

disp('Pol rapid (ignorat):'); disp(pol_rapid);
disp('Poli dominanti:'); disp(poli_dominanti);

% Construim model redus de ordin 2
a = -sum(poli_dominanti);          % coef s (real, pozitiv)
b = poli_dominanti(1)*poli_dominanti(2);  % termen constant (real)

% Pastram gain-ul DC pentru potrivire stationara
dc_gain = dcgain(G);
num_redus = dc_gain * b;
den_redus = [1 a real(b)];

G_red = tf(num_redus, den_redus);

disp('Model redus de ordin 2:');
disp(G_red);

% 3. Raspuns la treapta unitara - comparatie
t = 0:0.01:10;  % timp suficient
[y_orig, t] = step(G, t);
[y_red, t] = step(G_red, t);

figure(1);
plot(t, y_orig, 'b-', 'LineWidth', 1.5); hold on;
plot(t, y_red, 'r--', 'LineWidth', 1.5);
grid on;
xlabel('Timp (s)');
ylabel('Amplitudine');
title('Raspuns la treapta unitara: Original (ordin 3) vs Redus (ordin 2)');
legend('Model original (ordin 3)', 'Model redus (ordin 2)');
hold off;

% Calcul suprareglaj (overshoot) pentru ambele
overshoot_orig = (max(y_orig) - y_orig(end)) / y_orig(end) * 100;
overshoot_red = (max(y_red) - y_red(end)) / y_red(end) * 100;
disp(['Suprareglaj model original: ', num2str(overshoot_orig, '%.2f'), ' %']);
disp(['Suprareglaj model redus: ', num2str(overshoot_red, '%.2f'), ' %']);

% 4. Tipul de intrare cu eroare stationara finita (pentru modelul simplificat)
% Modelul redus e tip 0 (fara integrator => Kp finit, Kv=0, Ka=0)
% Folosind functiile tale sserrors (daca le ai in folderul curent)
% Daca nu, decomenteaza liniile de mai jos:

% sserrors(num_redus, den_redus);  % va afisa tip 0, eroare finita doar la treapta

% Sau manual:
Kp = dcgain(G_red);  % = lim s->0 G_red(s)
Ess_step = 1 / (1 + Kp);
disp(['Eroare stationara la treapta (model redus): ', num2str(Ess_step)]);
disp('Pentru rampa si parabola: eroare infinita (tip 0)');
disp('Deci eroare stationara finita doar pentru intrare TREAPTA.');