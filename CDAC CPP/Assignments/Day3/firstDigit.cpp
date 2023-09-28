#include<iostream>

using namespace std;

int main()
{
    int input ;
    cout<<"Enter number for which first digit have to be found :"<<endl;
    cin>>input;
    
    while(input/10>0)
    {
        input = input/10;
    }

    cout<<input<<endl;
    return 0;
}