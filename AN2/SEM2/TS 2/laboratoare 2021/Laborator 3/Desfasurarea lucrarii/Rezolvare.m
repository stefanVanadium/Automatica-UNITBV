%% Proces de ordin 1

R=10000;
C=10^(-4);

%functia de transfer a procesului
num=[1];
den=[R*C 1];

%modelul la stare al procesului
[A,B,C,D]=tf2ss(num,den)

%raspunsul procesului la o marime de intrarea treapta unitara
t=[0:0.1:10]
step(A,B,C,D,1,t)

%% Proces de ordinul 2

R=10000;
C=10^(-4);
L=1000;

%modelul la stare al procesului
A=[-R/L -1/L;1 0];
B=[1;0];
C=[0 1/(L*C)]
D=0;

%obtinerea functiei de transfer a procesului
[num,den]=ss2tf(A,B,C,D,1)
G=tf(num,den)

%raspunsul sistemului la o marime de intrare treapta unitara
t=[0:0.1:5];
step(t,G)