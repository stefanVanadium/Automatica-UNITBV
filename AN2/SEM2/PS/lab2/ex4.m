
w = 0:0.1:30;

z = [];

p = [-3+4j -3-4j -8+12j -8-12j];

k = prod(p);

[num,den] = zp2tf(z,p,k);

Gw = bode(num,den,w);

plot(w,Gw)
grid on
