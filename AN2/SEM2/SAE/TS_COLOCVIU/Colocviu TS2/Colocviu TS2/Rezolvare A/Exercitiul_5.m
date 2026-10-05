num = [1];
den = [1 1 0];
G = tf(num,den);

num2 = [1];
den2 = [1 2];
G2 = tf(num2, den2);

Gd = series(G,G2);
rlocus(Gd)
[k,p] = rlocfind(Gd)

%pentru K = 25.4513 avem unul dintre poli egal cu:0.5274 + 2.4492i, deci
%pentru aceasta valoare a lui K sistemul nostru este instabil in circuit
%inchis