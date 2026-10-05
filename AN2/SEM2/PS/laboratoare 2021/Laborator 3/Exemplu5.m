%specificatiile impuse
wp=20;
Gp=0.7933;
ws=12;
Gs=0.1;

%specificatiile exprimate in dB - calcul impus de functia buttord
GpdB=20*log10(Gp);
GsdB=20*log10(Gs);

%determinarea functiei de transfer
[N1, wn1]=cheb1ord(wp,ws,GpdB,GsdB,'s');

%dtermninarea ordinului si a frecventei de frangere
[num1,den1]=cheby1(N1,1,wn1,'s');
g=tf(num1,den1)

%trasarea grafica a caracteristicii modul-pulsatiei
w=0:0.01:30;
[mag,phase]=bode(num1,den1,w);
plot(w,mag,[wp ws],[Gp Gs],'o')