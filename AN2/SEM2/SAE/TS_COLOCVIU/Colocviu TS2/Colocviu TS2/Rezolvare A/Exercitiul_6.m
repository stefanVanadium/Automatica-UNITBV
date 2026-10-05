n1 = [1];
d1 = [2];

n2 = [4];
d2 = [1 4];

n3 = [1];
d3 = [1 2];

nblocks = 3;
blkbuild;

q = [1 -3; 2 1; 3 1 ];

%numarul blocului de intrare
iu = 1;

%numarul blocului de iesire
iy = 3;

[A,B,C,D] = connect(a,b,c,d,q,iu,iy);

[num,den]=ss2tf(A,B,C,D,iu);

G = tf(num,den)


