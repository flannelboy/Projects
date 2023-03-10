#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "structure.c"

// >>>>> when including a file, make sure that file is complete <<<<<
// >>>>> otherwise, console will throw expect "{", before main. <<<<<


int main(void)
{
    time_t rawtime;
    struct tm *t;

    time(&rawtime);
    t = localtime(&rawtime);
    printf("Starting YourDay ...");
    sleep(1);
    printf("\nToday is %s", asctime(t));

    char getPassword[51];
    FILE *PassIN = fopen("password.txt", "r");
    if(PassIN == NULL)
    {
        printf("Cannot check password.");
        return 1;
    }
    else
    {
        fgets(getPassword,51,PassIN);
    }
    fclose(PassIN);
    int password = atoi(getPassword);
    int inputPass = 0;

    printf("\nEnter password:");
    scanf("%d", &inputPass);
    do
    {
        printf("Incorrect password!");
        printf("\nEnter password:");
        scanf("%d", &inputPass);
    }
    while(inputPass != password);
    printf("Inventory empty.");

    return 0;
}
