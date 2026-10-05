%% Exercitiul 1 - Raspuns la rampa unitara (dlsim si dstep)
% Sistem din sectiunea 10.3: Gpc(s) = 1/(s+1), Te = 0.1
% Bucla inchisa cu reactie unitara negativa

clear; clc; close all;

%% Parametri sistem
num = 1;
den = [1 1];
Te = 0.1;

%% Discretizare cu ZOH
sys_c = tf(num, den);
sys_d = c2d(sys_c, Te, 'zoh');

%% Bucla inchisa discreta
sys_cl = feedback(sys_d, 1);
[nd, dd] = tfdata(sys_cl, 'v');

%% Vector de timp
N = 60;  % numar de esantioane
t = (0:N-1)';

%% --- Metoda 1: dlsim ---
% Rampa unitara discreta: r[k] = k * Te
u_ramp = t * Te;

y_dlsim = dlsim(nd, dd, u_ramp);

figure(1);
subplot(2,1,1);
stairs(t * Te, y_dlsim, 'b', 'LineWidth', 1.5);
hold on;
plot(t * Te, u_ramp, 'r--', 'LineWidth', 1.2);
xlabel('t [s]'); ylabel('y[k]');
title('Raspuns la rampa unitara folosind dlsim');
legend('Iesire y[k]', 'Intrare r[k] (rampa)');
grid on;

%% --- Metoda 2: dstep ---
% Raspunsul la rampa = raspunsul la treapta al sistemului cascadat
% cu un integrator discret (z/(z-1)) scalat cu Te
%
% R(z) = Te * z / (z-1)^2
% Y(z) = G_cl(z) * R(z) = [G_cl(z) * Te/(z-1)] * z/(z-1)
% => ramp response = dstep( G_cl(z) * integrator_discret )

% Integratorul discret: H_int(z) = Te * z^{-1} / (1 - z^{-1})
%                                 = Te / (z - 1)
num_int = [0 Te];       % Te * z^0 = Te (in termeni de puteri descrescatoare)
den_int = [1 -1];       % z - 1

% Convolam coeficientii sistemului cascadat: G_cl(z) * H_int(z)
n_casc = conv(nd, num_int);
d_casc = conv(dd, den_int);

y_dstep = dstep(n_casc, d_casc, N);
t2 = (0:length(y_dstep)-1)' * Te;

subplot(2,1,2);
stairs(t2, y_dstep, 'b', 'LineWidth', 1.5);
hold on;
plot(t * Te, u_ramp, 'r--', 'LineWidth', 1.2);
xlabel('t [s]'); ylabel('y[k]');
title('Raspuns la rampa unitara folosind dstep (integrator cascadat)');
legend('Iesire y[k]', 'Intrare r[k] (rampa)');
grid on;

sgtitle('Exercitiul 1 - Raspuns la rampa unitara', 'FontSize', 13, 'FontWeight', 'bold');
