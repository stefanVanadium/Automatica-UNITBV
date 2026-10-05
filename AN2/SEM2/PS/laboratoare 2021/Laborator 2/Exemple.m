%% 1 Trasarea caracteristicii modul-pulsatie pt T2

% factorul de amplificare
k = 1;
%pulsatia naturala
wn = 10; 
%factorul de amortizare
z = 0.7 

%domeniul de frecventa pentru care se traseaza caracteristica
w=0:0.1:30; 

%functia de transfer a filtrului
num = [k*wn*wn];
den = [1 2*z*wn wn*wn];
Gw = bode(num,den,w);

%caracteristica modul-pulsatie = caracteristica Bode de amplitudine
plot(w,Gw)

%% 2 Trasarea caracteristicii modul-pulsatie a unui sistem cu 2 poli

%domeniul de frecventa pentru care se traseaza caracteristica
w=0:0.1:30;  

%zerourile (nu are)
z = [];
%polii impusi
p = [-7+j*5 -7-j*5]; 
%amplificarea egala cu produsul polilor pentru a indeplini
%conditia ca in 0 sa avem castig unitar – filtru trece-jos
k = prod(p); 

%obtinerea functiei de transfer a sistemului cu polii alesi
[num, den] = zp2tf(z,p,k);
Gw = bode(num,den,w);

%caracteristica modul-pulsatie = caracteristica Bode de amplitudine
plot(w,Gw);

%% Trasarea caracteristicii modul-pulsatie a unui sistem la care s-au intodus poli

%domeniul de frecventa pentru care se traseaza caracteristica
w=0:0.1:30;  

%zerourile (nu are)
z = [];
%polii impusi
p = [-7+j*5 -7-j*5 -5-j*10 -5+j*10]; 

%amplificarea egala cu produsul polilor pentru a indeplini
%conditia ca in 0 sa avem castig unitar – filtru trece-jos
k = prod(p); 

%obtinerea functiei de transfer a sistemului cu polii alesi
[num, den] = zp2tf(z,p,k);
Gw = bode(num,den,w);

%caracteristica modul-pulsatie = caracteristica Bode de amplitudine
plot(w,Gw);

%% Introducerea zeroului z=-5/z=-5+-j*20 in fc de transfer a T2

%domeniul de frecventa pentru care se traseaza caracteristica
w=0:0.1:30;  

wn=10;
zita=0.7;

%functia de transfer
num=[wn*wn];
den=[1 2*zita*wn wn*wn];
G=bode(num,den,w);

subplot(3,1,1);
plot(w,G)

num_mod=[wn*wn 5*wn*wn];
den_mod=[5 10*zita*wn 5*wn*wn];
G_mod=bode(num_mod,den_mod,w);

subplot(3,1,2)
plot(w,G_mod);

num_mod1=[wn*wn 10*wn*wn 425*wn*wn];
den_mod1=[425 425*2*zita*wn 425*wn*wn];
G_mod1=bode(num_mod1,den_mod1,w);

subplot(3,1,3);
plot(w,G_mod1)

%% 6
k1=0.2;
k2=0.5;
%domeniul de frecventa pentru care se traseaza caracteristica
w=0:0.1:30;  

num_G1=[k1 k1*10 k1*250];
den_G1=[1 10 50];
G1=bode(num_G1,den_G1,w);
plot(w,G1)

hold;

num_G2=[k2 k2*10 k2*50];
den_G2=[1 10 250];
G2=bode(num_G2,den_G2,w);
plot(w,G2)
