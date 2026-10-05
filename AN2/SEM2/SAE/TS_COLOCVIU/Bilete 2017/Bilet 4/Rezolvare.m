%% ex1

n1=[1];
d1=[1];

n2=[0.5];
d2=[1];

n3=[4];
d3=[1 4];

n4=[1];
d4=[1 2];

nblocks=4;
blkbuild

q=[1 0 0 0 ;2 1 -4 0 ;3 2 0 0;4 3 0 0];

[A,B,C,D]=connect(a,b,c,d,q,1,3);

[num,den]=ss2tf(A,B,C,D);
g=tf(num,den)

%% ex2

num_Gcd=[1];
den_Gcd=[1 1 0];

num_Gcr=[1];
den_Gcr=[1 2];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,num_Gcr);

%studiul stabilitatii - Criteriul Nyquist
nyquist(num_G,den_G);
 %sistem stabil - punctul (-1 j0) nu este incercuit de cercul de raza unitara

%studiul stabilitatii - Caracteristici Bode
bode(num_G,den_G);

%studiul stabilitatii - Indicatori de calitate
margin(num_G,den_G);

%% ex4

A=[-6 0; 1 0];
B=[1;0];
C=[0 9];
