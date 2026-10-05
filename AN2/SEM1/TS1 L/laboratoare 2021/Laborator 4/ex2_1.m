syms a b c s t y(t);
dy=diff(y,t);
dy2=diff(dy,t);
ec=a*dy2+b*dy+c*y(t)==2*t
ecLt=laplace(ec,t,s);
syms y_t
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b c y(0) dy(0)];
values=[1 2 5 0 0];
ysol=subs(ysol,vars,values)

