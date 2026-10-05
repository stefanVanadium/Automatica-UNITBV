%Generarea unui semnal armonic de frecvenţă 10Hz şi amplitudine 2, la o perioadă de eşantionare de 0.01.

%perioada de generare - similara cu perioada de esantionare
Te = 0.001;
%vectorul timpului - momentele de prelevare de semnal
t = 0:Te:1;
%frecventa semnalului
f = 10;
%pulsatia semnalului
w = 2*pi*f;
%amplitudinea semnalului
a = 2;
%semnalul generat / inregistrat in vectorul x
x = a*sin(w*t);
%prezentarea grafica a semnalului x
plot(t,x)

%exercitiul 2
save Semnal1.mat t x;
save Semnal2.mat Te x;

