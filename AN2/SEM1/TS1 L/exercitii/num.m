%% 1) Reducere schema bloc cu G1, G2, G3, H1, H2 (structura ca în examen)
s  = tf('s');

G1 = 1/(s+2);          % pune aici G1(s)
G2 = 1/(s+1);          % pune aici G2(s)
G3 = (s+1)/(s^2+6*s);  % pune aici G3(s)
H1 = 7;                % pune aici H1(s)  (poate fi tf sau scalar)
H2 = 5;                % pune aici H2(s)

G2_cl   = feedback(G2,H2);     % bucla locala din jurul lui G2 (feedback negativ unitar cu H2)
F       = G1*G2_cl;            % blocul înainte de H1
G_RN    = feedback(F,H1);      % buclă cu H1 (feedback negativ unitar)
G_total = G_RN*G3;             % Y(s)/R(s)

%% 2) Regulator + parte fixă definită prin E.D. 2 (răspuns la rampă + buclă închisă + stabilitate + indici)

s  = tf('s');

% ----- date parte fixă din ecuația diferențială: a2*y'' + a1*y' + a0*y = b*u -----
a2 = 1;       % coeficient la y''
a1 = 5;       % coeficient la y'
a0 = 6;       % coeficient la y
b  = 6;       % coeficient la u(t)

num_pf = b;
den_pf = [a2 a1 a0];
Gpf    = tf(num_pf,den_pf);

% a) răspunsul părții fixe la rampă unitară, cu CI y(0), y'(0)
t  = 0:0.1:10;    % intervalul de timp
u  = t;           % rampă unitară
y0 = 1;           % y(0)
dy0 = 1;          % y'(0)
sys_pf = ss(Gpf);
x0 = [y0; dy0];
y  = lsim(sys_pf,u,t,x0);
% figure; plot(t,y)

% b) funcția de transfer în circuit închis (CI nule)
Gr  = -(2.07 + 3.27/s);   % pune aici G_R(s) (cu semn, exact ca în enunț)
Gol = Gr*Gpf;
Gcl = feedback(Gol,1);    % feedback negativ unitar

% c) verificare stabilitate
p_Gcl = pole(Gcl);

% d) indicatori de calitate la treaptă unitară
info_Gcl = stepinfo(Gcl);

% e) adăugare pol suplimentar (rapid) astfel încât performanțele să nu se modifice
a_fast = 10;              % alege un pol mult mai la stânga decât polul dominant
G_new  = Gcl * a_fast/(s + a_fast);
% figure; step(Gcl,G_new,0:0.01:10)

%% 3) Sistem de ordin 3 în circuit închis -> reducerea ordinului prin pol dominant

s = tf('s');
G = 225/(s^3 + 29*s^2 + 109*s + 225);   % pune aici funcția de transfer de ordin 3

% a) polii
p = pole(G);

% b) reducerea ordinului (dominant pole approximation)
[~,i] = min(abs(p));
pdom  = p(i);          % polul dominant
pr    = p;
pr(i) = [];            % ceilalți poli

ratio = min(abs(pr))/abs(pdom);   % verificare condiție |prapid| ≥ 5|pdom|

a     = abs(real(pdom));
Gred  = dcgain(G)*a/(s + a);      % sistem redus de ordin 1 cu același câștig static

t = 0:0.01:5;
% figure; step(G,Gred,t)
infoG    = stepinfo(G);
infoGred = stepinfo(Gred);

%% 4) Sistem cu reacție negativă unitară, eroare staționară + răspuns treaptă

s = tf('s');
G  = 9/(s*(s+4));          % pune aici G(s) în circuit deschis
Gcl = feedback(G,1);

% b) răspuns la treaptă unitară
t = 0:0.01:20;
[y,t] = step(Gcl,t);
% figure; plot(t,y)

% (opțional) erori staționare la treaptă / rampă / parabolă
Kp    = dcgain(G);         % constanta poziție
e_step = 1/(1 + Kp);

Kv     = dcgain(s*G);      % constanta viteză (dacă e finită)
e_ramp = 1/Kv;

Ka       = dcgain(s^2*G);  % constanta accelerație (dacă e finită)
e_parab  = 1/Ka;
