#pragma once
#include <CodeAnalysis/SourceAnnotations.h>  

struct LinkedList
{
    struct LinkedList* next;
    int data;
};

typedef struct LinkedList LinkedList;

[returnvalue:SA_Post(Null = SA_Maybe)] LinkedList* AllocateNode();