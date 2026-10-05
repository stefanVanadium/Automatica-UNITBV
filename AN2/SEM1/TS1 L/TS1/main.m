%% 1

A = [1 2; 3 4];
B = [1 3 5 7];
C = [1; 4; 9];

a = A(2,1);
b = B(4);
c = C(3,1);

%% 3

X = [1 0 2; 0 0 1; 0 0 4];
Y = zeros(3,3);

Y(1,:) = any(X > 0);   % at least one > 0 in each column
Y(2,:) = all(X == 0);  % all zeros
Y(3,:) = all(X > -1);  % all greater than -1

Y

%% 4

sum = 0;

sum = funcwhile(sum);
sum = funcfor(sum);

%% 5

V = [5 2 -9 10 -1 9 1];

s = vecsum(V);


