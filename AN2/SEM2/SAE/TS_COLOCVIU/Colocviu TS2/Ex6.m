%% Ex6
n1=[0.5];
d1=[1];

n2=[4];
d2=[1 4];

n3=[3];
d3=[1 3];;

n4=[1];
d4=[1 2];

nblocks=4;
blkbuild;

q=[1 0 0;2 -4 1; 3 2 0;4 2 0];

[A B C D]=connect(a,b,c,d,q,1,3)