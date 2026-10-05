Gr = tf([1 1], [1 5]);
Gf = tf(2, [1 2 0 0]);

G = series(Gr, Gf);

[k, p] = rlocfind(G) %[output:16a78075] %[output:81a8e301]

%[appendix]{"version":"1.0"}
%---
%[metadata:view]
%   data: {"layout":"onright","rightPanelPercent":40}
%---
%[output:16a78075]
%   data: {"dataType":"text","outputData":{"text":"Select a point in the graphics window\n","truncated":false}}
%---
%[output:81a8e301]
%   data: {"dataType":"error","outputData":{"errorType":"runtime","text":"Error using <a href=\"matlab:matlab.lang.internal.introspective.errorDocCallback('ginput', 'C:\\Program Files\\MATLAB\\R2025a\\toolbox\\matlab\\uitools\\uitools\\ginput.m', 84)\" style=\"font-weight:bold\">ginput<\/a> (<a href=\"matlab: opentoline('C:\\Program Files\\MATLAB\\R2025a\\toolbox\\matlab\\uitools\\uitools\\ginput.m',84,0)\">line 84<\/a>)\nInterrupted by figure deletion\n\nError in <a href=\"matlab:matlab.lang.internal.introspective.errorDocCallback('DynamicSystem\/rlocfind', 'C:\\Program Files\\MATLAB\\R2025a\\toolbox\\control\\ctrlanalysis\\@DynamicSystem\\rlocfind.m', 41)\" style=\"font-weight:bold\">DynamicSystem\/rlocfind<\/a> (<a href=\"matlab: opentoline('C:\\Program Files\\MATLAB\\R2025a\\toolbox\\control\\ctrlanalysis\\@DynamicSystem\\rlocfind.m',41,0)\">line 41<\/a>)\n   [re,im] = ginput(1);    % Get one point\n   ^^^^^^^^^^^^^^^^^^^^^^^^^"}}
%---
