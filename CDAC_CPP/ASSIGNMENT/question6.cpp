#include<iostream>
using namespace std;


int main ()
{
    char c;
    cout<<"Enter any value (int/char/number)"<<endl;

    cin>> c;
    
    // ascii value of NULL is Zero.
    cout<<"Ascii value of entered key is "<<(int)(c-NULL)<<endl;
    return 0;
}