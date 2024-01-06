

#include <iostream>

using namespace std;


int main()
{
  
int input;
  cout<<"Enter the Number to be reversed"<<endl;

  cin>>input;


if (input<10)
{
  cout<<"Reverse value -> "<<input<<endl;
  return 0;
}

  int reverse=0;
  int temp = input;
  int tenPow = 1;


   while( temp>0)
   {
 if (temp/10>0)
 {
    tenPow*=10;
 }
 temp=temp/10;
   }


int increment =1;

int ans = 0;


while(input>0)
{
    int quotion = input/tenPow;
    ans += quotion*increment;
    increment*=10;
    input = input%tenPow;
    tenPow/=10;

}

cout<<"Reverse value -> "<<ans<<endl;

 return 0;  
}

