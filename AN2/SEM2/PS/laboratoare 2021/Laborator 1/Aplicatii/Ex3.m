load Laborator1_Semnal1.mat;
Te=0.001;
N = length(x);
fe = 1/Te;
X = fft(x);
Xabs = abs(X)/(N/2);
magX = Xabs(1,1:N/2+1);
f = [0:N/2]*fe/N;
subplot(2,1,1);
plot(f,magX)

xx = ifft(X);
subplot(2,1,2);
plot(t,xx)
