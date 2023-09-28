#include<iostream>

using namespace std;

int reverse(int input)
{



if (input<10)
{
  
  return input;
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

return ans;

}

int main()
{
    int input ;
    cout<<"Enter number to be checked for palindrom  :"<<endl;
    cin>>input;
   if (reverse(input)==input)
   {
    cout<<"Number is Palindrom"<<endl;
   }
   else{
    cout<<"Number is not a Palindrom"<<endl;
   }
    return 0;
}