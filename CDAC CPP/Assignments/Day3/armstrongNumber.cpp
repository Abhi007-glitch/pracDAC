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

int numberOfDigit(int n )
{
    int count=0;
    while(n!=0)
    {
        count++;
        n=n/10;
    }
    return count;
}

int main()
{
    int input ;
    cout<<"Enter number to be checked for Armstrong  :"<<endl;
    cin>>input;
    int temp = input;
    
    
    int length = numberOfDigit(input);

    int sum =0;
   while(input!=0)
    {   
        // cout<<input%10<<"  "<<length<<"  ->  ";
        // cout<<power(input%10,length)<<endl;
        sum+=power(input%10,length);
        input = input/10;
    }
    if (temp == sum)
    {
       
        cout<<"The given number is ArmStrong Number"<<endl;
    }
    else{
        //  cout<<"SUM -> "<<sum<<endl;
        cout<<"The given number is not ArmStong Number"<<endl;
    }
    return 0;
}