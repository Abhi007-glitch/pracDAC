#include <iostream>

using namespace std;


int main()
{
  int n ;
  cout<<"Enter a number whose digit product has to be calculated!!"<<endl;

  cin>> n;

  int temp =n;
  
  int ans =1;
  while(temp>0)
  {
   ans=ans*(temp%10);
   temp=temp/10;
  }

  cout<<"The digit product of "<<n << " is : "<<ans<<endl;
  
}