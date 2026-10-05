t=0:0.02:4;
mv=0.4;
tv=0.8;
%zita = factor de amortizare
zita = abs(log(mv))/sqrt(pi^2+log(mv)^2);
w = pi / (tv*sqrt(1-zita^2));
d = w^2;
e=(2*zita*w-1)/d;
numg=[0 0 d];
deng=[1 1 0];

numh=[0 e 1];
denh=[0 0 1];

%fct de trasnfer inchisa (-1=semn feedback negativ)

[numz,denz]=feedback(numg,deng,numh,denh,-1);
step(numz,denz,t);