
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Semnalul original 
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Pasul de generare a semnalului 'continuu'
Tg = 0.0001;
% Perioada de generare este de 10 secunde
t = 0:Tg:10;
% Semnalul "continuu", format din 4 sinosoide (putem incerca diferite
% forme), de frecvente 10Hz, 20Hz, 80Hz, 90Hz
x = sin(2*pi*10*t) + sin(2*pi*20*t) + sin(2*pi*80*t) + sin(2*pi*90*t);
% Sa vedem cum arata semnalul 'inregistrat', pe un interval de 0.5 secunde
subplot(2,2,1)
plot(t(1:0.5/Tg),x(1:0.5/Tg))


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Spectrul semnalului original, cu perioada de generare Tg
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

X = fft(x);
L = length(x);
Xabs = abs(X)/(L/2);
MagX = Xabs(1:L/2+1);
fg = 1/Tg;
% Domeniul de valori ale frecventei
f = fg*[0:(L/2)]/L;
% Sa vedem cum arata spectrul de amplitudine, pe domeniul considerat
subplot(2,2,2)
plot(f(1:1000), MagX(1:1000))



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Inregistram semnalul
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Perioada de esantionare la inregistrare este diferita (mai mare)
% decat cea utilizata la generarea semnalului. Simulam esantionarea
% semnalului. Pune diferite valori pentru a vedea efectul.
Te = 0.001;
% Momentele de timp cand are loc esantionarea
te = t(1:Te/Tg:end);
% Esantioanele semnalului inregistrat
xe = x(1:Te/Tg:end);
% Sa vedem cum arata semnalul inregistrat, pe un interval de 0.5 secunde
subplot(2,2,3)
plot(te(1:0.5/Te),xe(1:0.5/Te))



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Spectrul semnalului inregistrat
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

XE = fft(xe);
L = length(xe);
XEabs = abs(XE)/(L/2);
MagXE = XEabs(1:L/2+1);
fe = 1/Te;
% Domeniul de valori ale frecventei
f = fe*[0:(L/2)]/L;
% Sa vedem cum arata spectrul de amplitudine, pe domeniul considerat
subplot(2,2,4)
plot(f(1:1/Te), MagXE(1:1/Te))