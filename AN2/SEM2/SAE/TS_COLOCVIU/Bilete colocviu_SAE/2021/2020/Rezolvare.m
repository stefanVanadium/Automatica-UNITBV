%% ex 2

num_Gr=[1 0];
den_Gr=[1 2];

[num_Grz,den_Grz]=c2dm(num_Gr,den_Gr,0.1,'zoh');

%% ex3

num_G1=[1];
den_G1=[1 1];

num_G2=[1 3];
den_G2=[1 2];

Te=0.1;

[num_G1z den_G1z]=c2dm(num_G1,den_G1,Te,'zoh');
Gcdz=tf(num_G1z,den_G1z,Te);

[num_G2z den_G2z]=c2dm(num_G2,den_G2,Te,'zoh');

[num_Gb,den_Gb]=series(num_G1z,den_G1z,num_G2z,den_G2z);

Gb=tf(num_Gb,den_Gb,Te);

G0=Gcdz/(1+Gb)

%% ex4

A=[-4 0;1 0];
B=[1;0];
C=[0 9];
D=[0];

[fi gama C_1 D_1]=c2dm(A,B,C,D,0.1,'zoh');

[num_Gz den_Gz]=ss2tf(fi,gama,C_1,D_1)

dnyquist(num_Gz,den_Gz,0.1)
%sistem stabil

det(obsv(fi,C_1))
%sistem observabil

%% ex5

num_G=[9];
den_G=[1 6 0];

[num_Gz den_Gz]=c2dm(num_G,den_G,0.1,'zoh');

[num_G0z den_G0z]=feedback(num_Gz,den_Gz,1,1);

% dstep(num_G0z,den_G0z)

[p,z] = pzmap(num_G0z,den_G0z);
zplane(z,p)