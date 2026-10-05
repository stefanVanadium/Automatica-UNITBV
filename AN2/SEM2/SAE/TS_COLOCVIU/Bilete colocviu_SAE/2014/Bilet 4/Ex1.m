 Te = 0.3;
 
 num1 = [0 0 1];
 den1 = [1 1 0];
 
 num2 = [0 0 2];
 den2 = [1 4 0];
 
 num3 = [0 1];
 den3 = [1 -1];
 
 G3 = tf(num3,den3);
 
 [numz1,denz1] = c2dm(num1,den1,Te,'zoh');
 [numz2,denz2] = c2dm(num2,den2,Te,'zoh');
 
 G1 = tf(numz1,denz1,Te);
 G2 = tf(numz2,denz2,Te);
 
 G0z = G1*G2