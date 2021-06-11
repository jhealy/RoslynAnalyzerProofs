#include <windows.h>  

//    
//These 3 functions are consumed by the sample  
//  but are not defined. This project cannot be linked!  
//  

bool CheckDomain(LPCSTR);
HRESULT ReadUserAccount();

//  
//These constants define the common sizes of the   
//  user account information throughout the program  
//  

const int USER_ACCOUNT_LEN = 256;
const int ACCOUNT_DOMAIN_LEN = 128;