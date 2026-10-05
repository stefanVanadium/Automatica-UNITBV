%% ex1

num_G1=[1];
den_G1=[1 1 0];

Te=0.1;
[num_G1z den_G1z]=c2dm(num_G1,den_G1,Te,'zoh');

num_G2=[2];
den_G1=[1 1];

[num_G2z den_G2z]=c2dm(num_G2,den_G2,Te,'zoh');

[num_Gz den_Gz]=series(num_G1z,den_G1z,num_G2z,den_G2z);
G2=tf(num_Gz,den_Gz,Te)


%% ex2

gama=[0 -0.25;1 1];
fi=[1;1];
C_1=[0 1];

%% ex3

A=[0 -0.25;1 1];
B=[1;1];
C=[0 1];
D=[0];

Te=0.1;
[gama fi C_1 D_1]=c2dm(A,B,C,D,Te,'zoh');

obsv(gama,C_1)
ctrb(gama,fi)

[num_Gz den_Gz]=ss2tf(gama,fi,C_1,D_1);

w=[0:01:4]
[mag phase]=dbode(num_Gz,den_Gz,Te,w)

y=mag.*sin(w*Te+phase);
plot(w,y);

%% ex5

num_G=[9];
den_G=[1 7 0];

Te=0.1
[num_Gz den_Gz]=c2dm(num_G,den_G,Te,'zoh');
w=logspace(-1,2)
[mag phase]=dbode(num_Gz,den_Gz,Te,w);

plot(w,mag,w,phase)

