syms y(t) s
Dy = diff(y,t);
D2y = diff(y,t,2);

eq = D2y + 3*Dy + 2*y == 3*t;
Ys = laplace(eq,t,s);
Ys = subs(Ys,[laplace(y,t,s) y(0) subs(Dy,t,0)], [sym('Y') 1 2]);
Y = solve(Ys, sym('Y'));
y_sol = ilaplace(Y,s,t)
