function s = vecsum(V)
s = 0;
i = 1;
while i <= length(V) && V(i) < 9
    s = s + V(i);
    i = i + 1;
end
end
