%% ex1

plot(out.y)

%% ex2

num_Gcd=[25];
den_Gcd=[1 1 0];

num_Gcr=[1];
den_Gcr=[1 10];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

[ma mf w]=bode(num_G,den_G);

madb=20*log10(ma);

plot(w,madb)

%% ex3

num_Gcd=[9];
den_Gcd=[1 6];

num_Gcr=[1];
den_Gcr=[1 0];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

rlocus(num_G,den_G)

%% ex4

A=[-1 -1;6.5 0];
B=[1 1;1 0];
C=[1 0;0 1];

%% ex5

n1=[1];
d1=[1 3];

n2=[0.5];
d2=[1];

n3=[4];
d3=[1 4];

n4=[1];
d4=[1 2];

nblocks=4;
blkbuild;

q=[1 0 ;2 4;3 2;4 2];

[A B C D]=connect(a,b,c,d,q,1,3);
[num den]=ss2tf(A,B,C,D);
G0=tf(num,den)


