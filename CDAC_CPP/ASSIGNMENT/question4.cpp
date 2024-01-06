#include<iostream>

using namespace std;

// re-try

int main ()
{

   int num1,num2;
   cout<<"Enter the value of fist number 1 :"<<endl;
   cin>>num1;

   cout<<"Enter the value of fist number 2 :"<<endl;
   cin>>num2;
  
   // Swapping with third variable 
   int s1,s2;
   s1=num1;
   s2=num2;
   int temp = s1;
   s1 = s2;
   s2 =temp;
   cout<<"Swapped value using thrid variable, first number value: "<<s1<<" Second number value : "<<s2<<endl;
   
   // swapping without 3rd variable using + - logic;

   s1=num1;
   s2=num2;

   s1=s1+s2;
   s2= s1-s2;
   s1 = s1-s2;

    
    cout<<"Swapped value without using thrid variable, first number value: "<<s1<<" Second number value : "<<s2<<endl;

   
   
    return 0;
}