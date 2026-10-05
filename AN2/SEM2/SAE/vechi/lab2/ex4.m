
num2 = [10];
den2 = [1 10 0];

num3 = [1];
den3 = [1 2];

% Sampling time
T = 1;

% Discretize G2 (ZOH)
[numz2, denz2] = c2dm(num2, den2, T, 'zoh');
Gz2 = tf(numz2, denz2, T);

% Discretize G3
G3 = tf(num3, den3);
s = tf('s');
Gz3 = c2d(s * G3, T, 'zoh');

z = tf('z', T);
Gz3 = Gz3 * (z/(z-1));

% Overall open-loop discrete system
Gz = Gz2 * Gz3;

% Plot pole-zero map
[num,den] = tfdata(Gz,'v');
zplane(num,den)
