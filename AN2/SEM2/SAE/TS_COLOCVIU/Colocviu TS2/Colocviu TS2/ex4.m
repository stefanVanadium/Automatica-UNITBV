n=[9];
d=[1 3 0];

[ampl,faza,w]=bode(n,d);
g=freqs(n,d,w);
plot(log10(w),20log10(g))

%plot(log10(w),faza)
[ma,mf]=margin(n,d)  %mf = 79.7560