t=[0:0.01:2*pi];
f=sin(2*t).*cos(2*t);
% for i=0:0.01:2*pi
% f(i)=sin(2*t(i))*cos(2*t(i))
%end
polar(t,f)