%generare de 5 sinusoide de frecvente diferite
Te=0.01;
t = [0:Te:3];
x1 = sin(2*pi*3*t)+sin(2*pi*4*t)+sin(2*pi*5*t)+sin(2*pi*6*t)+sin(2*pi*7*t);
subplot(2,1,1);
plot(t,x1);
%semnal de forma tren de impulsuri dreptunghiulare de frecventa 30HZ
x2 = square(2*pi*30*t);
subplot(2,1,2);
plot(t, x2);
%salvarea datelor
 save Semnal_impulsuri_dreptunghiulare.mat t x2 Te
