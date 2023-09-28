#include<iostream>

using namespace std;

int main()
{
    int input ;
    cout<<"Enter number for which digits sum have to be found  :"<<endl;
    cin>>input;
    int sum =0;
   while(input!=0)
    {
        sum+=input%10;
        input = input/10;
    }
    cout<<sum<<endl;
    return 0;
}