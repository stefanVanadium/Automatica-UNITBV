% sa se genereze un semnal format din 2 armonici si sa se salveze datele
% intr-un fisier

Te = 0.001;
%perioada de generare - similara cu perioada de esantionare
t = [0: Te: 3];
%vectorul timpului - momentele de prelevare de semnal
f1 = 25; f2 = 14;
%frecventa semnalului
w1 = 2 * pi * f1;
w2 = 2 * pi * f2;
%pulsatia semnalului
a1 = 2; a2 = 3;
%amplitudinea semnalului
x = a1*sin(w1*t) + a2*sin(w2*t);
%semnalul generat / inregistrat in vectorul x
plot(t,x)
%prezentarea

% salvarea in fisier
save ex1.mat t x;