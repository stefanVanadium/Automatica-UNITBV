%Sa se reprezinte răspunsul la intrarea treaptă pentru sistemul din figură 
% ( t = [0:10], cu pasul 0.1):
t=0:0.1:10;
num1=[0 6];
num2=[0 4];
den1=[1 2];
den2=[1 1];
[num,den]=parralel(num1,den1,num2,den2);
tf(num,den);
step(num,den,t);