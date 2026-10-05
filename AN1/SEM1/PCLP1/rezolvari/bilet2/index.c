#include <stdio.h>
#include <stdlib.h>

struct mySet
{
    int nr_element;
    double *element;
};

void citire(struct mySet *s1, struct mySet *s2)
{
    printf("introduceti elementele primului sir:\n");
    for (int i = 0; i < s1->nr_element; i++)
    {
        printf("elementul %d este: ", i + 1);
        scanf("%lf", &s1->element[i]);
    }
    printf("introduceti elementele celui de-al doilea sir:\n");
    for (int i = 0; i < s2->nr_element; i++)
    {
        printf("elementul %d: ", i + 1);
        scanf("%lf", &s2->element[i]);
    }
}

void afisare(struct mySet *s1, struct mySet *s2)
{
    printf("Elementele primului sir: ");
    for (int i = 0; i < s1->nr_element; i++)
    {
        printf("%lf ", s1->element[i]);
    }
    printf("\n");

    printf("Elementele celui de-al doilea sir: ");
    for (int i = 0; i < s2->nr_element; i++)
    {
        printf("%lf ", s2->element[i]);
    }
    printf("\n");
}

int main()
{
    struct mySet s1[5], s2[7];
    printf("Introduceti numarul de elemente pentru primul sir: ");
    scanf("%d", &s1[0].nr_element);

    printf("Introduceti numarul de elemente pentru al doilea sir: ");
    scanf("%d", &s2[0].nr_element);

    printf("Introduceti elementele:\n");
    citire(&s1, &s2);
    afisare(&s1, &s2);

    return 0;
}