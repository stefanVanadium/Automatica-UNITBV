%% ex 1

R=10*10^3;
C=100*10^(-6);
L=1;

functie(R,C,L);


%% ex2

num_G1=[1];
den_G1=[1 2];
G1=tf(num_G1,den_G1);

num_G2=[1];
den_G2=[1 3];
G2=tf(num_G2,den_G2);

num_G3=[1 1];
den_G3=[1 6 0];
G3=tf(num_G3,den_G3);

num_H1=[7];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[5];
den_H2=[1];
H2=tf(num_H2,den_H2);

%modificare de topologie
H3=H2/G1;

G12=series(G1,G2);
Ge1=feedback(G12,H1);
Ge2=series(Ge1,G3);
Ge=feedback(Ge2,H3)

%% ex3

num_Gr=[19 20];
den_Gr=[1 0];
Gr=tf(num_Gr,den_Gr);

num_Gee=[1];
den_Gee=[1];
Gee=tf(num_Gee,den_Gee);

num_Gtr=[1];
den_Gtr=[1];
Gtr=tf(num_Gtr,den_Gtr);

num_Gp=[9];
den_Gp=[1 3 9];
Gp=tf(num_Gp,den_Gp);

%functia de transfer in circuit a caii directe
Ge1=series(Gr,Gee);
Ge2=series(Ge1,Gtr)

%functia de transfer a sistemului in circuit inchis
Ge=feedback(Ge2,Gp)

%a
subplot(4,1,1);
p=pzmap(Ge)

%b
subplot(4,1,2);
t=[0:0.1:10];
lsim(t,t,G2)

%c
subplot(4,1,3);
step(t,Ge)
%tc=0,1s 

%functia de transfer in circuit deschis
num_G0=conv([19,20],[1 3 9]);
den_G0=conv([1],[9]);
G0=tf(num_G0,den_G0);

% d errortf(G0)
p=pole(Ge);
num_G_mod=[19 77 231 180];
den_G_mod=conv([1 3 180 180],[1 0.5]);
G_mod=tf(num_G_mod,den_G_mod);
subplot(4,1,4);
step(G_mod)



