num1 = [0.5];
den1 = [1];

num2 = [4];
den2 = [1 4];

num3 = [3];
den3 = [1 3];

num4 = [1];
den4 = [1 2];

nblocks=4 ;
blkbuild

q = [1 0 0; 2 0 -4; 3 2 0; 4 2 0];
[A,B,C,D] = connect(a,b,c,d,q,1,3);
[num,den] = ss2tf(A,B,C,D);
G = tf(num, den)