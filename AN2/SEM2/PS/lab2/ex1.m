
k = 1; %amplificarea sistemului
wn = 10; %pulsatia naturala
z = 0.7 %factorul de amortizare
num = [k*wn*wn];
den = [1 2*z*wn wn*wn];
z1 = -2;
%add z1 pole
den = [den, 1]; % Add the new pole z1 to the denominator
[num, den] = zp2tf(z1, p, k); % Update transfer function with new pole
%functia de transfer a filtrului num/den
Gw = bode(num,den,w);
%caracteristica modul-pulsatie = caracteristica Bode de amplitudine
plot(w,Gw)

%% ai

% Parameters
k = 1;        % gain
wn = 10;      % natural frequency (rad/s)
zeta = 0.7;   % damping factor
w = logspace(-1,2,500); % frequency vector (rad/s) for nicer Bode plots

% Original 2nd-order TF: H1(s) = k*wn^2 / (s^2 + 2*zeta*wn*s + wn^2)
num1 = k*wn^2;
den1 = [1 2*zeta*wn wn^2];
sys1 = tf(num1, den1);

% Add a zero z1 (at s = z1). For zero at s = z1, multiply numerator by (s - z1)
z1 = -2;                      % zero to add
num2 = conv(num1, [1 -z1]);   % new numerator (s - z1)
den2 = den1;                  % denominator unchanged
sys2 = tf(num2, den2);

% Compute magnitude (linear) using bode and convert to dB
[mag1,~,ww] = bode(sys1, w);
mag1 = squeeze(mag1);
[mag2,~,~] = bode(sys2, w);
mag2 = squeeze(mag2);

% Plot in dB on semilog x-axis
figure
semilogx(ww, 20*log10(mag1), 'b-', ww, 20*log10(mag2), 'r--', 'LineWidth', 1.2)
grid on
xlabel('Frequency (rad/s)')
ylabel('Magnitude (dB)')
legend('Before adding z1', 'After adding z1', 'Location', 'Best')
title('Bode Magnitude: before and after adding zero z1')


