X=[1 0 2; 0 0 1; 0 0 4];

y=any(X);
for i=1:3
    if y(1,i)==1
        i
    end
end

z=all(X);
for i=1:3
   if z(1,i)==1
       i
   end
end

w=any(X>(-1))
for(k=1:3)
    if w(1,k)==1
        k
    end
end
