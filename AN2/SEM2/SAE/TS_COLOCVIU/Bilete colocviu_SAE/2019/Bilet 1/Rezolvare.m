%% ex1

num_Gr=[3 1];
den_Gr=[5 1];

[nz dz]=c2dm(num_Gr,den_Gr,0.1,'zoh');
num_Grz= conv(nz, [1 0]);
den_Grz= conv(dz, [1 -1]);



%% ex2

num_G=[9];
den_G=[1 2 0];

[num_Gz,den_Gz]=c2dm(num_G,den_G,0.1,'zoh');

rlocus(num_Gz,den_Gz)
zgrid;

%% ex3

A=[-6 0;1 0];
B=[1;0];
C=[0 9];
D=[0];

Te=0.1

[fi gama C_1 D_1]=c2dm(A,B,C,D,Te,'zoh');

det(ctrb(fi,gama))
[num_Gz den_Gz]=ss2tf(fi,gama,C_1,D_1);

[num_G0z den_G0z]=feedback(num_Gz,den_Gz,1,1);

[fi gama C_1 D_1]=tf2ss(num_G0z,den_G0z);

w=[0:0.01:4];
[mag phase]=dbode(fi,gama,C_1,D_1,Te,1,w);

y=mag.*sin(w*Te+phase);

plot(w,y)

%% ex 4

num_G2=[1];
den_G2=[1 1];

Te=0.1
[num_Gcdz den_Gcdz]=c2dm(num_G2,den_G2,Te,'zoh');
Gcdz=tf(num_Gcdz,den_Gcdz,Te)

num_H=[1 3];
den_H=[1 2];

[num_G den_G]=series(num_G2,den_G2,num_H,den_H);

[num_Gz den_Gz]=c2dm(num_G,den_G,Te,'zoh');
Gz=tf(num_Gz,den_Gz,Te)

G=Gcdz/(1+Gz)

%%  ex5

fi=[0.21 -0.98;0.1 0.87];
gama=[0.1;0.01];
C_1=[0 9];







