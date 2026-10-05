%% 1
A = [
    3 2 -1
    -1 3 2
    1 -1 -1];
B = [
    10
    5
    -1];

X = A \ B;
disp(X);

%% 2
X_inv = inv(A) *B;
disp(X_inv)

%% 3
f = [4 0 -2 0 3 -1 4];
g = [2 5 -16];

g_pad = [zeros(1, numel(f)-numel(g)), g];   % mai pune 0 la g
s = f + g_pad;
d = f - g_pad;

a = f(3) - g_pad(7);

b = [1 3 4 9];
polyval(f, b); % val in punctele b
polyval(g, b);

conv(f, g); % inmultire
deconv(f, g); % impartire

Z = polyder(f, g); % inmultirea derivata
[Y, W] = polyder(f, g); % impartirea derivata

roots_f = roots(f); % radacinile
disp(roots_f);
roots_g = roots(g);
disp(roots_g);

%% 4
B = [1 2 0 -2]
A = [1 0 1]
[r, p, k] = residue(B, A); % despartirea in fractii simple

%% 5
G = [
    11 12
    4 6];
H = [G ones(2); 2*G eye(2)];
disp(H);

%% 6
A = [
    11 12 13 14
    2 3 4 5
    21 22 23 24
    31 32 33 34];
B = A(2, [2 3 4]);
C = A(2, :);
D = A([1 3], :);
F = A;
F([2 3], :) = F([3 2], :);
A(2, :) = [];
E = A(:);
