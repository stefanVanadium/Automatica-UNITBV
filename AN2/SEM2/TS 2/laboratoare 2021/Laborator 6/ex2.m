numGr=[1 1];
denGr=[1 5];

numGp=[2];
denGp=[1 2 0 0];

[numGd,denGd]=series(numGr,denGr,numGp,denGp);

rlocus(numGd,denGd)

[k poli]=rlocfind(numGd,denGd)