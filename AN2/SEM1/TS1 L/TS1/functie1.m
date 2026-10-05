function [output] = functie1(inputx,inputy);
    if inputx-inputy >= 0 & inputx=inputy <= 10
        output = inputx^3 + inputy^3;
    elseif input-x-inputy < 0 & inputy >= 0
        output = inputx^2 + inputy^2;
    else
        output = (inputx-inputy)^2
    end
end

%%
function [output] = functie1(inputx,inputy);
    if inputx-inputy >= 0 & inputx=inputy <= 10
        output = inputx^3 + inputy^3;
    else
        if input-x-inputy < 0 & inputy >= 0
        output = inputx^2 + inputy^2;
    else
        output = (inputx-inputy)^2
    end
end