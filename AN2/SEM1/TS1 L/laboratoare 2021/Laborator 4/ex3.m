num_G1=[1];
den_G1=[1 10];
G1=tf(num_G1,den_G1);

num_G2=[1];
den_G2=[1 1];
G2=tf(num_G2,den_G2);

num_G3=[1 0 1];
den_G3=[1 4 4];
G3=tf(num_G3,den_G3);

num_G4=[1 1];
den_G4=[1 6];
G4=tf(num_G4,den_G4);

num_H1=[2];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[1 1];
den_H2=[1 2];
H2=tf(num_H2,den_H2);

num_H3=[1];
den_H3=[1];
H3=tf(num_H3,den_H3);

 
B1=feedback(G3,H2*G4);
B2=series(G2,B1);
B3=feedback(B2,H1);
G13=series(G1,B3);
G14=series(G13,G4);
G0=feedback(G14,H3);

num=[1 9 21 21 20 12];
den=[2 50 589 2527 7496 11926 10008 4392];

roots(num)
roots(den)