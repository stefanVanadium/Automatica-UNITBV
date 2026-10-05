%% ex 1

%perioada de esantionare
Te=0.1;

%functia de transfer G2 in variabila s
num_G2=[1];
den_G2=[1 1];

%functia de transfer de pe calea directa in variabila z
[num_Gcdz,den_Gcdz]=c2dm(num_G2,den_G2,Te,'zoh');
Gcdz=tf(num_Gcdz,den_Gcdz,Te);

%functia de transfer echivalenta
[num_Ge,den_Ge]=feedback(num_Gcdz,den_Gcdz,1,1);
Ge=tf(num_Ge,den_Ge,Te)

%simulare raspuns la treapta
t=[0:1:30]
subplot(2,1,1)
dstep(Ge,t)

%simulare raspuns la rampa
 %raspunsul la rampa unitara reprezinta raspunsul la treapta unitara integrat
subplot(2,1,2)
num_Ge_rampa=num_Ge*0.1;
den_Ge_rampa=conv(den_Ge,[1 -1]);
dlsim(num_Ge_rampa,den_Ge_rampa,t)

%% ex 2

%perioada de esantionare
Te=0.1;

%functia de transfer G2 in variabila s
num_G2=[1];
den_G2=[1 1];

%functia de transfer H in variabila s
num_H=[1 0];
den_H=[1 2];

%functia de transfer H in variabila z
[num_Hz,den_Hz]=c2dm(num_H,den_H,Te,'zoh');

%functia de transfer de pe calea directa in variabila z
[num_Gcdz,den_Gcdz]=c2dm(num_G2,den_G2,Te,'zoh');
Gcdz=tf(num_Gcdz,den_Gcdz,Te);

%functia de transfer a buclei/pe crcuit deschis in variabila 
[num_Gz,den_Gz]=series(num_Gcdz,den_Gcdz,num_Hz,den_Hz);
Gz=tf(num_Gz,den_Gz,Te);

%functia de transfer echivalenta a sistemului in variabila z
Gez=Gcdz/(1+Gz)

