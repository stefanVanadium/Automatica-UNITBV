%% ex1

num_G=[9];
den_G=[1 7 0];

Te=0.1;
[num_Gz den_Gz]=c2dm(num_G,den_G,Te,'zoh');

rlocus(num_Gz,den_Gz)
zgrid

%% ex3

num_G1=[1];
den_G1=[1 1 0];

Te=0.2;

[num_G1z den_G1z]=c2dm(num_G1,den_G1,Te,'zoh');

num_G2=[2];
den_G2=[1 1];

[num_G2z den_G2z]=c2dm(num_G2,den_G2,Te,'zoh');

[num_Gz den_Gz]=series(num_G1z,den_G1z,num_G2z,den_G2z)
Gz=tf(num_Gz,den_Gz,Te);

%% ex4

num_G=[9];
den_G=[1 3 0];

Te=0.1;
[num_Gz den_Gz]=c2dm(num_G,den_G,Te,'zoh');

w=logspace(-1,2);
[mag phase]=dbode(num_Gz,den_Gz,Te,w)

plot(w,mag,w,phase)

%% ex5

gama=[1 1 0.5;0 1 1;0 0 1];
fi=[1 0;0 0;0 1];
C=[1 0 0;0 0 1]


