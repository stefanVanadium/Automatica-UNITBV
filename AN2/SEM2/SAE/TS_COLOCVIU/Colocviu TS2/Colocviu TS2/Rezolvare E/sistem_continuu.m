function[sys,x0,str,Te]=sistem_continuu(t,x,u,flag,A,B,C)
%Daca flag=1 returneaza derivatele
if flag==1
 sys=A*x+B*u;
%Daca flag=3 returneaza iesirile
elseif flag==3
    sys=C*x;
%Daca flag=0 iniţializări
 % sys(1)- nr starilor continue;
 % sys(2)- nr starilor discrete;
 % sys(3)- nr iesirilor;
 % sys(4)- nr intrarilor;
 % sys(5)- alocat pentru găsirea rădăcinilor;
 % sys(6)- flagul de acces direct al mărimii de
 %intrare;
 % sys(7)- numărul momentelor de eşantionare.
elseif flag==0
 sys=[2,0,1,1,0,1,0];
 x0=0;str=[]; Te=[];
%In alte conditii nu returneaza nimic
else 
    sys=[];
end