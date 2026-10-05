%% 1
num1 = [5 0 1];
den1 = [1 3 3 1];
G = tf(num1, den1);

num2 = conv([1 0], [1 2]);
den2 = conv(conv([1 4i], [1 -4i]), [1 3]);
H = tf(num2, den2);

pG = pole(G);
zG = zero(G);

pH = pole(H);
zH = zero(H);

GH = G / H;            % G(s) / H(s)
pGH = pole(GH);
zGH = zero(GH);

figure
subplot(3,1,1)
pzmap(G); grid on; title('Pole-Zero Map: G(s)')

subplot(3,1,2)
pzmap(H); grid on; title('Pole-Zero Map: H(s)')

subplot(3,1,3)
pzmap(GH); grid on; title('Pole-Zero Map: G(s)/H(s)')

%% 2
syms a b c s t u(t) y(t) Y U % simboluri

dy = diff(y, t);
dy2 = diff(diff(y, t));
ec = dy2 + a*dy + b*y(t) == c*u(t); %ecuatia diferentiala simbolica

ecLT = laplace(ec,t,s);
sim = [laplace(y(t),t,s) laplace(u(t),t,s) y(0) (subs(diff(y(t),t), t, 0))];
vars = [Y U 0 0]; %

ecLT = subs(ecLT, sim, vars);
ecLT = subs(ecLT, U, 1/s);
ecs = solve(ecLT, Y);
ysol = ilaplace(ecs, s, t);
vars = [a b c];
values = [2 5 2];
ysol = subs(ysol, vars, values);
disp(ysol);


syms a b c s t u(t) y(t) Y U % simboluri

dy = diff(y, t);
dy2 = diff(diff(y, t));
ec = dy2 + a*dy + b*y(t) == c*u(t); %ecuatia diferentiala simbolica

ecLT = laplace(ec,t,s);
sim = [laplace(y(t),t,s) laplace(u(t),t,s) y(0) (subs(diff(y(t),t), t, 0))];
vars = [Y U 1 2]; %

ecLT = subs(ecLT, sim, vars);
ecLT = subs(ecLT, U, 1/s);
ecs = solve(ecLT, Y);
ysol = ilaplace(ecs, s, t);
vars = [a b c];
values = [3 2 3];
ysol = subs(ysol, vars, values);
disp(ysol);

%% 3
G1 = tf(1, [1 10]);
G2 = tf(1, [1 1]);
G3 = tf([1 0 1], [1 4 4]);
G4 = tf([1 1], [1 6]);

H1 = tf(2, 1);
H2 = tf([1 1], [1 2]);
H3 = tf(1, 1);

H1 = H1/G4;
G34 = series(G3, G4);
G34H2 = feedback(G34, H2);
G234H2 = series(G2, G34H2);
G234H12 = feedback(G234H2, H1);
G1234H12 = series(G1, G234H12);
G = feedback(G1234H12, H3);

% Inspect final G
G;
% Minimalization
Gmin = minreal(G)

%% 4
G1 = tf(1, [1 10]);
G2 = tf(1, [1 1]);
G3 = tf([1 0 1], [1 4 4]);
G4 = tf([1 1], [1 6]);

H1 = tf(2, 1);
H2 = tf([1 1], [1 2]);
H3 = tf(1, 1);

aG12 = parallel(G1, G2);
aH12 = parallel(H1, -H2);
aG = feedback(aG12, aH12);

G1H1 = feedback(G1, H1);
% ?