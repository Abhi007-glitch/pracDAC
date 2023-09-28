
#include <iostream>
using namespace std;

int main ()
{
    int n;
    cout<<"Enter number "<<endl;
    cin>> n;
   
    int tabs = n-1;
    for( int i=1;i<=n;i++)
    {
      for ( int j =0;j<tabs;j++)
      {
        cout<<"\t";
      }
      tabs--;
      for(int j=1;j<=i ;j++ )
      {
        cout<<i<<"\t\t";
      }
     cout<<endl;
     cout<<endl;
    }
     cout<<endl;
      cout<<endl;
      cout<<endl;
      cout<<endl;
      cout<<endl;
      cout<<endl;


    return 0;
}