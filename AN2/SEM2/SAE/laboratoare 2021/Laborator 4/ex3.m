%sistemul in circuit inchis reprezentat in spatiul starilor
fi=[0 -0.25;1 1];
gama=[1;1];
C=[0 1];
D=[0];

%conditii initiale
x0=[1; 1];

%marimea de intrare treapta unitara
t=[0:0.1:5]
u=ones(1,length(t))

%raspusnul sistemului la intrare treapta folosond dlsim
dlsim(fi,gama,C,D,u,x0)




