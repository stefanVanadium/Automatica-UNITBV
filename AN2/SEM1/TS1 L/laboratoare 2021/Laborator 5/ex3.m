%% Caz I

M=1;
B=2;
K=4;

den_Gp=[1];
num_Gp=[M B K];
Gp=tf(den_Gp,num_Gp)

step(Gp)

%% Caz 2

syms M B K s t y(t);
dy=diff(y,t);
dy2=diff(dy,t);
ec=M*dy2+B*dy+K*y(t)==1;
ecLt=laplace(ec,t,s)
syms y_t;
ecLt=subs(ecLt,laplace(y(t),t,s),y_t);
ecs=solve(ecLt,y_t);
ysol=ilaplace(ecs,s,t);
vars=[M B K dy(0) y(0)];
values=[1 2 4 0 15];
ysol=subs(ysol,vars,values)

  t1=[0:0.1:10];
  for i=1:length(t1)
     y1(i)=(59*exp(-t1(i))*(cosh(3^(1/2)*t1(i)*1i) - (3^(1/2)*sinh(3^(1/2)*t1(i)*1i)*1i)/3))/4 + 1/4;
  end
  plot(t1,y1)
    


