num_G=[5 0 1];
den_G=[1 3 3 1];
G=tf(num_G,den_G);
%zerourile functiei de transfer G
roots(num_G);
%polii functiei de transfer G
roots(den_G);

[p,z]=pzmap(num_G,den_G)
%metoda 2 - determinarea polilor si zerourilor 

r=[0 -2];
num_H=poly(r)
r=[4i -4i -3];
den_H=poly(r);
H=tf(num_H,den_H)
%zerourile functiei H
roots(num_H);
%polii functiei H
roots(den_H);

pzmap(num_H,den_H);

%G(s)/H(s)
num_imp=conv(num_G,den_H);
den_imp=conv(den_G,num_H);
imp=tf(num_imp,den_imp)

%poli imp
pzmap(num_imp,den_imp)

