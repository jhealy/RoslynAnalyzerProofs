#include <CodeAnalysis/SourceAnnotations.h>  
#include <windows.h>  
#include <stdlib.h>    
#include "annotations.h"  

LinkedList* AddTail(LinkedList *node, int value)
{
    LinkedList *newNode = NULL;

    // finds the last node  
    while (node->next != NULL)
    {
        node = node->next;
    }

    // appends the new node  
    newNode = AllocateNode();
    newNode->data = value;
    newNode->next = 0;
    node->next = newNode;

    return newNode;
}