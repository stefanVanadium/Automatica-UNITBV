% ============================================================
% FORMULE SI CONCEPTE TS2 - CHEAT SHEET
% ============================================================

% ============================================================
% LAB 2 - SPATIU DE STARE
% ============================================================

% definire sistem
A = [...]; B = [...]; C = [...]; D = 0;
sys = ss(A, B, C, D);

% functie de transfer din matrici
[num, den] = ss2tf(A, B, C, D);
tf(num, den)         % afiseaza H(s)

% exponentiala matriceala (matrice de tranzitie)
syms s t
mf = inv(s*eye(n) - A)       % (sI - A)^-1
mt = ilaplace(mf, t)         % phi(t) = L^-1{(sI-A)^-1}

% raspunsuri
step(sys)            % la treapta
impulse(sys)         % la impuls
lsim(A,B,C,D, u, t, x0)  % la intrare oarecare cu conditii initiale

% controlabilitate / observabilitate
det(ctrb(A, B))      % != 0 => controlabil
det(obsv(A, C))      % != 0 => observabil

% ============================================================
% LAB 3 - RASPUNS IN FRECVENTA LA O SINGURA FRECVENTA omega
% ============================================================

% CAND: vrei raspunsul stationat y(t) la u(t) = A*sin(omega*t)
% H(j*omega) = amplitudine + faza => calculeaza bode la un singur punct

omega = 2;
u = 10 * sin(omega * t);

[amp, f] = bode(num, den, omega);   % amp = |H|, f = faza in grade
y = 10 * amp * sin(omega*t + deg2rad(f));
plot(t, u, t, y)

% sau cu obiect tf:
[amp, f] = bode(sys, omega);
y = A_intrare * amp * sin(omega*t + deg2rad(f));

% ============================================================
% LAB 4 - CONTROLLERE SI DIAGRAME BODE/NYQUIST COMPLETE
% ============================================================

% CAND: ai planta + controller, vrei sa analizezi bucla inchisa

Gpf = tf([1], [M B K]);          % planta (ex: masa-amortizor-arc)
GPI  = tf([10 5], [1 0]);        % controller PI
GPID = tf([2 10 5], [0.01 1 0]); % controller PID

Gd = series(Gpf, GPI);   % bucla deschisa = planta * controller
G0 = feedback(Gd, 1);    % bucla inchisa

% raspuns sinusoidal la frecventa omega:
[a, f] = bode(G0, omega);
y = A * a * sin(omega*t + deg2rad(f));

bode(Gd)      % diagrama Bode completa (bucla deschisa!)
nyquist(Gd)   % diagrama Nyquist (bucla deschisa!)

% ============================================================
% LAB 5 - MIMO (mai multe intrari / iesiri)
% ============================================================

% CAND: B, C, D sunt matrice (nu scalari)

A = [0 1; -25 -4]; B = [1 1; 0 1]; C = [1 0; 0 1]; D = zeros(2,2);
sys = ss(A, B, C, D);
Gp = tf(sys)

Gf = feedback(Gp, eye(2));   % feedback unitar MIMO => eye(n) in loc de 1
step(Gf); bode(Gp); nyquist(Gp)

% ============================================================
% LAB 6 - LOCUL RADACINILOR (Root Locus)
% ============================================================

% CAND: vrei sa vezi cum se misca polii cand creste amplificarea K

num = [1 5]; den = [1 3.6 0 0];
rlocus(num, den)              % traseaza locul radacinilor
[k, p] = rlocfind(num, den)  % alegi grafic un punct => afla K si polii

% cu conv() pentru polinom cu radacini complexe:
den = conv([1 1], conv([1 3+1j], [1 3-1j]));

% cu series():
G1 = tf([1 1], [1 5]); G2 = tf(2, [1 2 0 0]);
G = series(G1, G2);
[k, p] = rlocfind(G)

% ============================================================
% TIP EXERCITIU: ROOT LOCUS + STABILITATE (ex1, ex2)
% ============================================================
%
% SCHEMA: R(s) -> sumator -> G_directa(k) -> Y(s)
%                  |<--- G_feedback(s) ---|
%
% PAS 1: identifica functia OL (open-loop) FARA k
%        daca cale directa = k*P(s) si feedback = F(s):
%        L(s) = P(s)*F(s)  (scoti k-ul din OL)
%        num = numarator din L(s), den = numitor din L(s)
%
% PAS 2: traseaza locul radacinilor
%        rlocus(num, den)
%        => graficul arata unde merg polii cand k creste de la 0 la inf
%        => polii OL (x) = start, zerouri OL (o) = final
%
% PAS 3: verifica starea sistemului pt un k concret
%        ec. caracteristica BC: den + k*num = 0
%        p = roots(ec_caracteristica_cu_k_dat)
%        daca all(real(p) < 0) => STABIL
%        daca any(real(p) > 0) => INSTABIL
%        daca any(real(p) == 0) => LA LIMITA (marginal)
%
% PAS 4 (optional): demonstreaza pt mai multe valori de k
%        for k = [k1 k2 k3 ...]
%            p = roots([coef_cu_k]);
%            ...
%
% ATENTIE la cum construiesti den:
%        s*(s+a)     => conv([1 0], [1 a])
%        (s+a)*(s+b) => conv([1 a], [1 b])
%        s*(s+a)*(s+b) => conv([1 0], conv([1 a], [1 b]))
%
% CE SA TE ASTEPTI:
%        - grafic root locus cu ramuri ce pleaca din polii OL
%        - fprintf cu valorile polilor si starea sistemului
%
% SIMULINK (partea b, daca apare):
%        - validare parametru: if a < low || a > high => error('...')
%        - in model: InitFcn callback cu acelasi if/error
%        - Transfer Fcn: num/den ca vectori de coeficienti
%        - Step + Scope pentru simulare treapta unitara

% ============================================================
% LAB 7 - LINIARIZARE DIN SIMULINK
% ============================================================

% CAND: ai un model Simulink neliniar si vrei forma ss liniara

% metoda 1 - linearize (mai noua)
op = operpoint('NumeModel');
io = getlinio('NumeModel');
sys = linearize('NumeModel', io, op);

% metoda 2 - linmod (mai veche)
[A, B, C, D] = linmod('NumeModel', x0, u0);
sys = ss(A, B, C, D)

% ============================================================
% LAB 2 - SCHEME BLOC (blkbuild + connect)
% ============================================================

% CAND: ai o schema bloc cu mai multe subsisteme

n1=0.5; d1=1;
n2=4;   d2=[1 4];
% ... definesti toate blocurile n1,d1 ... nN,dN
nblocks = N;
blkbuild;   % construieste matricile a,b,c,d

% q = matrice conexiuni: [bloc_out, bloc_in1, bloc_in2, ...]
q = [1 -2 0; 2 1 0; ...];
[A,B,C,D] = connect(a, b, c, d, q, inputs, outputs);
sys = ss(A,B,C,D);
[num, den] = ss2tf(A,B,C,D); tf(num,den)

% ============================================================
% TIP EXERCITIU: CITIRE G(s) DIN BODE + RASPUNS BUCLA INCHISA (ex3)
% ============================================================
%
% SCHEMA: citesti graficul Bode al lui G_ol si construiesti G(s)
%
% PAS 1: identifica K din magnitudinea la frecvente mici
%        daca graficul porneste de la 0 dB => K=1
%        daca porneste de la -20 dB => K = 10^(-20/20) = 0.1
%        daca porneste de la +20 dB => K = 10^(20/20) = 10
%
% PAS 2: identifica zerouri si poli din breakuri in panta
%        panta urca cu +20 dB/dec la omega=w1 => ZERO la s+w1 (numarator)
%        panta coboara cu -20 dB/dec la omega=w2 => POL la s+w2 (numitor)
%        (panta initiala -20 dB/dec => pol la origine => den: s)
%
% PAS 3: construieste G_ol si G_cl
%        G_ol = tf(K * [1 w1], [1 w2])   % sau cum e cazul
%        G_cl = feedback(G_ol, 1)
%
% PAS 4: raspuns la sinusoida
%        [amp, phi] = bode(G_cl, omega);  % amp = modul, phi = grad
%        % daca intrare = A*sin(omega*t):
%        % iesire = A*amp*sin(omega*t + deg2rad(phi))
%
% EXEMPLU (breakuri la omega=1 si omega=10, start -20dB):
%        G_ol = tf(0.1 * [1 1], [1 10])
%        G_cl = feedback(G_ol, 1)
%        [amp, phi] = bode(G_cl, 2)
%        y = 3 * amp * sin(2*t + deg2rad(phi))
%
% ============================================================
% TIP EXERCITIU: G0 DAT CA TF + S-FUNCTION + OBSERVABILITATE (ex4)
% ============================================================
%
% SCHEMA: ti s-a dat G0(s) ca functie de transfer a unui sistem
%         -> construiesti spatiul de stare -> S-function -> verifici observabilitate
%
% PAS 1: extrge A, B, C, D din G0
%        num0 = [coef numarator]; den0 = [coef numitor];
%        [A, B, C, D] = tf2ss(num0, den0)
%        % sau manual daca G0 e simplu cu grade egale (D != 0)
%
% PAS 2: verifica rapid comportamentul
%        G0 = tf(num0, den0);
%        impulse(G0)   % raspuns la impuls
%
% PAS 3: S-function (template G0sfun.m)
%        function [sys,x0,str,ts] = G0sfun(t,x,u,flag)
%        switch flag
%          case 0: sys=[n_state,0,n_out,n_in,0,0]; x0=zeros(n_state,1); str=[]; ts=[0 0];
%          case 1: sys = A*x + B*u;    % derivata starii xdot
%          case 3: sys = C*x + D*u;    % iesire y
%          otherwise: sys = [];
%        end
%        In Simulink: bloc "S-Function" cu Name=G0sfun + Impulse + Scope
%
% PAS 4: verifica observabilitatea
%        M_obs = obsv(A, C);
%        fprintf('det = %.4f\n', det(M_obs));
%        % det != 0 => OBSERVABIL (rang maxim)
%        % daca vrei explicit: rank(M_obs) == size(A,1)
%
% ATENTIE:
%        - tf2ss returneaza forma canonica (controlabila), cu polii/zerouri
%          corecti dar coeficientii A, B, C, D pot arata ciudat — e ok
%        - D = 0 daca grad(num) < grad(den),  D != 0 daca grade egale
%        - daca G0 = ceva + polinom => imparte manual si obtii D = polinom
%
% ============================================================
% REZUMAT RAPID
% ============================================================
% ss()         => definire sistem spatiu de stare
% tf()         => functie de transfer
% ss2tf()      => conversie ss -> tf
% step/impulse => raspuns la treapta/impuls
% lsim()       => raspuns la intrare arbitrara
% bode(s,w)    => raspuns la SINGURA frecventa w
% bode(s)      => diagrama Bode completa
% nyquist(s)   => diagrama Nyquist
% series()     => conectare in serie G1*G2
% feedback()   => bucla inchisa
% rlocus()     => locul radacinilor
% rlocfind()   => gaseste K si poli pe grafic
% ctrb/obsv    => controlabilitate/observabilitate
% ilaplace()   => transformata Laplace inversa simbolica
% linmod()     => liniarizare model Simulink
