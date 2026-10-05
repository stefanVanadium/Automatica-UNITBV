syms a b c t s y(t);
dy=diff(y,t);
dy2=diff(dy,t);
ec=a*dy2+3*dy+2*y(t)==3;
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b c y(0) dy(0)];
values=[1 3 2 1 2];
ysol=subs(ysol,vars,values)