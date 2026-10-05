function [sys,x0,str,Te] = sistem_discret(t,x,u,flag,fi,gama,C)
%Daca flag=2 returneaza derivatele
if flag==2
 sys=fi*x+gama*u;
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
 sys=[0,3,1,1,0,0,1];
 x0=[1;1;0];str=[];
 Te=[0.1 0];
%In alte conditii nu returneaza nimic
else sys=[];
end



