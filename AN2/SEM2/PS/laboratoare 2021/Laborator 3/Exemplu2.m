%Proiectare filtru trece sus 

%specificatiile impuse
wp=20;
Gp=0.794;
ws=10;
Gs=0.1;

%specificatiile exprimate in dB - calcul impus de functia buttord
GpdB=20*log10(Gp);
GsdB=20*log10(Gs);

%determinarea functiei de transfer
[num1, den1]=butter(N1,wn1,'high','s');
%trasarea grafica a caracteristicii modul-pulsatie
w=0:0.01:30;
[mag,phase]=bode(num1,den1,w);
plot(w,mag,[wp ws],[Gp Gs],'o');
grid
n=2
[z,p,k]=buttap(n);
%returneaza zerourile, polii si amplificarea FB de ordinul n
[num,den]=zp2tf(z,p,k)
% returneaza numaratorul si numitorul functiei de transfer a FB
