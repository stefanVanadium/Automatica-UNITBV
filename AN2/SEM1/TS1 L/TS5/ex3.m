clc; clear; close all;

% mass–spring–damper system
M = 1;      
B = 2;      
K = 4;      

wn = sqrt(K/M);
zeta = B / (2*sqrt(M*K));

fprintf('=== mass–spring–damper system ===\n');
fprintf('wn = %.2f rad/s\n', wn);
fprintf('zeta = %.3f (underdamped)\n\n', zeta);

% transfer function y(s)/f(s)
num = 1/M;
den = [1 B/M K/M];
sys = tf(num, den);

% convert to state–space for initial conditions
sys_ss = ss(sys);

t = 0:0.01:10;

%% case 1 — zero initial conditions
figure(1);
step(sys, t);
title('step response — zero initial conditions');
xlabel('time [s]'); ylabel('displacement y(t) [m]');
grid on;

info1 = stepinfo(sys);
disp('quality indicators (zero initial conditions):');
disp(info1);

%% case 2 — y(0)=15 m, y''(0)=0
[y_forced, ~] = step(sys, t);
[y_free,   ~] = initial(sys_ss, [15; 0], t);

y_total = y_forced + y_free;

figure(2);
plot(t, y_total, 'b', 'linewidth', 1.4); hold on;
plot(t, y_forced, '--r');
plot(t, y_free, '--g');
title('step response — y(0)=15 m');
xlabel('time [s]'); ylabel('displacement y(t) [m]');
legend('total','forced','free');
grid on;

info2 = stepinfo(t, y_total);
disp('quality indicators (nonzero initial conditions, approx):');
disp(info2);

%% phase plot
figure(3);
initial(sys_ss, [15; 0]);
title('phase plot — y(0)=15 m, v(0)=0');
grid on;

fprintf('\nsteady-state value: y_ss = 1/k = 0.25 m\n');
fprintf('initial displacement creates oscillations around 0.25 m\n');
