
num = [50]
den = [1 7 25]
Te = 1/50

%Metoda ZOH

[numz,denz] = c2dm(num,den,Te,'zoh')
Gz = tf(numz,denz,Te)

%Metoda FOH

[numz,denz] = c2dm(num,den,Te,'foh')
Gz = tf(numz,denz,Te)

%Metoda Tustin

[numz,denz] = c2dm(num,den,Te,'tustin')
Gz = tf(numz,denz,Te)

%Metoda Matched

[numz,denz] = c2dm(num,den,Te,'matched')
Gz = tf(numz,denz,Te)

%Poli și zerouri în planul z

zplane(numz,denz)