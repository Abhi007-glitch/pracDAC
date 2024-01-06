#include<iostream>

using namespace std;


int power( int n,int pow )
{  
    int product = 1;
    for ( int i =0;i<pow;i++)
    {
        product *=n;
    }
    return product;
}



int main()
{
    int num1,pow ;
    cout<<"Enter number of which exponent has to be found  :"<<endl;
    cin>>num1;

    cout<<"Enter the value of exponent"<<endl;
    cin>>pow;

    cout<<power(num1,pow)<<endl;
    
    return 0;
}