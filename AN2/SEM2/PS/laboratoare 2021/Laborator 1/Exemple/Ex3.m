% incarca valorile pentru timp si valorile inregistrate ale semnalului la aceste momente: 
% t si x; perioada de esantionare va fi egala cu diferenta dintre 2 valori consecutive din vectorul t
load Semnal1.mat
subplot(2,1,1)
plot(t,x)

% incarca valorile pentru perioada de esantionare si valorile inregistrate ale semnalului
load Semnal2.mat
% se obtin momentele de timp cunoscand perioada de esantionare
t = 0:Te:1;
subplot(2,1,2);
plot(t,x);
