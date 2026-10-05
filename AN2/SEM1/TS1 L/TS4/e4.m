s = tf('s');

%a
Y = parallel(G1, G2);
Y1 = parallel(H1, H2);
Y = feedback(Y, Y1);
Y = minreal(Y);

%b
G1 = 1/(s+10);
G2 = 1/(s+1);
G3 = (s^2+2)/(s^2 + 4*s + 4);
G4 = (s+1)/(s+6);

H1 = 2;
H2 = (s+1)/(s + 2);

X1 = feedback(G1, H1);
X1 = feedback(X1, H2);
X = series(G2, G3);
X = parallel(X, G4);
X = feedback(X1, X);
X = minreal(X);
