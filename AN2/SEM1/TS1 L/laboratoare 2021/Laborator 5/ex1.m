%% proces 1

R=10000;
C=10^(-4);

%functia de transfer a sistemului
den_Gp1=[1/(R*C)];
num_Gp1=[1 1/(R*C)];
Gp1=tf(den_Gp1,num_Gp1);

%stabilitatea - determinarea pozitiei polilor
roots(num_Gp1);
    %polul sistemului se afla in semiplanul stang al planului s 
    % deci avem un sistem stabil
    
%stabilitatea - simulare 
subplot(4,1,1)
step(Gp1) % se observa ca sistemul se stabilizeaza

%raspunsul sistemului la o marime treapta unitara
syms a b s t y(t);
dy=diff(y,t);
ec=a*dy+b*y(t)==1;
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b y(0)];
values=[C*R 1 0];
ysol=subs(ysol,vars,values)

t1=[0:0.1:10];
for i=1:length(t1)
  y1(i)=1 - exp(-t1(i));
end
subplot(4,1,2)
plot(t1,y1)


%raspunsul la marimile rampa  unitara 
% raspuns: t-T+T*exp(-t) = t-1+exp(-t)
subplot(4,1,3)
lsim(Gp1,t1,t1)

 %raspunsul la marimea impuls unitar T=1
% raspuns: 1/T*exp(-t/T) = exp(-t)
subplot(4,1,4)
impulse(Gp1)


%% proces 2

L=1;
R=10;
C=51*10^(-5);

%functia de transfer a sistemului
den_Gp2=[1/(L*C)];
num_Gp2=[1 R/L 1/(L*C)];
Gp2=tf(den_Gp2,num_Gp2);

%stabilitatea - determinarea polilor
pzmap(den_Gp2,num_Gp2);

%stabilitatea - simulare
subplot(2,1,1)
step(Gp2)
   
%raspunsul sistemului la marimea treapta unitara
syms a b c s t y(t);
dy=diff(y,t);
dy2=diff(dy,t);
ec=a*dy2+b*dy+c*y(t)==1;
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b c dy(0) y(0)];
values=[C*L R*C 1 0 0];
ysol=subs(ysol,vars,values)

 t1=[0:0.1:10];
 for i=1:length(t1)
   y1(i)=1 - exp(-5*t1(i))*(cosh((201399^(1/2)*t1(i)*5i)/51) - (201399^(1/2)*sinh((201399^(1/2)*t1(i)*5i)/51)*1i)/3949);
 end
 subplot(2,1,2)
 plot(t1,y1)




