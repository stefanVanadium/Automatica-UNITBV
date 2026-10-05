Cod complet:

A = [-1 -0.5; 1 0];
B = [0.5; 0];
C = [1 0];
D = 0;

t = 0:0.05:10;

sys = ss(A,B,C,D);

G = tf(sys)

[num,den] = ss2tf(A,B,C,D);
G2 = tf(num,den)

syms s

I = eye(size(A));

Gs = C * inv(s*I - A) * B + D

Phi = expm(A*t(2))

Phi_s = inv(s*I - A);
Phi_t = ilaplace(Phi_s)

Co = ctrb(A,B);

if rank(Co) == size(A,1)
disp('sistem controlabil')
else
disp('sistem necontrolabil')
end

figure
tiledlayout(2,1)

ax1 = nexttile;
step(sys,t)
grid on
title('Step Response')
xlabel('t (s)')
ylabel('amplitude')

ax2 = nexttile;
impulse(sys,t)
grid on
title('Impulse Response')
xlabel('t (s)')
ylabel('amplitude')