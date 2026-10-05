%% a
num_g = 1;
den_g = [1 4 0 0];

num_h = 1;
den_h = 1;

[num_serie,den_serie] = series(num_g,den_g,num_h,den_h);

rlocus(num_serie,den_serie)
% 3 ramuri -> inf
% (0,0) punct de ramificatie

%% b
[k,p] = rlocfind(num_serie,den_serie)
% sistemul este instabil pentru oricare k pozitiv