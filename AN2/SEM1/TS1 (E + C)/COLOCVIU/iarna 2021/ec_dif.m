syms a b c s t y(t);
dy=diff(y,t);
dy2=diff(dy,t);
ec=a*dy2+b*dy+c*y(t)==3
ecLt=laplace(ec,t,s);
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b c y(0) dy(0)];
values=[1 4.2 3 0 0 0];
ysol=subs(ysol,vars,values)

t1=[0:0.1:10];
for i=1:length(t1)
  y1(i)=
end
plot(t1,y1)