%% ex1

x=[0:0.1:1];
F=1./(x-0.3).^2;

functie(x,F)

%% 2

num_Gr=[3.2 3];
den_Gr=[1 0];
Gr=tf(num_Gr,den_Gr)

num_Gee=[1];
den_Gee=[1];
Gee=tf(num_Gee,den_Gee);

num_Gtr=[1];
den_Gtr=[1];
Gtr=tf(num_Gtr,den_Gtr);

R=10*10^3;
C=100*10^(-6);

%a
num_Gp=[1];
den_Gp=[R*C 1];
Gp=tf(num_Gp,den_Gp);

%b
 syms a b c s t y(t) u(t);
 dy=diff(y,t);
 ec=a*dy+b*y(t)==u(t)
 ecLt=laplace(ec,t,s);
 syms y_t;
 ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
 ecs=solve(ecLt,y_t);
 ysol=ilaplace(ecs,s,t);
 vars=[a b y(0)];
 values=[C*R 1 0 ];
 ysol=subs(ysol,vars,values)

 t1=[0:0.1:10];
 for i=1:length(t1)
   y1(i)=1 - exp(-t1(i))
 end
 subplot(2,1,1);
 plot(t1,y1) 

%c
G1=series(Gr,Gee);
G2=series(G1,Gp);
Ge=feedback(G2,Gtr);
subplot(2,1,2);
step(Ge)

%d din raspunsul sistemului de la c) avem
  %tc=0.7s - timp de crestere
  %ts=1.4s - timp de stabilire

%% ex3

num_G1=[1];
den_G1=[1 2];
G1=tf(num_G1,den_G1);

num_G3=[1];
den_G3=[1 4];
G3=tf(num_G3,den_G3);

num_G4=[1 1];
den_G4=[1 6 0];
G4=tf(num_G4,den_G4);

num_H1=[3];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[5];
den_H2=[1];
H2=tf(num_H2,den_H2);

%modificare topologie
H3=H1/G4;

G34=series(G3,G4);
Ge1=feedback(G34,H2);
Ge2=feedback(H2,H1);
Ge=series(G1,Ge2)

%% ex4

%a 

%functia de transfer in circuit deschis
num_G0=[9];
r=[0,-3];
den_G0=poly(r);
G0=tf(num_G0,den_G0);

% errortf(num_G0,den_G0)

%b

%functia de transferin circuit inchis;
H1=tf([1],[1]);
Ge=feedback(G0,H1)
subplot(2,1,1);
step(Ge);

p=pole(Ge)

%micsorare suprareglaj
num_G_mod=conv([9],[1]);
den_G_mod=conv([1 3 9],[1 1]);
G_mod=tf(num_G_mod,den_G_mod)
subplot(2,1,2);
step(G_mod)
