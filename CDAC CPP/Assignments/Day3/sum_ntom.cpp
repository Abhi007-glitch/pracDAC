#include<iostream>

using namespace std;

int main()
{
    int num1,num2 ;
    cout<<"Enter the two numbers for in between numbers sum has to be found "<<endl;
    cin>>num1;
    cin>>num2;

    int smaller = num1;
    int greater =num2 ;
    if (num1>num2)
    {
        smaller=num2;
        greater=num1;
    }

    int sum1 = (greater*(greater+1))/2;
    int sum2 = (smaller*(smaller+1))/2;

    cout<<"Sum 1 "<<sum1<<endl;
    
    cout<<"Sum 2 "<<sum2<<endl;

    cout<<"sum = "<<smaller+sum1-sum2<<endl;
    
   
    return 0;
}