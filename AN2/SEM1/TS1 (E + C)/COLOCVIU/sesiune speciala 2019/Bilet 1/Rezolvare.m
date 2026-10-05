%% ex1
s=tf('s');
G=9/(s+3);
H=1/s;

%functie de transfer in circuit deschis
G0=G*H
%erorile stationare ale sistemului
 errortf([9],[1 3 0])

%functia de transfer in circuit inchis
Ge=feedback(G,H)
subplot(2,1,1);
step(Ge)

%polii sistemului
p=pole(Ge)

%modificare suprareglaj
num_G_mod=conv([9 0],[1 1]);
den_G_mod=[1 3 9];
G_mod=tf(num_G_mod,den_G_mod);
subplot(2,1,2);
step(G_mod)


%% ex2

x=[0:0.1:1];
F=1./((x-0.2).^2);
functie(x,F)

%% ex3

num_G1=[1];
den_G1=[1 2];
G1=tf(num_G1,den_G1);

num_G2=[1];
den_G2=[1 3];
G2=tf(num_G2,den_G2);

num_G3=[1 1];
den_G3=[1 6 0];
G3=tf(num_G3,den_G3);

num_H1=[7];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[5];
den_H2=[1];
H2=tf(num_H2,den_H2);

%modificare de topologie => H2/G1
H3=H2/G1;

G12=series(G1,G2);
Ge1=feedback(G12,H1);
Ge2=series(Ge1,G3);
Ge=feedback(Ge2,H3)

%% ex4
 
num_Gr=[20 10];
den_Gr=[1 0];
Gr=tf(num_Gr,den_Gr);

num_Gee=[1];
den_Gee=[1];
Gee=tf(num_Gee,den_Gee);

num_Gtr=[1];
den_Gtr=[1];
Gtr=tf(num_Gtr,den_Gtr);

R1=1.5;
R2=1.5;
C=2;

%a
num_Gp=[C*R2 0];
den_Gp=[(R1+R2)*C 1];
Gp=tf(num_Gp,den_Gp);

%b
syms a b  s t y(t) u(t);
dy=diff(y,t);
du=diff(u,t);
dy2=diff(dy,t);
ec=a*dy2+b*dy==R2*C*du;
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b u(t) u(0) y(0) dy(0)];
values=[C*(R1+R2) 1 1 0 0 0];
ysol=subs(ysol,vars,values)

 t1=[0:0.1:10];
 for i=1:length(t1)
  y1(i)=3 - 3*exp(-t1(i)/6)
 end
 subplot(2,1,1);
 plot(t1,y1)

%c
 Ge1=series(Gr,Gee);
 Ge2=series(Ge1,Gp);
 Ge=feedback(Ge1,Gp);
 u=ones(1,length(t1));
 subplot(2,1,2);
 lsim(Ge,u,t1)

%d
% erorile se det plecand de la functia de transfer in circuit deschis = Ge2 
errortf([60 30 0 ], [6 1 0])








