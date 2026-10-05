%% ex2

n1=[1 1];
d1=[1 2];

n2=[1];
d2=[1 1];

n3=[1 5];
d3=[1 5 6];

nblocks=3;
blkbuild;

q=[1 3;2 1;3 2];

[A B C D]=connect(a,b,c,d,q,1,2);

[num,den]=ss2tf(A,B,C,D,1);

G=tf(num,den)

%% ex3

A=[0 1; -25 -4];
B=[1 1; 0 1];
C=[1 0;0 1];

%%  ex4

k=[0:0.5:12];

num_G=[1];
den_G=[1 4 0 0];

rlocus(num_G,den_G,k)

%% ex5


bode([1000], [1 1])
k=1/10;
T=1/10;

%f de tf experim
num=[1];
den=[1 10 0];
Gd=tf(num,den)
bode(num,den)

%rasp in frecventa
[numG0,denG0]=cloop(num,den);
