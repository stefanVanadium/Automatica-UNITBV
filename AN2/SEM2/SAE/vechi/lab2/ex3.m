
num = [1];
den = [1 1 0];

% discretizare cu ZOH, T = 0.3
T = 0.3;
G = tf(num, den);          % continuous-time TF

% multiply G with s (i.e., differentiator) then discretize
s = tf('s');
Gz = c2d(s * G, T, 'zoh');     % discrete-time plant

% open-loop
z = tf('z', T);
Gz_open = Gz * (z/(z-1));

% închidere buclă (unity feedback)
Gz_cl = feedback(Gz_open, 1)

% extragere b, a și apel zplane
[b, a] = tfdata(Gz_cl, 'v'); 
zplane(b, a);