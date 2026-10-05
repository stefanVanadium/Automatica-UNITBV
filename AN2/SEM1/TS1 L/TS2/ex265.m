G = [1 2; 4 6];
I = eye(2);
U = ones(size(G));

H = [G I; 2*G U];
H