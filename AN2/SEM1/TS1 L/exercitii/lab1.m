%% 1
% matricile
A = [ 1 2; 3 4];
B = [ 1 3 5 7];
C = [ 1; 4; 9];
% ; la sfarsit de linie opreste afisarea liniei in commnad window

A(2,1);
B(4);
C(3);

%% 2
functie1(1,3);
functie1(1,-3);
functie1(-1,3);
functie1(-4,-1);

%% 3
%versiunea mea de sub3 c++ coder
X = [ 
    1 0 2
    0 0 1
    0 0 4];

for j = 1:size(X,2)
    ok1 = 0;
    ok2 = 0;
    ok3 = 0;
    for i = 1:size(X,1)
        if X(i,j) ~= 0
            ok1 = 1;
        end
        if X(i,j) ~= 0
            ok2 = ok2 + 1;
        end
        if X(i,j) > -1
            ok3 = 1;
        end
    end
    if ok1 == 1
        disp(['ok1 true for column ' num2str(j)])
    end
    if ok2 == 3
        disp(['all 3 entries nonzero in column ' num2str(j)])
    end
    if ok3 == 1
        disp(['ok3 true for column ' num2str(j)])
    end
end

%versiunea copilot
for j = 1:size(X,2)
    col = X(:,j);
    ok1 = any(col ~= 0);
    ok2 = sum(col ~= 0);
    ok3 = any(col > -1);
    % display or use ok1, ok2, ok3...
end

%% 4
sum1 = 0;
for i = 1:1:100
    sum = sum + i;
end
disp(sum1)

i = 1;
sum2 = 0;
while(i<101)
    sum2 = sum2 + i;
    i = i + 1;
end
disp(['Sum from 1 to 100 is: ' num2str(sum2)]);
% ce rost mai am daca aiu imi da asta
sum3 = sum(1:100);
disp(['Sum from 1 to 100 is: ' num2str(sum3)]);

%% 5
X = [5 2 -9 10 -1 9 1];
idx = find(X > 8, 1);
if isempty(idx)
    s = sum(X);
else
    s = sum(X(1:idx-1));
end
disp(s);