%% ex1

%factorul de amplificare
k=2;
%pulsatia naturala
wn=5;
%factorul de amortizare
zita=0.7;

%functia de transfer in circuit inchis al unui sistem de ordinul 2 in
num_G=[k*wn*wn];
den_G=[1 2*zita*wn wn*wn];
G=tf(num_G,den_G);

%functia de transfer in variabila z
  [num_Gz,den_Gz]=c2dm(num_G,den_G,0.02,'zoh');
% [num_Gz,den_Gz]=c2dm(num_G,den_G,0.02,'foh')
% [num_Gz,den_Gz]=c2dm(num_G,den_G,0.02,'tustin') - eroare
% [num_Gz,den_Gz]=c2dm(num_G,den_G,0.02,'prewarp')
% [num_Gz,den_Gz]=c2dm(num_G,den_G,0.02,'matched')

%metoda 1 - afisare
printsys(num_Gz,den_Gz,'z')

%metoda2 - afisare
Gz=tf(num_Gz,den_Gz,0.02)

%studiul stabilitatii
[p,z]=pzmap(num_Gz,den_Gz);
zplane(z,p) 
 %polii se afla in interiorul cercului de raza unitara => sistem stabil

%% ex 2

%factorul de amplificare
K=1;
%perioada de esantionare
Te=0.3

%functia de transfer a procesului in variabila de stare
num_Gp=[K];
den_Gp=[1 1 0];

%functia de transfer a procesului in variabila z
[num_Gpz,den_Gpz]=c2dm(num_Gp,den_Gp,Te,'zoh')

%functia de transfer echivalenta in variabila z
[num_Gez,den_Gez]=feedback(num_Gpz,den_Gpz,1,1);
Gez=tf(num_Gez,den_Gez,Te)

%studierea stabilitatii sistemului
[p,z]=pzmap(Gez);
zplane(z,p)
 %polii se afla in interiorul cercului de raza unitara => sistem stabil

%% ex3

% Nu avem un CNA => facem un artificiu de calcul: s*G(s) <=> G(z)*z/(z-1)

%functia de transfer sG(s)
num_Gs=[1 0];
den_Gs=[1 1 0];

%functia de transfer sG(s) in variabila z
[num_Gz, den_Gz]=c2dm(num_Gs, den_Gs,0.3,'zoh')

%functia de transfer z a caii directe
[num_Ge1,den_Ge1]=series(num_Gz,den_Gz,[1,0],[1 -1]);
Gcdz=tf(num_Ge1,den_Ge1,0.3)

%functia de transfer z echivalenta
[n,d]=feedback(num_Ge1,den_Ge1,1,1);
G0z=tf(n,d,0.3)

% studiul stabilitatii
pzmap(G0z)
 %polii se afla in interiorul cercului de raza unitara => sistem stabil
%% ex 4

%functia de tranfer G1 in variabila s
num_G1=[10];
den_G1=[1 10 0];

%functia de tranfer G1 in variabila z
[num_G1z,den_G1z]=c2dm(num_G1,den_G1,1,'zoh');
G1z=tf(num_G1z,den_G1z,1)

% G1 si G2 sunt legate in serie prin esantionor intercala, dar G2 nu are un
% ER0 => facem un artificiu de calcul: sG2(s) <=> G2(z)*z/(z-1)

%functia de tranfer sG2 in variabila s
num_G2=[1 0];
den_G2=[1 2];

%functia de tranfer sG2 in variabila z
[num_G2z,den_G2z]=c2dm(num_G2,den_G2,1,'zoh');
[num_G2z,den_G2z]=series(num_G2z,den_G2z,[1 0],[1 -1])
G2z=tf(num_G2z,den_G2z,1)

%functia de transfer echivalenta
Ge=series(G1z,G2z)

%% ex 5

%perioada de esantionare
Te=0.1;

%OBS: G1 reprezinta elementul de retinere de ordin 0, adica un CNA

%functia de transfer G2(s) 
num_G2=[1];
den_G2=[1 1];

%functia de transfer de pe calea directa in variabila z
[num_Gcdz,den_Gcdz]=c2dm(num_G2,den_G2,Te,'zoh');
Gcdz=tf(num_Gcdz,den_Gcdz,Te)

%functia de tranfer de pe calea de reactie in variabila s
num_H=[1 0];
den_H=[1 2];

%functia de transfer pe circuit deschis/buclei in variabila s
[num_Gb,den_Gb]=series(num_G2,den_G2,num_H,den_H);

%functia de transfer pe circuit deschis/buclei in variabila z
[num_Gbz,den_Gbz]=c2dm(num_Gb,den_Gb,Te,'zoh');
Gbz=tf(num_Gbz,den_Gbz,Te)

%functia de transfer pe circuit inchis
 G0=Gcdz/(1+Gbz)

 





