tv=0.8;
Mv=0.4;
zita=abs(log(Mv))/(sqrt(pi*pi+log(Mv)*log(Mv)));
pulsatia=pi/(tv*sqrt(1-zita*zita));

d=pulsatia*pulsatia;
e=(2*zita*pulsatia-1)/d;

num_G1=[d];
den_G1=[1 1 0];
G1=tf(num_G1,den_G1)

num_G2=[e 1];
den_G2=[1];
G2=tf(num_G2,den_G2)

%functia de transfer a sistemului
G=feedback(G1,G2)

%raspunsul sistemului la o marime treapta
t=[0:0.01:4];
subplot(2,1,1)
step(t,G)

%micsorare suprareglaj
p=pole(G)
num_G_mod=[16.73];
den_G_mod=conv([1 2.291 16.73],[1 1]);
G_mod=tf(num_G_mod,den_G_mod)

t=[0:0.01:4];
subplot(2,1,2)
step(t,G_mod)
 