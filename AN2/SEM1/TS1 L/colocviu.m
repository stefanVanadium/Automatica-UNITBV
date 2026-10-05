%% 1

s = tf('s');

G1 = 1 / (s + 2); 
G3 = 1 / (s + 4); 
G4 = (s + 1) / (s^2 + 6*s); 
H1 = 3; 
H2 = 5;

H1 = H1/G4;
G34 = series(G3, G4);
G34H2 = feedback(G34, H2);
G34H12 = feedback(G34H2, H1);
G = series(G1, G34H12);

%% 2

s  = tf('s');

a2 = 1;         % coeficientii pf
a1 = 4;
a0 = 6;
b  = 6;

num_pf = b;
den_pf = [a2 a1 a0];
Gpf    = tf(num_pf,den_pf);

% a)
t  = 0:0.1:10;
u  = t;
y0 = 1;         % cond initiale
dy0 = 1;
sys_pf = ss(Gpf);
x0 = [y0; dy0];
y  = lsim(sys_pf,u,t,x0);
figure; plot(t,y);

% b)
Gr  = 2.07 + 3.27/s;
Gol = Gr*Gpf;
Gcl = feedback(Gol,1);

% c)
p_Gcl = pole(Gcl);

% d)
info_Gcl = stepinfo(Gcl);

%% 3 
s = tf('s');
G = 180 / (s^3 + 24*s^2 + 89*s + 180);

% a) polii
p = pole(G);

% b)
minValue = inf;
minIndex = 0;

for i = 1:length(p)
    if abs(p(i)) < minValue
        minValue = abs(p(i));
        minIndex = i;
    end
end

pdom = p(minIndex);
pr = p;
pr(minIndex) = [];

ratio = min(abs(pr))/abs(pdom);         % pr > 5pdom

a = abs(real(pdom));
Gred = dcgain(G)*a/(s + a);

t = 0:0.01:5;
figure; step(G,Gred,t)
infoG  = stepinfo(G);

%% 5

% a)
den = [1 3 0];
r = roots(den);
sumRoots = sum(r == 0);

switch sumRoots
    case 0
        disp('finita pentru treapta');
    case 1
        disp('finita pentru rampa');
    case 2
        disp('finita pentru parabola');
    otherwise
        disp('0 pentru parabola');
end

% b)
% t  = 0:0.1:10;
% [y, t] = step(feedback, t);
% figure; plot(t, y);
