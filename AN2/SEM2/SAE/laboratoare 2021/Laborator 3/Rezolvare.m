%% ex1

%functia de transfer de pe calea directa in variabila s
num_Gcd=1;
den_Gcd=[1 1];

%functia de transfer  de pe calea directa in variabila z
[num_Gcdz,den_Gcdz]=c2dm(num_Gcd,den_Gcd,0.1,'zoh');

%functia de transfer pe circuit inchis in variabila z
[num_Gz,den_Gz]=feedback(num_Gcdz,den_Gcdz,1,1);

num_Gz_rampa=num_Gz*0.1;
den_Gz_rampa=conv(den_Gz,[1 -1]);
Gz_rampa=tf(num_Gz,den_Gz,0.1)

t=[0:1:30];

%raspusnul sistemului la rampa unitara
subplot(2,1,1);
dlsim(num_Gz_rampa,den_Gz_rampa,t)

%raspusnul sistemului la rampa unitara
subplot(2,1,2);
dstep(num_Gz,den_Gz,t)

%% ex2

%functia de tranfer de pe calea directa in variabila s
num_Gcd=[1];
den_Gcd=[1 1 0];

%functia de tranfer de pe calea directa in variabila z
[num_Gcdz,den_Gcdz]=c2dm(num_Gcd,den_Gcd,0.3,'zoh');

%functia de tranfer echivalenta in variabila z
[num_G0z,den_G0z]=feedback(num_Gcdz,den_Gcdz,1,1);

%functia de transfer pentru intrare rampa
num_G0z_rampa=num_G0z*0.3;
den_G0z_rampa=conv(num_G0z,[1 -1]);

t=[0:1:30];

%raspusnul sistemului la treapta unitara
subplot(3,1,1)
dstep(num_G0z,den_G0z,t)
%raspusnul sistemului la rampa unitara
subplot(3,1,2)
dlsim(num_G0z_rampa,den_G0z_rampa,t)
%raspusnul sistemului la impuls unitar
subplot(3,1,3)
dimpulse(num_G0z,den_G0z,t)

%% ex 3

%functia de transfer in circuit deschis pt sistem continuu
num_G=[9];
den_G=[1 7 0];

%functia de transfer in circuit inchis pt sistem continuu
[num_G0,den_G0]=feedback(num_G,den_G,1,1);

%raspunsul sistemului continuu pt treapta unitara
t=[0:1:30];
subplot(5,1,1)
step(num_G0,den_G0,t)

%functia de transfer echivalenta pt sistem discret - zoh si raspunsul
[num_Gz,den_Gz]=c2dm(num_G,den_G,0.1,'zoh');
[num_G0z,den_G0z]=feedback(num_Gz,den_Gz,1,1);

subplot(5,1,2)
dstep(num_G0z,den_G0z,t)

%functia de transfer echivalenta pt sistem discret - foh si raspunsul
[num_Gz2,den_Gz2]=c2dm(num_G,den_G,0.1,'foh');
[num_G0z2,den_G0z2]=feedback(num_Gz2,den_Gz2,1,1);

subplot(5,1,3)
dstep(num_G0z2,den_G0z2,t)

%functia de transfer echivalenta pt sistem discret - tustin si raspunsul
[num_Gz3,den_Gz3]=c2dm(num_G,den_G,0.1,'tustin');
[num_G0z3,den_G0z3]=feedback(num_Gz3,den_Gz3,1,1);


subplot(5,1,4)
dstep(num_G0z3,den_G0z3,t)

%functia de transfer echivalenta pt sisemt discret - matched si raspunsul
[num_Gz4,den_Gz4]=c2dm(num_G,den_G,0.1,'matched');
[num_G0z4,den_G0z4]=feedback(num_Gz4,den_Gz4,1,1);

subplot(5,1,5)
dstep(num_G0z4,den_G0z4,t)

%% ex4

for k=5:20
    
num_Gr=[k 20*k];
den_Gr=[1 1];
Gr=tf(num_Gr,den_Gr);

num_Gp=1;
den_Gp=[1 30 200 0];
Gp=tf(num_Gp,den_Gp);

[num_G,den_G]=series(num_Gp,den_Gp,num_Gr,den_Gr)

[num_Gz,den_Gz]=c2dm(num_G,den_G,0.1,'zoh');

[num_G0z,den_G0z]=feedback(num_Gz,den_Gz,1,1)

t=[0:100];
dstep(num_G0z,den_G0z,t)

hold on

end