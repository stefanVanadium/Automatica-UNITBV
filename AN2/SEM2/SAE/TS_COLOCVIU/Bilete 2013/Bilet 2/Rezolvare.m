%% ex1

num_Gcd=1;
den_Gcd=[1 1 0];

num_Gcr=[1];
den_Gcr=[1 2];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

rlocus(num_G,den_G)

%% ex2

plot(out.y)

%% ex3

n1=[0.5];
d1=[1 1];

n2=[4];
d2=[1 4];

n3=[1];
d3=[1 2];

n4=[-2];
d4=[1];

nblocks=4;
blkbuild;

q=[1 -4 0;2 1 0;3 2 0;4 2 0];

[A B C D]=connect(a,b,c,d,q,1,3);
[num den]=ss2tf(A,B,C,D);
G0=tf(num,den)

%% ex5

A=[1 1 0.5;0 1 1;0 0 1];
B=[1 0;0 0;0 1];
C=[1 0 0;0 0 1];
