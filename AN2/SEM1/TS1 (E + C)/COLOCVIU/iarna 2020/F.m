function [ x ] = F( R,C,L)

% G=s^2/(s^2+(R/L)*s+(1/L*C));
syms a b c s t y(t)
cond=y(0)==0;
condl=diff(cond)==0;
dy=diff(y,t);
dy2=diff(dy,t);
ec=a*dy2+b*dy+c*y(t)==t^2/2; %parabola t^2/2
ecLt=laplace(ec,t,s);
syms y_t m
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b c y(0) 'D(y)'];
values=[1 L/R 1/(L*C) 0 m];
ysol=subs(ysol,vars,values);
ysol=subs(ysol,'m(0)',0)
SOL=......
t=[0:0.1:10];
x=plot(sol,t)

end

