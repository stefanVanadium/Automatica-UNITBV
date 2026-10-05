
% Discretize G
num = [1];
den = [1 1];
T = 0.1;
[numz, denz] = c2dm(num, den, T, 'zoh');
Gz2 = tf(numz, denz, T);

% Discretize H
num3 = [1 0];
den3 = [1 2];
H = tf(num3, den3);
Hz = c2d(H, T, 'zoh');

% Series
Fz = Gz2 * Hz;

% Closed-loop
Gz_cl = Gz2 / (1 + Fz)

% Plot
[b,a] = tfdata(Gz_cl,'v'); 
zplane(b,a)

%%

% Discretize G
num = [1];
den = [1 1];
T = 0.1;
[numz, denz] = c2dm(num, den, T, 'zoh');
Gz2 = tf(numz, denz, T);

% Discretize H
num3 = [1 0];
den3 = [1 2];
[numz, denz] = c2dm(num3, den3, T, 'zoh');
Gz3 = tf(numz, denz, T);

% Closed-loop
Gz_cl = Gz2 / (1 + Gz2 * Hz)

% Plot
[b,a] = tfdata(Gz_cl,'v'); 
zplane(b,a)