%% 2024
%% 2

s=tf('s');
G=1/(s+2);
H1=1/(s+3);
H2=5;
Gfb=feedback(G,H2);
T=Gfb+H1

%% 3

t=0:0.1:10;
num=6;
den=[1 4 6];
sys=ss(tf(num,den));
x0=[1;1];
u=t;
y=lsim(sys,u,t,x0);
plot(t,y)

s=tf('s');
Gr=2.07+3.27/s;
Gpf=6/(s^2+4*s+6);
Gol=Gr*Gpf;
Gcl=feedback(Gol,1)

t=0:0.1:10;
step(Gcl,t)
info=stepinfo(Gcl)

Gr2=1.2+3.27/s;
Gol2=Gr2*Gpf;
Gcl2=feedback(Gol2,1);
step(Gcl,Gcl2,t)

%% 4
% G = tf(180, [1 24 89 180]);

den=[1 24 89 180];
p=roots(den)

s=tf('s');
G=180/(s^3+24*s^2+89*s+180);

p=pole(G);
[~,i]=min(abs(p));
pdom=p(i);

pr=p; pr(i)=[];
ratio=min(abs(pr))/abs(pdom);

a=abs(real(pdom));
Gred=dcgain(G)*a/(s+a);

t=0:0.01:10;
step(G,Gred,t)

infoG=stepinfo(G);
infoGred=stepinfo(Gred);

dcG=dcgain(G);
dcGred=dcgain(Gred);

[ratio infoG.SettlingTime infoGred.SettlingTime infoG.Overshoot infoGred.Overshoot dcG dcGred]

%% 5