#include<iostream>

using namespace std;

int main()
{
    int input ;
    cout<<"Enter number for which digits to be printed in words  :"<<endl;
    cin>>input;
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




int ans = 0;


while(input>0)
{
    int cur = input/tenPow;
    input = input%tenPow;
    tenPow/=10;



        switch (cur)
        {
        case 0:
            cout<<"Zero"<<" ";
            break;
        case 1:
           cout<<"One"<<" ";
           break;
        case 2:
            cout<<"Two"<<" ";
            break;
        case 3:
           cout<<"Three"<<" ";
           break;
        case 4:
            cout<<"Four"<<" ";
            break;
        case 5:
           cout<<"Five"<<" ";
           break;
        case 6:
           cout<<"Six"<<" ";
           break;
        case 7:
            cout<<"Seven"<<" ";
            break;
        case 8:
           cout<<"Eight"<<" ";
           break;
        case 9:
            cout<<"Nine"<<" ";
            break;
        default:
            cout<<endl;
            break;
        }




}
    
    return 0;
}



  