function output = functie1(x, y)
    if 0 <= x - y && x - y <= 10
        output = x^3 + y^3;
    else
        if x - y < 0 && y >= 0
            output = x^2 + y^2;
        else
            output = (x-y)^2;
        end
    end
end

%% sau cu if-elseif (nu merg ambele in acelasi fisier, e doar exemplu)

% function output = functie1(x, y)
%     if 0 <= x - y && x - y <= 10
%         output = x^3 + y^3;
%     elseif x - y < 0 && y >= 0
%         output = x^2 + y^2;
%     else
%         output = (x - y)^2;
%     end
% end
