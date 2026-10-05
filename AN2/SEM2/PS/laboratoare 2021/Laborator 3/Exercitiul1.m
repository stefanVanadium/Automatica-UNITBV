%% a - Varianta 1 

%specificatiile impuse
wp=10;
Gp=0.794;
ws=20;
Gs=0.1;

%specificatiile exprimate in dB - calcul impus de functia buttord
GpdB=20*log10(Gp);
GsdB=20*log10(Gs);

%determinarea functiei de transfer
[N1, wn1]=cheb2ord(wp,ws,GpdB,GsdB,'s');

%dtermninarea ordinului si a frecventei de frangere
[num1,den1]=cheby2(N1,1,wn1,'s');

%trasarea grafica a caracteristicii modul-pulsatiei
w=0:0.01:30;
[mag,phase]=bode(num1,den1,w);
plot(w,mag,[wp ws],[Gp Gs],'o')

%% a Varianta 2

%specificatiile impuse
wp=10;
Gp=0.794;
ws=20;
Gs=0.1;

%specificatiile exprimate in dB - calcul impus de functia buttord
GpdB=20*log10(Gp);
GsdB=20*log10(Gs);

%determinarea functiei de transfer
[N1, wn1]=butpord(wp,ws,GpdB,GsdB,'s');

%dtermninarea ordinului si a frecventei de frangere
[num1,den1]=butter(N1,1,2,wn1,'s');

%trasarea grafica a caracteristicii modul-pulsatiei
w=0:0.01:30;
[mag,phase]=bode(num1,den1,w);
plot(w,mag,[wp ws],[Gp Gs],'o')

%% b - Varianta 1

%specificatiile impuse
wp=20;
Gp=0.794;
ws=10;
Gs=0.1;

%specificatiile exprimate in dB - calcul impus de functia buttord
GpdB=20*log10(Gp);
GsdB=20*log10(Gs);

%determinarea functiei de transfer
[N1, wn1]=cheb2ord(wp,ws,GpdB,GsdB,'s');

%dtermninarea ordinului si a frecventei de frangere
[num1,den1]=cheby2(N1,1,wn1,'s');

%trasarea grafica a caracteristicii modul-pulsatiei
w=0:0.01:30;
[mag,phase]=bode(num1,den1,w);
plot(w,mag,[wp ws],[Gp Gs],'o')

%% c Varianta 1

%specificatiile impuse
wp1=2;
wp2=28;
Gp=0.794;
ws1=12;
ws2=18;
Gs=0.1;

%specificatiile exprimate in dB - calcul impus de functia buttord
GpdB=20*log10(Gp);
GsdB=20*log10(Gs);

R=1;
% detreminarea ordinului si a fecventei de frangere
[N1,wn1]=cheb2ord([wp1 wp2],[ws1 ws2],GpdB,GsdB,'s');

% determinarea fc transfer
[num1,den1]=cheby2(N1,1,wn1,'s');

%trasarea grafuca a caracteristicii modul-pulsatie
w=0:0.01:30;
[mag,phase]=bode(num1,den1,w);
plot(w,mag,[wp1 wp2 ws1 ws2],[Gp Gp Gs Gs],'o')