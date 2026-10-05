% S-function pentru G0(s) = (s^2+7s+18)/(s^2+7s+9)
% spatiu de stare: A=[-7 -9; 1 0], B=[1;0], C=[0 9], D=1

function [sys, x0, str, ts] = G0sfun(t, x, u, flag)

A = [-7 -9; 1 0];
B = [1; 0];
C = [0 9];
D = 1;

switch flag
    case 0  % initializare
        sizes = simsizes;
        sizes.NumContStates  = 2;
        sizes.NumDiscStates  = 0;
        sizes.NumOutputs     = 1;
        sizes.NumInputs      = 1;
        sizes.DirFeedthrough = 1;
        sizes.NumSampleTimes = 1;
        sys = simsizes(sizes);
        x0  = [0; 0];
        str = [];
        ts  = [0 0];

    case 1  % derivate
        sys = A*x + B*u;

    case 3  % iesire
        sys = C*x + D*u;

    otherwise
        sys = [];
end
