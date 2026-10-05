numG=9;
denG=[1 6];
numH=1;
denH=[1 0];

[numGd,denGd]=series(numG,denG,numH,denH);
nyquist(numGd,denGd)  %sist este stabil, caract nu inconjoara pct -1+j*0
%% 
numG=9;
denG=[1 6];
numH=1;
denH=[1 0];

[numGd,denGd]=series(numG,denG,numH,denH);
bode(numGd,denGd)
%% 
numG=9;
denG=[1 6];
numH=1;
denH=[1 0];

[numGd,denGd]=series(numG,denG,numH,denH);
[numG0,denG0]=feedback(numGd,denGd,1,1);
sys=tf(numG0,denG0);

bodemag(sys)


