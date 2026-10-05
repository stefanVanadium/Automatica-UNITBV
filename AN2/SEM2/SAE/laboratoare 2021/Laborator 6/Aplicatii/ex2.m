%spatiul starilor
A=[-1 -0.5;1 0];
B=[0.5;0];
C=[1 0];
D=[0];

%discretizare spatiul starilor
[fi,gama,C_1,D_1]=c2dm(A,B,C,D,0.05,'zoh');

%studiul stabilitatii folosind indicatorii de calitate
 %nu se poate aplica criteriul Nquit]st pt ca avem sistem in circuit inchis
[mag phase w]=dbode(fi,gama,C_1,D_1,0.05)
[Mr k]=max(mag);
wr=w(k)
n=1;
while(mag(n)>0.7)
    n=n+1;
end
largime_banda=w(n)


