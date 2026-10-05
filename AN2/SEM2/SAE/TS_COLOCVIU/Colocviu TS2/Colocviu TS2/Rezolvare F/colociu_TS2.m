%ex1
num=[1,3,12];
den=[1,3,6];
[A,B,C,D]=tf2ss(num,den)

[num1,den1]=ss2tf(A,B,C,D);
P=obsv(A,C);
%%
%ex3
a=6
num=9
den=[1,a,0];
nyquist(num,den)
%stabil ,se afla in afara conturului

%%
%ex4
num=1;
den=[1,4,0,0];
g1=tf(num,den);
%rlocus(num,den)
[num2,den2]=feedback(g1,1)
[k,poli]=rlocfind(num2,den2)
%%
n1=0.5;
d1=1;

n2=4;
d2=[1,4];

n3=3;
d3=[1,3];

n4=1;
d4=[1,2];

nblocks=4;
blkbuild;
q=[1,0,0;
   2,1,-4;
   3,2,0;
   4,2,0]
iu=1;
iy=3;
[A,B,C,D]=connect(a,b,c,d,q,iu,iy)
%%
%ex2
%wf1=1  =>T=1/wf=1
%wf2=10  =>T=1/wf=1/10
%al doilea grafic pleaca din 0  =>nu are integrator
%-20=20lgK => lgk=-1 =>k-1/10;
%se inlocuieste t in s*T+1
%functia este
Gs=tf([1,1],[1,10]);
t=[0:0.1:10];
Gsf=feedback(Gs,1);
r=3*sin(2*t);
numGsf=[1,1];
denGsf=[2,11];
bode(numGsf,denGsf,r)
