// Online C++ compiler to run C++ program online


#include <iostream>

using namespace std;


int main()
{
 int input;
 cout<<"Enter the number to be checked for perfect Number"<<endl;
 cin>>input;
 int i;
 i=2;
 int sum;
 sum=1;
 while(i<=input/2){
     int rem;
     rem=input/i;
     if(rem*i==input){
       sum +=i;  
     }
     i++;
 }
 if(sum==input){
     cout<<"It's a perfect Number"<<endl;
 }else
 {
     cout<<"It's not a perfect Number"<<endl;
 }
 
 
 return 0;  
}

