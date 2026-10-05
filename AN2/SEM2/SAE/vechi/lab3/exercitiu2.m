%% Exercitiul 2 - Raspuns la treapta, rampa si impuls
% Sistem: ZOH + K/(s(s+1)), Te = 0.3, K = 1
% Bucla inchisa cu reactie unitara negativa

clear; clc; close all;

%% Parametri
Te = 0.3;
K  = 1;

%% Functia de transfer continua a partii de proces
% Gpc(s) = K / (s*(s+1))
num_c = K;
den_c = [1 1 0];   % s^2 + s + 0 => s*(s+1)

sys_c = tf(num_c, den_c);

%% Discretizare cu ZOH
sys_d = c2d(sys_c, Te, 'zoh');

%% Bucla inchisa discreta
sys_cl = feedback(sys_d, 1);
[nd, dd] = tfdata(sys_cl, 'v');

%% Vector de timp
N  = 80;
t  = (0:N-1)';
tv = t * Te;

%% ---- Raspuns la TREAPTA unitara ----
y_step = dstep(nd, dd, N);

%% ---- Raspuns la RAMPA unitara ----
u_ramp    = tv;                     % r[k] = k * Te
y_ramp    = dlsim(nd, dd, u_ramp);

%% ---- Raspuns la IMPULS unitar ----
y_imp = dimpulse(nd, dd, N);

%% Grafice
figure(1);

subplot(3,1,1);
stairs(tv, y_step(1:N), 'b', 'LineWidth', 1.5);
hold on;
plot(tv, ones(N,1), 'r--', 'LineWidth', 1.0);
xlabel('t [s]'); ylabel('y[k]');
title('Raspuns la treapta unitara');
legend('y[k]', 'r[k]=1(k)');
grid on;

subplot(3,1,2);
stairs(tv, y_ramp, 'b', 'LineWidth', 1.5);
hold on;
plot(tv, u_ramp, 'r--', 'LineWidth', 1.0);
xlabel('t [s]'); ylabel('y[k]');
title('Raspuns la rampa unitara');
legend('y[k]', 'r[k] = k*Te');
grid on;

subplot(3,1,3);
stairs(tv, y_imp(1:N), 'b', 'LineWidth', 1.5);
xlabel('t [s]'); ylabel('g[k]');
title('Raspuns la impuls unitar');
grid on;

sgtitle(sprintf('Exercitiul 2 - Sistem K/(s(s+1)), Te=%.1f, K=%d', Te, K), ...
    'FontSize', 13, 'FontWeight', 'bold');

%% Afisare functie de transfer discreta
disp('Functia de transfer discreta a buclei inchise:');
sys_cl
