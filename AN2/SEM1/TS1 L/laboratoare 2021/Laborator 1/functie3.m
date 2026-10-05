function [s] = functie3()
 X=[5 2 -9 10 -1 9 1];
s=0;
for i=1:length(X)
    if X(1,i)>8 break;
    else s=s+X(1,i);
    end
end
end

