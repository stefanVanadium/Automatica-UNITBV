%% ex1

plot(out.y)

%% ex2

n1=[1 1];
d1=[1 2];

n2=[1];
d2=[1 1];

n3=[1 5];
d3=[1 5 6];

nblocks=3;
blkbuild;

q=[1 -3;2 1;3 2];

[A B C D]=connect(a,b,c,d,q,1,2);

[num den]=ss2tf(A,B,C,D);
G=tf(num,den);

%% ex3

A=[-1 0; 1 0];
B=[1;0];
C=[0 0.1];
D=0;

[num den]=ss2tf(A,B,C,D)

[a,f,w]=bode(num,den);
f=deg2rad(f);
t=[0:0.1:10];
y=a.*sin(w.*t+f);
subplot(2,1,1)
plot(y)

subplot(2,1,2)
nyquist(num,den)

%% ex4

k=[0:0.5:12];

num=[1];
den=[1 4 0 0];

rlocus(num,den,k)

%% ex5

num=[10];
den=[1 4 4];

w=[0:0.02:8];
[a f]=bode(num,den,w);

adb=20*log10(a)
plot(w,adb,w,f)




