#include <stdio.h>
#include <stdlib.h>


int main(void)
{


    printf("Starting Inventory...");
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
    printf("Enter password:");
    scanf("%d", &inputPass);

    while(inputPass != password)
    {
        printf("Incorrect password!");
        printf("Enter password:");
        scanf("%d", &inputPass);
    }
    printf("\nInventory empty.");
    return 0;
}
