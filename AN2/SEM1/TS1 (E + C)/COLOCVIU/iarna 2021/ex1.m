s=tf('s');
G3=1/(s+4);
G4=(s+1)/(s+6);

num_H1=[3];
den_H1=[1];
H1=tf(num_H1,den_H1);

num_H2=[5];
den_H2=[1];
H2=tf(num_H2,den_H2);

%modificare topologie
H3=H1/G4;

Ge1=feedback(G4,H2);
Ge2=series(G3,Ge1);
Ge=feedback(Ge2,H1)
