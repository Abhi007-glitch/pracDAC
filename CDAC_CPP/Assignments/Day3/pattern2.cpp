#include<iostream>
using namespace std;

void pattern1()
{
int n;

    cin>>n;

    for ( int i =1;i<=n;i++)
    {
        for(int j=1;j<=i;j++)
        {
            cout<<i;
        }
        cout<<endl;
    }
    return ;
}


int main()
{
    int n;
    cin>>n;

    for ( int i =1;i<=n;i++)
    {
        for ( int j=1;j<i;j++)
        {
            cout<<"| ";
        }
        cout<<"|_"<<endl;
        

    }


    
}