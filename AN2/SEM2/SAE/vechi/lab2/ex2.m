
K = 1;

num = [K];
den = [1 1 0];

% discretizare cu ZOH, T = 0.3
T = 0.3;
[numz, denz] = c2dm(num, den, T, 'zoh');
Gz_open = tf(numz, denz, T);

%închidere buclă
Gz_cl = feedback(Gz_open, 1);   % feedback acceptă tf direct

% extragere b, a și apel zplane
[b, a] = tfdata(Gz_cl, 'v');
zplane(b, a)