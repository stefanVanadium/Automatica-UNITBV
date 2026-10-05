load Laborator3_Semnal

Te=0.001;
t=0:Te:3;

N=length(x);
fe=1/Te;
X=fft(x);
Xabs=abs(x)/(N);
MagX=Xabs(1,1:N/2+1);
f=[0:N/2]*fe/N;

subplot(2,1,1)
stem(MagX);

wp=10;
Gp=0.794;
ws=20;
Gs=0.1;

GsdB=20*log10(Gs);
GpdB=20*log10(Gp);

[N1,wn1]=buttord(wp,ws,GpdB,GsdB,'s');

Y=filter(wn1,N1,x);
t=0:Te:3;

plot(t,Y);

N2=length(Y);
fe=1/Te;

X2=fft(Y);
X2abs=abs(X2)/(N2/2);
MagX2=X2abs(1,1:N2/2+1);
f2=[0:N2/2]*fe/N2;

subplot(2,1,2)
stem(MagX2)