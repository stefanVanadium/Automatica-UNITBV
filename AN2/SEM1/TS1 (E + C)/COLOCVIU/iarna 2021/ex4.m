s=tf('s');
Gr=(10*s+11)/s;
Gp=6/(s*s+3*s+6);

% Gpf=series(Gr,Gp);
p=pole(Gp)
%sistem stabil

Ge1=series(Gr,Gp);
H1=tf([1],[1]);
Ge=feedback(Ge1,H1);
impulse(Ge)