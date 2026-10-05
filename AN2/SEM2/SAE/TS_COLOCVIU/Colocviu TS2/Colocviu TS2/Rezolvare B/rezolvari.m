%% 2
num=[1 5 11];
den=[1 2 4];

[A,B,C,D]=tf2ss(num,den)

%sistemul este observabil
%% 3 a
num=[1 1];
den=[1 10];

bode(num,den);
% T1=1
% T2=1/10
% k=1/10
%% 3 b
t=[0:0.1:10];
u=3*sin(2*t)
bode(num,den,u)

%% 4
k =1/25;
num=[k];
den=[1 5 0];

nyquist(num,den)
%sistemul este stabil
%% 5 a

num_1=[1];
den_1=[1 1 0];

num_2=[1];
den_2=[1 2];

[num_d,den_d]=series(num_1,den_1,num_2,den_2);

rlocus(num_d,den_d)

% (-inf,-2) U (-1, 0)
% 3 ramuri -> inf
% (-0,4, 0) punct de ramif
%% 5 b
[k,p]=rlocfind(num_d,den_d)

%pentru K=17 sistemul este instabil
%% 6

n1 = 0.5;
d1 = 1;

n2 = 4;
d2 = [1 4];

n3 = 1;
d3 = [1 2];

q = [1 -3 0 0;
     2 1 0 0;
     3 1 0 0];
     

iu = 1;
iy = 2;

nblocks = 3;
blkbuild
[A,B,C,D] = connect(a,b,c,d,q,iu,iy);

[num,den] = ss2tf(A,B,C,D);
G = tf(num,den)
%%
