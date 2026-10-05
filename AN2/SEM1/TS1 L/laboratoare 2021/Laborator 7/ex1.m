
%% metoda 1
num_Gd=[120 120];
r=[-3,-4];
den_Gd=poly(r);
Gd=tf(num_Gd,den_Gd);

errortf(num_Gd,den_Gd)

%% metoda 2

num_Gd=[120 120];
r=[-3,-4];
den_Gd=poly(r);
Gd=tf(num_Gd,den_Gd);

%eroare la marimea treapta unitara
kp=dcgain(Gd);
ess1=1/(1+kp)

%eroare la marime rampa unitara
Gd1=tf(conv(num_Gd,[1 0]),den_Gd);
kv=dcgain(Gd1);
ess2=1/kv

%eroarea la marime parabola unitara
Gd2=tf(conv(num_Gd,[1 0 0]),den_Gd);
ka=dcgain(Gd2);
ess3=1/ka
