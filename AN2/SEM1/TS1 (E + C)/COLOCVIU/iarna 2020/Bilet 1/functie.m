function [] = functie(R,C,L)

syms a b c s t y(t);
dy=diff(y,t);
dy2=diff(dy,t);
ec=a*dy2+b*dy+c*y(t)==1
ecLt=laplace(ec,t,s);
syms y_t
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[a b c y(0) dy(0)];
values=[L*C R*C 1 0 0];
ysol=subs(ysol,vars,values)

t1=[0:0.1:10];
for i=1:length(t1)
  y1(i)=1 - exp(-5000*t1(i))*(cosh(100*2499^(1/2)*t1(i)) + (50*2499^(1/2)*sinh(100*2499^(1/2)*t1(i)))/2499)
end

plot(t1,y1)

end

