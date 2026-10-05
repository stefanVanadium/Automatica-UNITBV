syms y(t) s
Dy = diff(y,t);
D2y = diff(y,t,2);

eq = D2y + 2*Dy + 5*y == 2*t;
Ys = laplace(eq,t,s);
Ys = subs(Ys,[laplace(y,t,s) y(0) subs(Dy,t,0)], [sym('Y') 0 0]);
Y = solve(Ys, sym('Y'));
y_sol = ilaplace(Y,s,t)
