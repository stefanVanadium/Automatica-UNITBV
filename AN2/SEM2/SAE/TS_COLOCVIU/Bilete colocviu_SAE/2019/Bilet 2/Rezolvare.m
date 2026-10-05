%% ex1

num_G=[9];
den_G=[1 2 0];

Te=0.1;
[num_Gz den_Gz]=c2dm(num_G,den_G,Te,'zoh');

dnyquist(num_Gz,den_Gz,Te)
%sistem stabil

%% ex2

num_G1=[1];
den_G1=[1 1];

num_G2=[1 3];
den_G2=[1 2];

[num_G1z den_G1z]=c2dm(num_G1,den_G1,Te,'zoh');
Gcdz=tf(num_G1z,den_G1z,Te)

[num_G2z den_G2z]=c2dm(num_G2,den_G2,Te,'zoh');

[num_Gbz den_Gbz]=series(num_G1z,den_G1z,num_G2z,den_G2z)
Gbz=tf(num_Gbz,den_Gbz,Te);

Ge=Gcdz/(1+Gbz)

%% ex 3

num_Gr=[3 1];
den_Gr=[5 1];

[num_Grz den_Grz]=c2dm(num_Gr,den_Gr,0.1,'zoh');

%% ex4

A=[-7 0;1 0];
B=[1;0];
C=[0 9];
D=[0];

Te=0.1;
[fi gama C_1 D_1]=c2dm(A,B,C,D,Te,'zoh');

O=obsv(fi,C_1)

[num_G den_G]=ss2tf(fi,gama,C_1,D_1);

[num_G0 den_G0]=feedback(num_G,den_G,1,1);

w=[0:01:4]
[mag phase]=dbode(num_G,den_G,Te,w)

y=mag.*sin(w*Te+phase)

plot(w,y)

%% ex5

gama=[0.21 -0.87;0.1 0.01];
fi=[0.1;0.01];
C_1=[0 9];


