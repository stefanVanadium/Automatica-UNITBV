[x,FS] = audioread('lab.wav');             % returneaza rata de transfer (FS) în Hertz
                                           % folositi pentru codarea datei în fisier
N = length(x);                             % lungimea transferului de semnal x	
t = (1:N)/FS;                              % scala timpului

%% Figura 1  -> Sub grafic superior

subplot(3,1,1)                             % sub grafic superior
plot(t,x)                                  % deseneaza semnalul de intrare
xlabel('Timp')                             % eticheta axei X
ylabel('Amplitudine')                      % eticheta axei Y
title('Semnal de intrare')                 % titlul figurii

%% -> Sub grafic central

X = fft(x,N) ;                             % calculeaza cele N puncte DFT ale 
                                           % semnalului x
m = 20*log10(abs(X));                      % amplitudinea în DB	
subplot(3,1,2)                             % sub grafic central 
w = (0:FS/N:(FS/2-FS/N));                  % intervalul de frecventa
plot(w,m(1:N/2))                           % desenarea frecventei	
xlabel('Frecventa(Hz)')	                   % eticheta axei x			
ylabel('Amplitudinea')		         	   % eticheta axei y
title('Spectrul amplitudinii de intrare')  % titlul figurii

%% -> Sub grafic inferior

subplot(3,1,3)                             % sub grafic inferior
specgram(x)                                % producerea spectogramei
colorbar;                                  % activarea barei de culori 

%% FIGURA 2 & 3 au fost create in Corel9 si sunt incluse
% 	in fisierul Word

%% FIGURA 4  "Raspunsul filtrului" (in impuls si frecventa)

freq = [0 0.010 0.015 0.02 0.08 0.10 0.17 0.18 0.19 0.20 1]; % vectorul frecventa
magn = [0 0 0.1 0.2 0.2 0.2 0.2 0.1 0 0 0];		     % vectorul amplitudine
a = fir2(1000,freq,magn);		       	             % filtrul fir2 de grad 1000

%% -> Sub grafic superior ("Raspunsul in impuls al filtrului")

[h,n] = impz(a,1);                         % calculeaza raspunsul în impuls  
subplot(3,1,1)                             % sub grafic superior
stem(n,h,'-')                              % secventa discreta
xlabel('n')                                % eticheta axa X
ylabel('h(n)')                             % eticheta axa Y
title('Raspunsul în impuls al filtrului')  % titlu figura

%% -> Sub grafic central ("Raspunsul in frecventa al filtrului")

[H,w] = freqz(a,1);                        % raspunsul în frecventa al filtrului numeric
subplot(3,1,2);                            % sub grafic central 
plot(w*FS/(2*pi),abs(H))                   % trasarea frecventei în radiani 
xlabel('Frecventa(H(z))')                  % eticheta axa X 
ylabel('Amplitudine')                      % eticheta axa Y
title('Raspunsul în frecventa al filtrului')% titlu figura

%% FIGURA 5

dan = filter(a,8,x);                        % filtrare fir2 de ordinul 8 al semnalului x

%% -> Sub grafic superior - Semnal de iesire 

figure				         
subplot(3,1,1)                              % sub grafic superior				                                                     
plot(t,dan)                                 % reprez. semnalul de iesire "dan" în domeniul timp 
xlabel('Timpi(s)')                          % eticheta axa X
ylabel('Amplitudine')		          	    % eticheta axa Y
title('Semnal de iesire')              	    % titlu figura

%% -> Sub grafic central

Y = fft(dan,N);                            % calculeaza DFT-ul de 8 puncte al lui "dan"
subplot(3,1,2)		                        % sub grafic central
k = 20*log10(abs(Y));                       % amplitudine în dB 
w = (0:FS/N:(FS/2-FS/N));                   % frecventa
plot(w,k(1:N/2))                            % reprezentarea semnalului "dan" în domeniul 
                                            % frecventei 
xlabel('Frecventa (Hz)')                    % eticheta axa X
ylabel('Amplitudine')                       % eticheta axa Y 
title('Spectrul amplitudinii de iesire')    % titlu figura

%% -> Sub grafic inferior

subplot(3,1,3)                              % sub grafic interior 
specgram(dan)                               % spectograma semnalului de iesire
colorbar                                    % validare colorbar

sound(500*dan,FS,8)			                % 8 biti pe esantion  