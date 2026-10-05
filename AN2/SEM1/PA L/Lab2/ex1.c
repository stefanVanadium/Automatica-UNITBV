#include <stdio.h>

int main() {
    int *p;
    int val;
    p = &val;
    *p = 42;
    printf("Value: %d\n", *p);
    return 0;
}