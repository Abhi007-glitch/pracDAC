#include<iostream>

using namespace std;

int main()
{
    int input ;
    cout<<"Enter number for which factors have to be found :"<<endl;
    cin>>input;
    
    for ( int i =2;i<=input/2;i++)
    {
        if (input%i==0)
        {
            cout<<i<<" ,";
        }
    
    }
    cout<<endl;
    return 0;
}