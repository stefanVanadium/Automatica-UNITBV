%% Exercitiul 4 - Sistem de reglare discret cu regulator Gr(s)
% GpF(s) = 1 / (s*(s+10)*(s+20))
% Gr(s)  = k*(s+20) / (s+1),   k in [5, 10]
% Te = 0.1 s
% Intrare treapta unitara

clear; clc; close all;

%% Parametri
Te = 0.1;
k_vals = 5:1:10;   % valorile k de analizat (5, 6, 7, 8, 9, 10)

%% Durata simulare
N = 200;
t_disc = (0:N-1) * Te;

%% Culori pentru grafic
colors = lines(length(k_vals));

figure(1);
hold on;

fprintf('%-5s %-15s %-15s %-15s %-10s\n', 'k', 'Suprareglaj(%)', 'T_varf(s)', 'T_stab(s)', 'Stabil');
fprintf('%s\n', repmat('-', 1, 60));

for idx = 1:length(k_vals)
    k = k_vals(idx);

    %% Regulator: Gr(s) = k*(s+20) / (s+1)
    num_r = k * [1 20];
    den_r = [1 1];
    Gr = tf(num_r, den_r);

    %% Proces: GpF(s) = 1 / (s*(s+10)*(s+20))
    num_p = 1;
    den_p = conv([1 0], conv([1 10], [1 20]));  % s*(s+10)*(s+20)
    Gp = tf(num_p, den_p);

    %% Sistem deschis continuu: L(s) = Gr(s) * GpF(s)
    L = Gr * Gp;

    %% Discretizare cu ZOH a partii continue (proces) impreuna cu ZOH
    %  In structura discreta: regulatorul se poate discretiza separat
    %  sau cascadat cu procesul.
    %  Abordare: discretizam sistemul deschis L(s) cu ZOH.
    L_d = c2d(L, Te, 'zoh');

    %% Bucla inchisa discreta
    sys_cl = feedback(L_d, 1);
    [nd, dd] = tfdata(sys_cl, 'v');

    %% Verificare stabilitate
    poles = roots(dd);
    stabil = all(abs(poles) < 1);

    %% Raspuns la treapta
    y = dstep(nd, dd, N);

    %% Indicatori de calitate
    yst = y(end);
    if abs(yst) < 1e-6, yst = 1; end  % evitam impartire la zero

    [y_max, k_max] = max(y);
    overshoot = max(0, (y_max - yst) / yst * 100);
    t_peak    = (k_max - 1) * Te;

    in_band = find(abs(y - yst) > 0.05 * abs(yst));
    if isempty(in_band)
        ts = 0;
    else
        ts = in_band(end) * Te;
    end

    fprintf('%-5d %-15.2f %-15.4f %-15.4f %-10s\n', ...
        k, overshoot, t_peak, ts, ...
        mat2str(stabil));

    %% Grafic
    stairs(t_disc, y(1:N), 'Color', colors(idx,:), 'LineWidth', 1.5, ...
        'DisplayName', sprintf('k = %d', k));
end

%% Referinta
plot([0 t_disc(end)], [1 1], 'k--', 'LineWidth', 1.2, 'DisplayName', 'Referinta');
plot([0 t_disc(end)], [1.05 1.05], 'k:', 'LineWidth', 0.8, 'HandleVisibility', 'off');
plot([0 t_disc(end)], [0.95 0.95], 'k:', 'LineWidth', 0.8, 'DisplayName', 'Banda ±5%');

xlabel('t [s]'); ylabel('y[k]');
title({'Exercitiul 4 - Raspuns la treapta al sistemului de reglare discret', ...
       'GpF(s) = 1/(s(s+10)(s+20)),  Gr(s) = k(s+20)/(s+1),  Te = 0.1 s'});
legend('Location', 'best');
grid on;

%% Figura separata: polii buclei inchise in functie de k
figure(2);
hold on;
theta = linspace(0, 2*pi, 200);
plot(cos(theta), sin(theta), 'k--', 'LineWidth', 1.0); % cercul unitatii
plot([-1.5 1.5], [0 0], 'k-', 'LineWidth', 0.5);
plot([0 0], [-1.5 1.5], 'k-', 'LineWidth', 0.5);

for idx = 1:length(k_vals)
    k = k_vals(idx);
    num_r = k * [1 20];  den_r = [1 1];   Gr = tf(num_r, den_r);
    num_p = 1;            den_p = conv([1 0], conv([1 10],[1 20]));
    Gp = tf(num_p, den_p);
    L_d   = c2d(Gr * Gp, Te, 'zoh');
    sys_cl = feedback(L_d, 1);
    poles  = pole(sys_cl);
    plot(real(poles), imag(poles), 'x', 'Color', colors(idx,:), ...
        'MarkerSize', 10, 'LineWidth', 2, 'DisplayName', sprintf('k=%d', k));
end

xlabel('Re'); ylabel('Im');
title('Polii buclei inchise discrete pentru diferite valori ale lui k');
legend('Location', 'best');
axis equal; xlim([-1.5 1.5]); ylim([-1.5 1.5]);
grid on;
