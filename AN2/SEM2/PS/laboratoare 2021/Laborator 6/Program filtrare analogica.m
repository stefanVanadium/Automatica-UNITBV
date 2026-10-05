%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Semnalul original
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Pasul pentru generarea semnalului "continuu"
Te = 0.001;
% Semnalul este generat pentru 100 de secunde
t = 0:Te:100;
% Semnalul "continuu", format din 4 sinosoide (putem incerca diferite
% forme), de frecvente 10Hz, 20Hz, 80Hz, 90Hz
x = sin(2*pi*10*t) + sin(2*pi*20*t) + sin(2*pi*80*t) + sin(2*pi*90*t);
% In punctul acesta, putem considera ca avem un semnal x continuu, pe care
% il vom filtra timp de 100 de secunde
% Sa vedem cum arata semnalul 'inregistrat' timp de o secunda
subplot(2,3,1)
plot(t(1:1/Te),x(1:1/Te))



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Spectrul semnalului original, cu perioada de esantionare Te utilizata la
% 'inregistrarea' ( = generarea) semnalului x
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
X = fft(x);
L = length(x);
Xabs = abs(X)/(L/2);
MagX = Xabs(1:L/2+1);
% Frecventa de esantionare
fe = 1/Te;
% Domeniul de valori ale frecventei pentru care reprezentam grafic spectrul
% seamnalului x
f = fe*[0:(L/2)]/L;
% Sa vedem cum arata spectrul de amplitudine, pe domeniul considerat
subplot(2,3,2)
plot(f, MagX)



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Proiectarea unui filtru trece jos analogic (Butterworth)
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Banda de trecere, in Hz
fp = 30;
% Castigul minim in banda de trecere
Gp = 0.95;
% Banda de oprire, in Hz
fs = 60;
% Castigul maxim in banda de oprire
Gs = 0.05;
% Datele de proiectarea trebuie adaptate pentru utilizarea filtrului
% Butterworth
wp = 2*pi*fp;
GpdB = 20*log10(Gp);
ws = 2*pi*fs;
GsdB = 20*log10(Gs);
% Determinarea ordinului si frecentei de frangere a filtrului Butterworth
% analogic
[N,wc] = buttord(wp,ws,GpdB,GsdB,'s');
% Determinarea numaratorului si numitorului functiei de transfer a
% filtrului Butterworth trece-jos analogic
[num,den] = butter(N,wc,'s');


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Caracteristica modul-pulsatie a filtrului obtinut
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Domeniul de frecventa pentru care trasam caracteristica
f = 0:0.01:100;
% Pentru obtinerea caracteristicii, folosim functia bode
[mag,phase] = bode(num,den,2*pi*f);
% Si sa vedem cum arata
subplot(2,3,3)
plot(f,mag,[fp fs],[Gp Gs],'o');grid



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Filtrarea semnalului original
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Semnalul filtrat cu filtrul analogic proiectat se obtine cu functia lsim.
% (Functia 'filter' se utilizeaza pentru filtre discrete.)
filtru_analogic = tf(num,den);
% Filtrarea (simularea filtrarii analogice) se face pentru tot domeniul de
% generare a semnalului original
y = lsim(filtru_analogic,x,t);
% Sa vedem cum arata semnalul filtrat, pentru un interval de o secunda
subplot(2,3,4)
plot(t(1:1/Te),y(1:1/Te))


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Spectrul semnalului filtrat, obtinut in aceleasi conditii ca cel al
% semnalului original 
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
Y = fft(y);
L = length(y);
Yabs = abs(Y)/(L/2);
MagY = Yabs(1:L/2+1);
% Frecventa de esantionare
fe = 1/Te;
% Domeniul de valori ale frecventei pentru care reprezentam grafic spectrul
% seamnalului x
f = fe*[0:(L/2)]/L;
% Sa vedem cum arata spectrul de amplitudine, pe domeniul considerat
subplot(2,3,5)
plot(f, MagY)
