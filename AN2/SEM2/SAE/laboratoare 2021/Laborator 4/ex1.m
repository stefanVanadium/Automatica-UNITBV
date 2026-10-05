%sistemul descris in spatiul starilor
A=[-1 0;1 0];
B=[1;0];
C=[0 1];
D=0;

%discretizarea sistemului reprezentat in spatiul starilor
[fi,gama,C_1,D_1]=c2dm(A,B,C,D,0.1,'zoh')

%sistemul discretizat in variabila z
[numz,denz]=ss2tf(fi,gama,C_1,D_1);

%sistemul in circuit inchis
[nz,dz]=feedback(numz, denz,1,1);

% spațiul starilor sistemului în circuit închis
[fi,gama,C_1,D_1]=tf2ss(nz,dz)

t=[1:0.1:10];

%raspunsul sistemului la o marime treapta
subplot(3,1,1)
dstep(fi,gama,C_1,D_1);

%raspunsul sistemului la o marime ramoa
subplot(3,1,2)
dlsim(fi,gama,C_1,D_1,t);

%raspunsul sistemului la o marime impuls
subplot(3,1,3)
dimpulse(fi,gama,C_1,D_1);