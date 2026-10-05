% second–order process: rlc series circuit
R = 10;        % 10 ohm
L = 1;         % 1 h
C = 5e-6;      % 5 microfarad

wn = 1 / sqrt(L * C);          % natural frequency
zeta = R / (2 * sqrt(L / C));  % damping factor

% transfer function (output voltage on the capacitor)
num2 = [1/(L*C)];
den2 = [1 R/L 1/(L*C)];
sys2 = tf(num2, den2);

fprintf('\n=== second-order process (rlc) ===\n');
fprintf('wn = %.2f rad/s, zeta = %.4f\n', wn, zeta);
if zeta < 1
    fprintf('stability: underdamped system (stable, oscillatory)\n');
elseif zeta == 1
    fprintf('stability: critically damped system (stable)\n');
else
    fprintf('stability: overdamped system (stable)\n');
end

% step response
figure(4);
step(sys2);
title('step response - second-order rlc process');
grid on;

% quality indicators
info2 = stepinfo(sys2);
disp('quality indicators (step) - second order:');
disp(info2);

% ramp response
t = 0:0.001:5;
u_ramp = t;
figure(5);
lsim(sys2, u_ramp, t);
title('ramp response - second-order rlc process');
grid on;

% impulse response
figure(6);
impulse(sys2);
title('impulse response - second-order rlc process');
grid on;