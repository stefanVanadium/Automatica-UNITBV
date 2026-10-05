%%
num_G1=[1];
den_G1=[1 10];
G1=tf(num_G1,den_G1);

num_G2=[1];
den_G2=[1 1];
G2=tf(num_G2,den_G2);

num_H1=[2];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[1 1];
den_H2=[1 2];
H2=tf(-num_H2,den_H2);

G12=parallel(G1,G2);
H12=parallel(H1,H2);
G0=feedback(G12,H12);

[p z]=pzmap(G0)

%%
num_G1=[1];
den_G1=[1 10];
G1=tf(num_G1,den_G1);

num_G2=[1];
den_G2=[1 1];
G2=tf(num_G2,den_G2);

num_H1=[2];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[1 1];
den_H2=[1 2];
H2=tf(-num_H2,den_H2);

num_G3=[1 0 1];
den_G3=[1 4 4];
G3=tf(num_G3,den_G3);

num_G4=[1 1];
den_G4=[1 6];
G4=tf(num_G4,den_G4);

% B1=feedback(G1,H1);
% B2=series(B1,G2);
% B3=feedback(B2,H2);
% G34=parallel(G2/G4,G3);
% G0=series(B3,G34)

[p z]=pzmap(G0);
 G01=minreal(G0)

%%
