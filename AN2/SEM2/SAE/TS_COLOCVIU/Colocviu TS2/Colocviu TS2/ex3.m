num=[1];
den=[1 4 0 0];
rlocus(num, den);
[a,f,w]=bode(num,den);
[mag,phase,w]=bode(num,den);
[Mr,k]=max(mag);
wr=w(k);
n=1;
while 20*log10(mag(n))>-3
%while (mag(n))>0.7
 n=n+1;
end
largime_banda=w(n);
