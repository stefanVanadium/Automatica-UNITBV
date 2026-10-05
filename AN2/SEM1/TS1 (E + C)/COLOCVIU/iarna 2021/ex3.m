R1=10*10^3;
R2=10*10^3;
C=100*10^(-6);

syms a b c s t y(t) u(t);
u(t)=t;
dy=diff(y,t);
du=diff(u,t)
ec=a*dy+b*y(t)==R2*C*du
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b u(0) y(0) dy(0)];
values=[C*(R1+R2) 1  0 0 0];
ysol=subs(ysol,vars,values)

 t1=[0:0.1:10];
 for i=1:length(t1)
 y1(i)=1 - exp(-t1(i)/2)
end
 plot(t1,y1)

