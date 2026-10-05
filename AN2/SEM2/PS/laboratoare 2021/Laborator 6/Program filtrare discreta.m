%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Semnalul original inregistrat
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Perioada de esantionare la inregistrare
Te = 0.001;
% Semnalul este inregistrat timp de 100 de secunde
t = 0:Te:100;
% Semnalul "continuu", format din 4 sinosoide (putem incerca diferite
% forme), de frecvente 10Hz, 20Hz, 80Hz, 90Hz
x = sin(2*pi*10*t) + sin(2*pi*20*t) + sin(2*pi*80*t) + sin(2*pi*90*t);
% Sa vedem cum arata semnalul 'inregistrat', pe un interval de o secunda
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
% Proiectarea unui filtru trece jos discret (Butterworth)
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
GpdB = 20*log10(Gp);
GsdB = 20*log10(Gs);
% Frecventele se normalizeaza cu frecventa Nyquist (care este
% jumatate din frecventa de esantionare
fNyquist = fe/2;
fpN = fp / fNyquist;
fsN = fs / fNyquist;

% Determinarea ordinului si frecentei de frangere a filtrului Butterworth
% analogic
[N,fc] = buttord(fpN,fsN,GpdB,GsdB);
% Determinarea numaratorului si numitorului functiei de transfer a
% filtrului Butterworth trece-jos analogic
[num,den] = butter(N,fc);



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Caracteristica modul-pulsatie a filtrului obtinut
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Domeniul de frecventa pentru care trasam caracteristica (frecventele sunt
% normalizate) 
f = 0:0.01:1;
% Pentru obtinerea caracteristicii, folosim functia dbode (bode pentru
% sisteme discrete)
[mag,phase,w] = dbode(num,den,Te);
% Si sa vedem cum arata (atentie dbode returneaza pulsatie, noi trasam in
% frecventa) 
subplot(2,3,3)
plot(w/(2*pi),mag,[fp fs],[Gp Gs],'o');grid



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Filtrarea semnalului inregistrat
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Semnalul filtrat cu filtrul discret proiectat se obtine cu functia filter.
filtru_analogic = tf(num,den);
% Filtrarea (simularea filtrarii analogice) se face pentru tot domeniul de
% generare a semnalului original
y = filter(num,den,x);
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
