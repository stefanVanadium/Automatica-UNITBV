f=[4 0 -2 0 3 -1 4];
g=[0 0 0 0 2 5 -16];

s= f+g
d=f-g

a=polyval(f,3)-polyval(g,7)
b=[1 3 4 9];
polyval(f,b)
polyval(g,b)

g=[2 5 -16];
p=conv(f,g)
[d,r]=deconv(f,g)

dp=polyder(p)
di=polyder(d)

roots(f,0)
roots(g,0)