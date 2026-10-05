num_G=[9];
r=[0 -2];
den_G=poly(r);
G=tf(num_G,den_G)

%a
errortf(num_G,den_G)
%sistemul prezinta eroere stationara finita pentru marime rampa

%b
num_H1=[1];
den_H1=[1];
H1=tf(num_H1,den_H1);

%functia de transfer in circuit inchis;
subplot(2,1,1);
Ge=feedback(G,H1)
step(Ge)
p=pole(Ge)

num_G_mod=conv([9],[0.5]);
den_G_mod=conv([1 2 9],[1 0.5]);
subplot(2,1,2)
G_mod=tf(num_G_mod,den_G_mod);
step(G_mod);