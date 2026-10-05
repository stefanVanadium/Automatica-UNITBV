t=[-2:0.02:2];
T=meshgrid(t);
x=cos(2*pi*T);
y=sin(2*pi*T);
mesh(x)
hold on;
mesh(y)
