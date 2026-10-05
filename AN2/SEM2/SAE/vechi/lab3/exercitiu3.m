%% Exercitiul 3 - Comparatie sistem continuu vs discret la treapta unitara
% Proces: Gpc(s) = 9 / (s*(s+7)), Te = 0.1 s
% Bucla inchisa cu reactie unitara negativa

clear; clc; close all;

%% Parametri
Te = 0.1;

%% Functia de transfer continua a procesului
% Gpc(s) = 9 / (s*(s+7))
num_c = 9;
den_c = [1 7 0];   % s^2 + 7s + 0 => s*(s+7)

sys_c = tf(num_c, den_c);

%% Bucla inchisa CONTINUA
sys_cl_c = feedback(sys_c, 1);

%% Discretizare cu ZOH
sys_d   = c2d(sys_c, Te, 'zoh');

%% Bucla inchisa DISCRETA
sys_cl_d = feedback(sys_d, 1);
[nd, dd] = tfdata(sys_cl_d, 'v');

%% Vectori de timp
t_final = 6;                       % durata simulare [s]
t_cont  = 0:0.001:t_final;         % timp continuu (pas mic)
N       = round(t_final / Te) + 1; % numar esantioane discrete
t_disc  = (0:N-1) * Te;

%% Raspuns la treapta continuu
y_cont = step(sys_cl_c, t_cont);

%% Raspuns la treapta discret
y_disc = dstep(nd, dd, N);

%% Indicatori de calitate - sistem continuu
info_c = stepinfo(sys_cl_c);
fprintf('--- Sistem CONTINUU ---\n');
fprintf('  Suprareglaj: %.2f %%\n', info_c.Overshoot);
fprintf('  Timp de varf: %.4f s\n', info_c.PeakTime);
fprintf('  Timp de stabilire (5%%): %.4f s\n', info_c.SettlingTime);

%% Indicatori de calitate - sistem discret (estimati din raspuns)
[y_max, k_max] = max(y_disc);
yst = y_disc(end);
overshoot_d = (y_max - yst) / yst * 100;
t_peak_d    = (k_max - 1) * Te;
% Timp de stabilire (banda +/-5%)
in_band = find(abs(y_disc - yst) > 0.05 * abs(yst));
if isempty(in_band)
    ts_d = 0;
else
    ts_d = (in_band(end)) * Te;
end

fprintf('\n--- Sistem DISCRET (Te=%.1fs) ---\n', Te);
fprintf('  Suprareglaj: %.2f %%\n', overshoot_d);
fprintf('  Timp de varf: %.4f s\n', t_peak_d);
fprintf('  Timp de stabilire (5%%): %.4f s\n', ts_d);

%% Grafic comparativ
figure(1);
plot(t_cont, y_cont, 'b-', 'LineWidth', 1.5, 'DisplayName', 'Continuu');
hold on;
stairs(t_disc, y_disc(1:N), 'r-o', 'LineWidth', 1.5, ...
    'MarkerSize', 4, 'DisplayName', sprintf('Discret (Te=%.1fs)', Te));
plot([0 t_final], [1 1], 'k--', 'LineWidth', 1.0, 'DisplayName', 'Referinta');
plot([0 t_final], [1.05 1.05], 'g:', 'LineWidth', 1.0, 'HandleVisibility','off');
plot([0 t_final], [0.95 0.95], 'g:', 'LineWidth', 1.0, 'DisplayName', 'Banda +/-5%');

xlabel('t [s]'); ylabel('y(t) / y[k]');
title('Exercitiul 3 - Comparatie sistem continuu vs discret (treapta unitara)');
legend('Location', 'best');
grid on;

%% Functii de transfer
disp('Functia de transfer discreta a buclei inchise:');
sys_cl_d
disp('Functia de transfer continua a buclei inchise:');
sys_cl_c
