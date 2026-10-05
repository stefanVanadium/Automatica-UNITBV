clc; clear; close all;

%% 1) first–order process: rc circuit (output on r)
R = 10e3;
C = 100e-6;
tau = R * C;

% transfer function
num1 = 1 / tau;
den1 = [1 1/tau];
sys1 = tf(num1, den1);

fprintf('=== first-order process (rc) ===\n');
fprintf('stability: pole at s = -%.4f (stable)\n', 1/tau);

% step response
figure(1);
step(sys1);
title('step response - first-order rc process');
grid on;

info1 = stepinfo(sys1);
disp('quality indicators (step):');
disp(info1);

% ramp response
figure(2);
t = 0:0.01:10;
u = t;
lsim(sys1, u, t);
title('ramp response - first-order rc process');
grid on;

%ramp response (with step)
t = 0:0.01:10;
s = tf('s');


% impulse response
figure(3);
impulse(sys1);
title('impulse response - first-order rc process');
grid on;
