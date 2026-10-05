function [f] = functie1 (x,y)

if x-y>=0 & x-y<=10 
    f=x^3+y^3
else if x-y<0 & y>=0 
               f=x^2+y^2
    else f=(x-y)^2
  
    end

end



