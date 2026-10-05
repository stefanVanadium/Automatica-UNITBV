%% ex2

num_Gcd=[9];
den_Gcd=[1 6];

num_Gcr=[1];
den_Gcr=[1 0];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

bode(num_G,den_G)
%sistem stabil

%% ex3

A=[-6 0;1 0];
B=[1;0];
C=[0 3];

%% ex4

n1=[1];
d1=[1 3];

n2=[0.5];
d2=[1];

n3=[1];
d3=[1 2];

n4=[4];
d4=[1 4];

nblocks=4;
blkbuild;

q=[1 0 0 0;2 1 3 0;3 2 0 0; 4 2 0 0];

[A B C D]=connect(a,b,c,d,q,1,4);

[num den]=ss2tf(A,B,C,D);
G=tf(num,den)