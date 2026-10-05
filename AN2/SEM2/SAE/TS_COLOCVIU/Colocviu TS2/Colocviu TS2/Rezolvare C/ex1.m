%% a)

num_g0s = [1 5 11];
den_g0s = [1 2 4];
[A,B,C,D] = tf2ss(num_g0s,den_g0s);


%% b)

Q = obsv(A,C);
det(Q)
if(det(Q) ~= 0)
    disp("Sistemul este observabil")
end