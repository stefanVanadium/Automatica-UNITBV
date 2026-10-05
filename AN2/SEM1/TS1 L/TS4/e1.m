numG = [2 1];
denG = [1 3 3 1];
G = tf(numG, denG);

numH = conv([1 0], [1 2]);
denH = conv([1 4i],[1 -4i], [1 3]);
H = tf(numH, denH);

GH = series(G, 1/H);   % sau direct tf(numG,denG) / tf(numH,denH)
