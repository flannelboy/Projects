#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "structure.c"


int main(void)
{
    printf("Starting YourDay ...");
    sleep(1);
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
