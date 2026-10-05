
A = [0 1 0;
     0 0 1;
    -6 -11 -6];
B = [1; 1; 1];
C = [1 1 0];
D = 0;

x0 = [1; 0.5; -0.5];
t = 0:0.05:4;

sys = ss(A,B,C,D);

u1 = ones(size(t));
[y1, ~, x1] = lsim(sys, u1, t, x0);

u2 = sin(2*pi*t);
[y2, ~, x2] = lsim(sys, u2, t, x0);

figure
plot(t, y1)
hold on
plot(t, y2)
grid on
legend('treapta', 'sin(2\pi t)')
title('comparatie raspunsuri')