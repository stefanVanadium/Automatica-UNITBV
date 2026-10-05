n1=[0.5];
d1=[1];

n2=[4];
d2=[1 4];

n3=[1];
d3=[1 2];

nblocks=3;
blkbuild;

q=[1 0 0; 2 1 -3; 3 2 0];
[A,B,C,D]=connect(a,b,c,d,q,1,2);
[num, den]=ss2tf(A,B,C,D,1)
%  SS2TF transforma din spatiul starilor in num si den
G=tf(num,den)