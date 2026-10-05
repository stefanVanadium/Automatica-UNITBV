function [sys, x0, str, ts] = Gsfun(t, x, u, flag)
A = [-1 0 0; 0 -2 1; 0 -1 -3];
B = [1 0; 0 1; 1 -1];
C = [1 0 1; 0 1 -1];
D = zeros(2, 2);

switch flag
    case 0
        sys = [3, 0, 2, 2, 0, 0];  % [n_state, 0, n_out, n_in, 0, 0]
        x0  = zeros(3, 1);
        str = [];
        ts  = [0 0];
    case 1
        sys = A*x + B*u;            % xdot
    case 3
        sys = C*x + D*u;            % y
    otherwise
        sys = [];
end
