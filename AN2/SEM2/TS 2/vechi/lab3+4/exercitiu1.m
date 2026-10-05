%% rc - ordinul 1
R = 10e3; C = 100e-6;
T = R * C;

num1 = [1];
den1 = [T 1];

w = 2;        % frecventa semnal
U = 10;       % amplitudine semnal

[mag1, phase1] = bode(num1, den1, w);

% raspuns stationar
fprintf('=== ordinul 1 ===\n')
fprintf('|G(j2)| = %.4f\n', mag1)
fprintf('faza    = %.2f grade\n', phase1)

% iesire y_st(t)
fprintf('y_st(t) = %.4f * sin(2t + (%.4f))\n', U*mag1, deg2rad(phase1))

% reprezentare grafica
t = 0:0.1:10;
u_in  = U * sin(w*t);
y_out = U * mag1 * sin(w*t + deg2rad(phase1));

figure(1)
plot(t, u_in, 'b', t, y_out, 'r')
legend('intrare u(t)', 'iesire y_{st}(t)')
title('raspuns frecventa - ordinul 1 (RC)')
xlabel('t [s]'); grid on


%% rlc - ordinul 2
R2 = 10; L = 1; C2 = 512e-6;

wn   = 1/sqrt(L*C2);           % pulsatia naturala
zeta = (R2/L) / (2*wn);        % factor de amortizare

fprintf('\n=== ordinul 2 ===\n')
fprintf('wn = %.4f rad/s\n', wn)
fprintf('zeta = %.4f\n', zeta)

num2 = [wn^2];
den2 = [1, 2*zeta*wn, wn^2];

[mag2, phase2] = bode(num2, den2, w);

fprintf('|G(j2)| = %.4f\n', mag2)
fprintf('faza    = %.2f grade\n', phase2)
fprintf('y_st(t) = %.4f * sin(2t + (%.4f))\n', U*mag2, deg2rad(phase2))

y_out2 = U * mag2 * sin(w*t + deg2rad(phase2));

figure(2)
plot(t, u_in, 'b', t, y_out2, 'r')
legend('intrare u(t)', 'iesire y_{st}(t)')
title('raspuns frecventa - ordinul 2 (RLC)')
xlabel('t [s]'); grid on