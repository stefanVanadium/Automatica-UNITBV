%sistem descris in saptiul starilor
A=[-1 0;1 0];
B=[1; 0];
C=[1 0];
D=0;

%discretizarea sistemului
[fi,gama,C_1,D_1]=c2dm(A,B,C,D,0.1,'zoh');    

%sistemul pe circuit deschis in variabila z
[numz,denz]=ss2tf(fi,gama,C_1,D_1);

%sistemul in circuit inchis in variabla z
[nz,dz]=feedback(numz,denz,1,1);

% spațiul starilor sistemului în circuit închis
[fi,gama,C_1,D_1]=tf2ss(nz,dz)
    
%det controlab si observab,det sunt diferiti de 0
P = ctrb(fi,gama)                      
Q = obsv(fi,C_1)

%reprezentarea rasp sist la intrarile treapta                 
dstep(fi,gama,C_1,D_1)


