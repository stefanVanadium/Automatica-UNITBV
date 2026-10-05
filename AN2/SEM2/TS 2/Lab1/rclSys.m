%[text] Brief summary of this function.
%[text] Detailed explanation of this function.
function [sys,x0,str,Te] = rcSys(t,x,u,flag,R,C,L)

if flag == 1
    A = [-R/L -1/L; 1/C 0];
    B = [1/L; 0];
    
    sys= A * x + B * u;

elseif flag == 3
    C = [0 1];
    sys = C * x;

% sys(1) - nr starilor continue;
% sys(2) - nr starilor discrete;
% sys(3) - nr iesirilor;
% sys(4) - nr intrarilor;
% sys(5) - alocat pentru găsirea rădăcinilor;
% sys(6) - flagul de acces direct al mărimii de intrare;
% sys(7) - numărul momentelor de eşantionare.
elseif flag == 0
    sys=[2,0,1,1,0,0,0];
    x0=0;
    str=[];
    Te=[];
else 
    sys=[];
end



%[appendix]{"version":"1.0"}
%---
