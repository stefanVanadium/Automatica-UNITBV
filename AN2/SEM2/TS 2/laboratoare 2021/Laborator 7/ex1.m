%regulatoarele
num_Gr1=[0.7 2.38];
den_Gr1=[1 0];
Gr1=tf(num_Gr1,den_Gr1);

num_Gr2=[0.26 0.35];
den_Gr2=[1 0];
Gr2=tf(num_Gr2,den_Gr2);

%procesele
num_G11=[2];
den_G11=[0.6 1];
G11=tf(num_G11,den_G11);

num_G12=[0.1];
den_G12=[0.7 1];
G12=tf(num_G12,den_G12);

num_G21=[0.4];
den_G21=[0.9 1];
G21=tf(num_G21,den_G21);

num_G22=[5];
den_G22=[1.5 1];
G22=tf(num_G22,den_G22);

%matricea de proces
Gp=[G11 G12; G21 G22]

%matricea de reglare
Gr=[Gr1 0; Gr2 0];

%circuit deschis
G=series(Gp,Gr)

%circuit inchis
G0= feedback(G,eye(2));

%simulare raspuns procese
step(Gp);
%functiile de transfer secundare influenteaza iesirile
%nu merg spre 0 in absenta reglarii

%caracteristci Bode
bode(G)

%caracteristica Nyquist doar pentru procesele principale
% subplot(2,1,1);
% nyquist(Gp(1,1));
% subplot(2,1,2);
% nyquist(Gp(2,2));


