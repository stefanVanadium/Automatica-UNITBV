%% a)

a = 3;
num_gcd = 9;
den_gcd = [1 a 0];
[A,B,C,D] = tf2ss(num_gcd,den_gcd);
nyquist(num_gcd,den_gcd);

% poli: Re(p1,2)=-1 => sistem stabil