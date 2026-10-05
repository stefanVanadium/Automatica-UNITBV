%% ex1

num_G1=[1];
den_G1=[1 1 0];

Te=0.1
[num_G1z den_G1z]=c2dm(num_G1,den_G1,Te,'zoh');

num_G2=[2 0];
den_G2=[1 4 0];

[num_G2z den_G2z]=c2dm(num_G2,den_G2,Te,'zoh');
num_G2z=conv(num_G2z,[1 0]);
den_G2z=conv(den_G2z,[1 -1]);

[num_Gz den_Gz]=series(num_G1z,den_G1z,num_G2z,den_G2z);
G2z=tf(num_Gz,den_Gz,Te)

%% ex 2

A=[0 -0.25;1 1.5];
B=[1;1];
C=[0 1];
D=[0];

[gama fi C_1 D_1]=c2dm(A,B,C,D,Te,'zoh');

[num_Gz den_Gz]=ss2tf(gama,fi,C_1,D_1);

w=[0:0.01:4];
[mag phase]=dbode(num_Gz,den_Gz,Te,w)

y=mag.*sin(w.*Te+phase);

plot(w,y);

%% ex3

num_G=[9];
den_G=[1 3 0];

Te=0.1;
[num_Gz den_Gz]=c2dm(num_G,den_G,Te,'zoh');

subplot(2,1,1);
rlocus(num_Gz,den_Gz);
zgrid;

w=[0:0.01:4]
subplot(2,1,2);
[mag phase]=dbode(num_Gz,den_Gz,Te,w)
y=mag.*sin(w.*Te+phase);
plot(w,y)

%% ex5

gama=[-9 -3.25 -1.5;8 0 0;0 2 0];
fi=[1;0;0];
C_1=[0 2 0];

