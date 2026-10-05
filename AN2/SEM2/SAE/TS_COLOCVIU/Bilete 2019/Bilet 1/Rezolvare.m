%% ex2

%metoda 1
num_G1=[1];
den_G1=[1 3];

num_G2=[0.5];
den_G2=[1];

num_G3=[1];
den_G3=[1 2];

num_G4=[4];
den_G4=[1 4];

[num_Ge1 den_Ge1]=feedback(num_G2,den_G2,num_G3,den_G3);
[num_Ge2 den_Ge2]=series(num_G1,den_G1,num_Ge1,den_Ge1);
[num_Ge den_Ge]=series(num_Ge2,den_Ge2,num_G4,den_G4)

[A B C D]=tf2ss(num_Ge,den_Ge);

%metoda 2
n1=[1];
d1=[1 3];

n2=[0.5];
d2=[1];

n3=[1];
d3=[1 2];

n4=[4];
d4=[1 4];

nblocks=4;
blkbuild;

q=[1 0 0;2 1 3;3 2 0;4 2 0];

[A,B,C,D]=connect(a,b,c,d,q,1,4);

[num,den]=ss2tf(A,B,C,D,1)
G=tf(num,den)

%% ex3

A=[0 1; -25 -4];
B=[1 1;0 1];
C=[1 0;0 1];

%% ex4

%factorul de amplificare
k=[0:0.5:12];

%functia de transfer pe citcuit deschis
num_G=[1];
den_G=[1 1 0 0];

%trasarea locului radacinilor
rlocus(num_G,den_G,k)

%% ex5