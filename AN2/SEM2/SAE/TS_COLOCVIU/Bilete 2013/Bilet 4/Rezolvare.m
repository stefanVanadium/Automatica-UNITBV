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
blkbuild;

q=[1 0 0;2 -4 1;3 2 0;4 3 0];

[A B C D]=connect(a,b,c,d,q,1,3);
[num den]=ss2tf(A,B,C,D);
G=tf(num,den)

%% ex2

num_Gcd=[1];
den_Gcd=[1 1 0];

num_Gcr=[1];
den_Gcr=[1 2];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

nyquist(num_G,den_G)
%% ex3

A=[-2 0;1 0];
B=[1;0];
C=[0 4];
D=[0];

[num den]=ss2tf(A,B,C,D);

[a f w]=bode(num,den);
t=[0:0.1:10];
y=a.*sin(w*t+f);
plot(y)

%% ex4

plot(out.y)

%% ex5

A=[-9 -3.25 -1.5;8 0 0;0 2 0];
B=[1;0;0];
C=[0 2 0];



