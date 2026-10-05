Te = 0.001;
t = 0:Te:3;

%generarea unui semnal
x = 2*sin(2*pi*5*t)+3*sin(2*pi*10*t)+1*sin(2*pi*15*t);
%determinarea spectrului Fouriei
N = length(x);
fe = 1/Te;
X = fft(x);
Xabs = abs(X)/(N/2);
magX = Xabs(1,1:N/2+1);
f = [0:N/2]*fe/N;
subplot(2,1,1);
plot(f,magX)
%reconstructia semnalului in domeniul timpului folosind soctrul Fourie
xx = ifft(X);
subplot(2,1,2);
% plot(t,xx)
stem(t,xx)