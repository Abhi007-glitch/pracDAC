#include<iostream>

using namespace std;

bool checkPrime(int n )
{
    for( int i =2;i<=n/2;i++)
    {
        if (n%i==0)
        {
          return false;
        }
    }
    return true;
}

int main()
{
    int num1,num2 ;
    cout<<"Enter the range in which prime numbers have to be founded "<<endl;
    cin>>num1;
    cin>>num2;

    int smaller = num1;
    int greater =num2 ;
    bool flag ;
    
    for ( int i =smaller;i<=greater;i++)
    {
         flag = checkPrime(i);
        if (flag)
        {
            cout<<i<<" ,";
        }
    }

    cout<<endl;
    
   
    return 0;
}