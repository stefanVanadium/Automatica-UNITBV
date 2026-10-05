% din graficul bode se citeste:
%   - magnitudine joasa frecventa: -20 dB => K = 0.1
%   - magnitudine inalta frecventa: 0 dB  => K*T1/T2 = 1 => T1/T2 = 10
%   - break-uri la omega=1 si omega=10 => T1=1s, T2=0.1s
%
% => G(s) = (s+1)/(s+10),  constante de timp: T1=1s, T2=0.1s

% a. functia de transfer
num_ol = [1 1];   % s + 1
den_ol = [1 10];  % s + 10
G_ol = tf(num_ol, den_ol)

% b. raspuns la r(t) = 3*sin(2t) in circuit inchis
G_cl = feedback(G_ol, 1);   % bucla inchisa cu feedback negativ unitar

omega = 2;
t = 0:0.01:20;
u = 3 * sin(omega * t);

[amp, phi] = bode(G_cl, omega);
y = 3 * amp * sin(omega*t + deg2rad(phi));

plot(t, u, t, y)
legend('r(t) = 3sin(2t)', 'y(t)')
title('raspuns circuit inchis')
xlabel('t (s)')
