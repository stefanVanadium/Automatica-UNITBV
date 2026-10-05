function [ysol] = rez_ec(c)



syms a b s t y(t);
dy=diff(y,t);
ec=a*dy+b*y(t)==c;
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b y(0)];
values=[C*R 1 0];
ysol=subs(ysol,vars,values);

end

