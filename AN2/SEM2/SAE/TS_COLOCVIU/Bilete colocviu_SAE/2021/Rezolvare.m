%% ex2

num_Gr=[3 1];
den_Gr=[5 1];

[num_Grz den_Grz]=c2dm(num_Gr,den_Gr,0.1,'zoh');
nz= conv(num_Grz, [1 0]);
dz= conv(den_Grz, [1 -1]);

[fi gama C_1 D_1]=tf2ss(nz,dz)

%% ex3

num_G2=[1];
den_G2=[1 1];

num_H=[1 3];
den_H=[1 2];

[num_Gcd den_Gcd]=c2dm(num_G2,den_G2,0.1,'zoh');
Gcdz=tf(num_Gcd,den_Gcd,0.1);

[num_Gb den_Gb]=series(num_G2,den_G2,num_H,den_H);
[num_Gbz den_Gbz]=c2dm(num_Gb,den_Gb,0.1,'zoh');
Gbz=tf(num_Gb,den_Gb,0.1);

G0=Gcdz/(1+Gbz)


%% ex4

num_G=[9];
den_G=[1 6 0];

[num_Gz den_Gz]=c2dm(num_G,den_G,0.1,'zoh');
[num_G0z,den_G0z]=feedback(num_Gz,den_Gz,1,1)

[p z]=pzmap(num_G0z,den_G0z);
zplane(z,p)
 %sistem stabil;
 
 [fi gama C_1 D_1]=tf2ss(num_Gz,den_Gz);
 
 det(ctrb(fi,gama))
 %sistem controlabil

%% ex5

A=[-4 0;1 0];
B=[1;0];
C=[0 9];
D=[0];

[fi gama C_1 D_1]=c2dm(A,B,C,D,0.1,'zoh');
[num_Gz den_Gz]=ss2tf(fi,gama,C_1,D_1);
[num_G0z den_G0z]=feedback(num_Gz,den_Gz,1,1);

[mag,phase,w]=dbode(num_G0z,den_G0z,0.1);
[Mr,k]=max(mag);
varf_rezonanta= Mr
wr=w(k);
n=1;
while 20*log10(mag(n))>-3
%while (mag(n))>0.7
 n=n+1;
end
largime_banda=w(n)

dnyquist(num_Gz,den_Gz,0.1)
%sistem stabil