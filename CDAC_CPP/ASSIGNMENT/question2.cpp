#include<iostream>

using namespace std;

int validated_marks()
{
    int n;
    cin>>n;
    if (n<0)
    {
     do
    {
        cout<<"Enter a valid marks value."<<endl;
       cin>>n;
    }while(n<0);
    }
    return n;
   
    
}


int main ()
{
  
  cout<<"Enter Your marks : "<<endl;

int input;
int sum = 0;
for ( int i =0;i<5;i++)
{
   cout<<"Enter marks scored in subject "<<i<<" : "<<endl;
   input = validated_marks();
   sum+=input;
}

//to get output in float or decimal we were needed to covert both numerator and denominator to float
float ans = (float)sum/(float)5;

cout<<ans<<endl;
int ansInt = (int) ans;

cout<<"Average Score is : "<<ans<<"( "<<ansInt<<" )"<<endl;

   
}