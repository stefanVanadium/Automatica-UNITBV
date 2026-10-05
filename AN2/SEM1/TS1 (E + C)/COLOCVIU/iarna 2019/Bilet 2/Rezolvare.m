%% ex1

%a

%functia de tranfer in circuit deschis
s=tf('s');
G0=9/(s*(s+2));

%errortf(G0);

%b
num_H=[1];
den_H=[1];
H=tf(num_H,den_H);

%functia de transfer in circuit inchis
subplot(2,1,1);
step(Ge)
Ge=feedback(G0,H);

p=pole(Ge)

num_G_mod=conv([9],[1 0.5]);
den_G_mod=conv([1 2 9],[0 0 0.5]);
G_mod=tf(num_G_mod,den_G_mod)
subplot(2,1,2);
step(G_mod)


%% ex2

x=[0:0.1:1];
F=1./(x-0.2).^2;
functie(x,F);

%% ex3

s=tf('s');
G3=1/(s+4);
G4=(s+1)/(s+6);

num_H1=[3];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[5];
den_H2=[1];
H2=tf(num_H2,den_H2);

%modificare de topologie
H3=H1/G4;

Ge1=feedback(G4,H2);
Ge2=series(G3,Ge1);
Ge=feedback(Ge2,H3)
%% ex4

s=tf('s');
Gr=1/2/(s*s);

num_Gee=[1];
den_Gee=[1];
Gee=tf(num_Gee,den_Gee);

num_Gtr=[1];
den_Gtr=[1];
Gtr=tf(num_Gtr,den_Gtr);

R=10*10^3;
C=100*10^(-6);

%a
Gp=(s*R*C)/(s*C*R+1);

%b
syms a b  s t y(t) u(t);
dy=diff(y,t);
du=diff(u,t);
ec=a*dy+b*y(t)==C*du
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b y(0) u(t) u(0)];
values=[C 1/R 0 1 0];
ysol=subs(ysol,vars,values)

 t1=[0:0.1:10];
 for i=1:length(t1)
   y1(i)=exp(-t1(i));
 end
 subplot(2,1,1);
 plot(t1,y1)

%c
Ge1=series(Gr,Gee);
Ge2=series(Ge1,Gp);
Ge=feedback(Ge2,Gtr)
subplot(2,1,2);
step(Ge)

%d
