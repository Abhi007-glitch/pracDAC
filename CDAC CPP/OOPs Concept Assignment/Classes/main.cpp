#include<iostream>
#include"String.h"

using namespace std;

int main()
{
    String str("abhinav");

    String str2(str);

    String str3 = (str+str2);

    cout<<str3.getStringVal()<<endl;
    cout<<str3.getSize()<<endl;

   return 0;
}