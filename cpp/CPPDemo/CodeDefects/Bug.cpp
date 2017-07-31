#include <stdlib.h>  
#include "Bug.h"  

// the user account   
TCHAR g_userAccount[USER_ACCOUNT_LEN] = "";
int len = 0;

bool ProcessDomain()
{
    TCHAR* domain = new TCHAR[ACCOUNT_DOMAIN_LEN];
    // ReadUserAccount gets a 'domain\user' input from   
    //the user into the global 'g_userAccount'  
    if (ReadUserAccount())
    {

        // Copies part of the string prior to the '\'   
        // character onto the 'domain' buffer  
        for (len = 0; (len < ACCOUNT_DOMAIN_LEN) && (g_userAccount[len] != '\0'); len++)
        {
            if (g_userAccount[len] == '\\')
            {
                // Stops copying on the domain and user separator ('\')   
                break;
            }
            domain[len] = g_userAccount[len];
        }
        if ((len = ACCOUNT_DOMAIN_LEN) || (g_userAccount[len] != '\\'))
        {
            // '\' was not found. Invalid domain\user string.  
            delete[] domain;
            return false;
        }
        else
        {
            domain[len] = '\0';
        }
        // Process domain string  
#pragma warning(suppress: 26496)
        bool result = CheckDomain(domain);

        delete[] domain;
        return result;
    }
    return false;
}

int path_dependent(int n)
{
    int i;
    int j;
    if (n == 0)
        i = 1;
    else
        j = 1;
    return i + j;
}