%% ex 1

t=[0:0.1:10]
u=10*sin(2*t);
y=10/sqrt(5)*sin(2.*t-atan(2));
subplot(2,1,1);
plot(t,u)
hold on;
plot(t,y)

y2=10/sqrt((1-4/(1/51*10^(-5))) + 10/(51*10^(-5))*(10/(51*10^(-5))) ) * sin(2*t-atan( 20/(1/(51*10^(-5))) / (1- 4/(1/(51*10^(-5)))) ) )
%%nu este de corect
subplot(2,1,2);
plot(t,u)
hold on;
plot(t,y2)

% R=1000;
% C=10^(-4);
% L=1000;
% 
% %sistem de ordin 1
% 
% num_Gp1=[1];
% den_Gp1=[R*C 1];
% 
% subplot(2,1,1)
% bode(num_Gp1,den_Gp1)
% 
% %sistem de ordin 2
% 
% num_Gp2=[1/(L*C)];
% den_Gp2=[1 R/L 1/(L*C)];
% subplot(2,1,2)
% bode(num_Gp2,den_Gp2)
%% ex2

M=1;
B=2;
K=1;

num_Gp=[1];
den_Gp=[M B K];

%Primul regulator(P)
num_Gr1=[10];
den_Gr1=[1];
%calea directa
[num_Gcd1,den_Gcd1]=series(num_Gp,den_Gp,num_Gr1,den_Gr1);
%caracteristica Bode
% subplot(3,1,1)
% bode(num_Gcd1,den_Gcd1);
%mariginea de amplitudine,faza si pulsatia
[a,f,w]=bode(num_Gcd1,den_Gcd1)
%raspunsul sistemului
t=[0:0.1:30]
y=a.*sin(t.*w+f)
plot(t,y)

%Al doilea regulator(PI)
num_Gr2=[10 5];
den_Gr2=[1 0];
%calea directa
[num_Gcd2,den_Gcd2]=series(num_Gp,den_Gp,num_Gr2,den_Gr2);
%caracteristica Bode
% subplot(3,1,2)
% bode(num_Gcd2,den_Gcd2)

%Al treilea regukator(PID)
num_Gr3=[2 10 5];
den_Gr3=[0.01 1 0];
%cale directa
[num_Gcd3,den_Gcd3]=series(num_Gp,den_Gp,num_Gr3,den_Gr3);
%caracteristica Bode
% subplot(3,1,3);
% bode(num_Gcd3,den_Gcd3)

%Determinarea stabilitatii folosind caracteristicile Nyquist
% subplot(3,1,1)
% nyquist(num_Gcd1,den_Gcd1)
% subplot(3,1,2)
% nyquist(num_Gcd2,den_Gcd2)
% subplot(3,1,3)
% nyquist(num_Gcd3,den_Gcd3)

%Determinarea stabilitatii folosind marginea de faza si amplitudine
% subplot(3,1,1)
% bode(num_Gcd1,den_Gcd1)
% subplot(3,1,2)
% margin(num_Gcd2,den_Gcd2)
% subplot(3,1,3)
% margin(num_Gcd3,den_Gcd3)


%% ex 3

%kdb=40 =>lgk=2 =>k=100
%g=100/s+1

%% ex4

%sistem in circuit inchis
num_G0=[750];
den_G0=[1 36 205 750];

%polii sistemului in circuit inchis
r=roots(den_G0)

%reducerea ordinului sistemului in circuit inchis
num_G0_red=[750/30]
r=[r(2) r(3)]
den_G0_red=poly(r)
G0_red=tf(num_G0_red,den_G0_red)

%determinarea tuturor indicatorilor de calitate pe circuit inchis pt G0
[mag,phase,w]=bode(num_G0,den_G0);
[Mr,k]=max(mag);
wr=w(k)
n=1;
while(mag(n)>0.7)
    n=n+1;
end
largime_banda=w(n)
subplot(2,1,1)
bode(num_G0,den_G0)

%determinarea tuturor indicatorilor de calitate pe circuit inchis pt G0_red
[mag,phase,w]=bode(num_G0_red,den_G0_red);
[Mr,k]=max(mag);
Mr
wr=w(k);
n=1;
while(mag(n)>0.7)
    n=n+1;
end
largime_banda=w(n)
subplot(2,1,2)
bode(num_G0_red,den_G0_red)


%% ex 5
A=[-1 0;1 0];
B=[1;0];
C=[1 0];
D=[0];

%determinarea stabilitatii folosind caracteristicile Bode
subplot(3,1,1)
bode(A,B,C,D,1)

%determinarea stabilitatii folosind caracteristicile Nyquist
subplot(3,1,2)
nyquist(A,B,C,D)

%reprezentarea caracteristicilor amplitudine-pulsatie, faza-pulsatie
[a f w]=bode(A,B,C,D,1)
adb=20*log10(a)
subplot(3,1,3)
plot(w,adb,w,f);




