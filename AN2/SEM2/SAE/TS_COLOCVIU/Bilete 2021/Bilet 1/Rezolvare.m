%% ex3

num_Gcd=[1];
den_Gcd=[1 6];

num_Gcr=[1];
den_Gcr=[1 0];

[num_G den_G]=series(num_Gcd,den_Gcd,num_Gcr,den_Gcr);

rlocus(num_G,den_G)

[k poli]=rlocfind(num_G,den_G);
 
k=1
[num_G0,den_G0]=feedback(num_G,den_G,1,1)
[mag,phase,w]=bode(num_G0,den_G0);
[Mr,k]=max(mag);
Mr
wr=w(k);
n=1;
while(mag(n)>0.7)
    n=n+1;
end
largime_banda=w(n)

%% ex4

num_Gcd=[9];
den_Gcd=[1 7 0];

[A,B,C,D]=tf2ss(num_Gcd,den_Gcd)

nyquist(num_Gcd,den_Gcd)

%% ex6

n1=[0.5];
d1=[1];

n2=[4];
d2=[1 4];

n3=[3];
d3=[1 3];;

n4=[1];
d4=[1 2];

nblocks=4;
blkbuild;

q=[1 0 0;2 -4 1; 3 2 0;4 2 0];

[A B C D]=connect(a,b,c,d,q,1,3)

%% ex5

num_G=[10];
den_G=[1 10 0];

%CONSTANTA DE TIMP:10;
%KDB=0 => K=1;

[a f w]=bode(num_G,den_G);

t=[0:0.1:10];
y=a.*sin(w*t+f);
plot(y)