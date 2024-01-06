#include<iostream>
#include<stack>
using namespace std;

int main()
{
   int n ;
   cout<<"Enter a number to be reversed :";
   cin>>n;

   stack<int> st;
   int temp =n;
   
   
   while(temp>0)
   {
    int cur = temp%10;

    st.push(cur);  // push the last digit of temp into the stack
    temp /= 10;     // remove the last digit from temp
   }
 


   int ans = 0;
   int pow=1;
   while(!st.empty())
   {
    int cur = st.top();
    ans+= cur*pow;
    pow*=10;
    st.pop();
   }

cout<<"The revered number is "<<ans<<endl;

   
}