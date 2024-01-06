#include<iostream>
using namespace std;


void swapByValues(int n1, int n2)
{
   int temp =n1;
   n1=n2;
   n2=temp;
}

void swapByRefer(int& n1, int& n2)
{
   int temp =n1;
   n1=n2;
   n2=temp;
}

void swapByPointer( int* n1, int* n2)
{
   int temp = *n1;
   *n1 = *n2;
   *n2 = temp;
}


int main()
{
  int n1,n2;
  cout<<"Enter two values to be swapped "<<endl;
  cin>>n1;
  cin>>n2;

  int temp1, temp2;

  temp1=n1;
  temp2=n2;

  swapByValues(temp1,temp2);
  cout<<"Swapping by value t1 t2 "<< temp1<<", " <<temp2<<endl;

 temp1=n1;
  temp2=n2;

  swapByRefer(temp1,temp2);
  cout<<"Swapping by ref t1 t2 "<< temp1<<", " <<temp2<<endl;

   
   temp1=n1;
  temp2=n2;

  swapByRefer(temp1,temp2);
  cout<<"Swapping byPointers t1 t2 "<< temp1<<", " <<temp2<<endl;



}