classdef lab1

    methods(Static)

        % Use the code browser on the left to add the callbacks.


        function A(callbackContext)
        if str2num(get_param(gcb, "A"))<0
            error("amplitudinea este negativă")
        end

        end

    end
end