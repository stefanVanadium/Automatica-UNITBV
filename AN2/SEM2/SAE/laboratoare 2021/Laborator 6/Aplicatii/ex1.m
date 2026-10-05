%% Primul sistem

%functia de transfer a procesului
num_Gp=[1];
den_Gp=[1 1 0];

%perioada de esantionare
Te=0.1;

%discretizarea procesului
[num_Gcdz,den_Gcdz]=c2dm(num_Gp,den_Gp,Te,'zoh');

%caracteristica Nyquist
subplot(2,1,1);
dnyquist(num_Gcdz,den_Gcdz,Te)

%caracteristica Bode
subplot(2,1,2);
dbode(num_Gcdz,den_Gcdz,Te)
[mag phase w]=dbode(num_Gcdz,den_Gcdz,Te);

%indicatori de calitate 
%in cazul determinarii largimii de banda si varfului de rezonanta se
%foloseste circuitul inchis
[num_G0z,den_G0z]=feedback(num_Gcdz,den_Gcdz,1,1);
[mag phase w]=dbode(num_G0z,den_G0z,Te);
[Mr k]=max(mag)
n=1;
while(mag(n)>0.7)
    n=n+1;
end
largime_banda=w(n);

%% Al doilea sistem

%functia de traansfer a procesului
num_Gp=[9];
den_Gp=[1 7 0];

%perioada de esantionare
Te=0.1;

%discretizarea procesului
[num_Gcdz,den_Gcdz]=c2dm(num_Gp,den_Gp,Te,'zoh');

%caracteristica Nyquist
subplot(2,1,1);
dnyquist(num_Gcdz,den_Gcdz,Te)

%caracteristica Bode
subplot(2,1,2);
dbode(num_Gcdz,den_Gcdz,Te)

%indicatori de calitate
[num_G0z,den_G0z]=feedback(num_Gcdz,den_Gcdz,1,1);
[mag phase w]=dbode(num_G0z,den_G0z,Te)
[Mr k]=max(mag)
n=1;
while(mag(n)>0.7)
    n=n+1;
end
largime_banda=w(n)
