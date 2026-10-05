function [sys,x0,str,Te]=RC(t,x,u,flag,A,B,C)
%Dinamica unui circuit RC (iesirea pe condensator)
%Stare x1 = uC (t) = y(t)
% x1_dot = -1/(R*C) * x1 + 1/(R*C) * u
% iesirea y = x1
% Conditii initiale nule.

% Setati valorile componentelor
%R = 10*10^3; % ohm
%C = 100*10^-12; % farad

%A = -1/(R*C);
%B = 1/(R*C);
%Cmat = 1;

if flag==1
    % derivate
    sys = A*x + B*u;
elseif flag==3
    % iesiri
    sys = C * x;
elseif flag==0
    % initializari: [#continua, #discrete, #iesiri, #intrari, nr_aux, direct_feedthrough, Ts]
    sys = [1, 0, 1, 1, 0, 0, 0];
    x0 = 0;
    str = [];
    Te = [];
else
    sys = [];
end