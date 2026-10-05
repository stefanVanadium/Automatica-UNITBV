%% ex 1

%modelul la stare al sistemului in circuit inchis
A=[-1 -0.5; 1 0];
B=[0.5; 0];
C=[1 0];
D=[0];

%functia de transfer a sistemului
[num den]=ss2tf(A,B,C,D)

%matricea fundamentala
O=inv(eye(2,2)-A)

%matricea de tranzitie a starilor
inv(O) %expm(???)

%raspunsul sistemului la o  marime de intrare treapta unitara
t=[0:0.05:10]
subplot(2,1,1);
step(A,B,C,D,1,t)

%raspunsul sistemului la o  marime de intrare impuls unitar
subplot(2,1,2)
impulse(A,B,C,D,1,t)

%% ex2

%modelul la stare al sistemului in circuit inchis
A=[0 1 0; 0 0  1; -6 -11 -6];
B=[1;1;1]
C=[1 1 0];
D=[0];

%conditii initiale
x0=[1;0.5;-0.5];

%simulare raspuns la o marime de intrare treapta
t=[0:0.05:4];
u1=ones(1,length(t))
subplot(2,1,1);
lsim(A,B,C,D,u1,t,x0)

%simulare raspuns la o marime de intrare sinusoidala
u2=sin(2*pi*t);
subplot(2,1,2);
lsim(A,B,C,D,u2,t,x0)

%% ex 3

%blocurile din schema
n1=[0.5]
d1=[1];

n2=[4];
d2=[1 4];

n3=[1];
d3=[1 2];

n4=[1];
d4=[1 3];

n5=[2];
d5=[1];

n6=[5];
d6=[1];

n7=[1];
d7=[1];

%numarul total de blocuri
nblocks=7;
blkbuild

%primul element al fiecrarei linii este numarul blocului
%celelalte elemente reprezinta intrarile in blocul respectiv
q=[1 -5 -6 -7;2 1 0 0;3 2 0 0; 4 3 0 0 ;5 2 0 0; 6 3 0 0 ;7 4 0 0];

%functia de transfer echivalenta in spatiul starilor
%1 si 4 reprezinta blocurile de intrare si iesire
[A,B,C,D]=connect(a,b,c,d,q,1,4);

%functia de transfer echivalenta in variabila s
[num,den]=ss2tf(A,B,C,D,1)
G=tf(num,den)

%% ex 4

%Procesul de ordin 1
R=1000;
C=10^(-4);
L=100;

A=[-R*C];
B=[R*C];
C=[1];
D=[0];

%controlabilitatea
ctrb(A,B)
 %cobtrolabil pentru ca detreminantu difera de zero

%observabilitatea
obsv(A,C)
 %observabil pt ca det difera de zero 

%Procesul de ordin 2
A=[-R/L -1/(L*C);1 0];
B=[1;0];
C=[0 1/(L*C)];
D=[0];

%controlabilitatea
det(ctrb(A,B))
 %cobtrolabil pentru ca detreminantu difera de zero

%observabilitatea
det(obsv(A,C))
 %observabil pt ca det difera de zero 


