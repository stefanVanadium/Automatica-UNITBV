%% ex1 Studierea efectului ntroducerii unui zero asupra T2

%domeniul de frecventa pentru care se traseaza caracteristica
w=0:0.1:30;  

wn=10;
zita=0.7;

%functia de transfer
num=[wn*wn];
den=[1 2*zita*wn wn*wn];
Gw=bode(num,den,w);

%caracteristica modul-pulsatie = caracteristica Bode de amplitudine
plot(w,Gw)

hold;

%functia de transfer modificata
num_mod=[wn*wn 2];
den_mod=[2 2*zita*wn 2*wn*wn];
Gw_mod=bode(num_mod,den_mod,w)

plot(w,Gw_mod)

%% ex 2 Studierea efectului introducerii unor perechi de zerouri asupra caracteristicii unui element cu polii -5+-j

w = [0: 0.1: 30];

z = [];
p = [-5+10*j -5-10*j];
k = prod(p);
[num, den] = zp2tf(z, p, k);
Gw = bode(num, den, w);

subplot(2,1,1);
plot(w, Gw);

z = [-2+j; -2-j];
[num, den] = zp2tf(z, p, k);
Gw = bode(num, den, w);
subplot(2,1,2)
plot(w, Gw);

%% ex 3

w = [0: 0.1: 30];

p = [-5+10*j; -5-10*j];
z = [-2+j ;-2-j];
k = prod(p);
[num, den] = zp2tf(z, p, k);
Gw = bode(num, den, w);

plot(w, Gw)

hold;

p = [-2+j -2-j];
z = [-5+10*j; -5-10*j];
k = prod(p);
[num, den] = zp2tf(z, p, k);
Gw = bode(num, den, w);

plot(w, Gw)

%% ex4

wp = 5;
w = [0: 0.1: 20];

num = [0 0.11];
den = [0.07 0.1];

 g = bode(num, den, w);
plot(w, g,[5 15],[0.9 0.1] , 'o')


