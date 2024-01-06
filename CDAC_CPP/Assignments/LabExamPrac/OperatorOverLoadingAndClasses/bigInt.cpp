#include<iostream>

using namespace std;




class BigInt{

  int num;
  
  public:
      BigInt(int n)
      {
        this->num=n;
      }
   
       int getVal()
       {
        return this->num;
       }
   int operator+ (BigInt i)
   {
    this->num+=i.num;
    return this->num;
   }

   int operator+ (int i)
   {
    this->num+=i;
    return this->num;
   }


   bool operator ==(int i)
   {
    return this->num==i;
   }
  
};

int operator+(int i, BigInt n)
{
  return n.getVal()+i;
}


int main()
{
 cout<<"Up and running!!<"<<endl;
 BigInt cur(1);

 cur=cur+10;
 
 int temp =11;
 temp = temp+cur;
  cout<<cur.getVal()<<endl;
  cout<<temp<<endl;
 cout<<(cur==temp/2)<<endl;

 if (cur==temp/2)
 {

  cout<<"true"<<endl;

 }
 else 
 {
  cout<<cur.getVal()<<" , "<<temp*2<<endl;
  cout<<"false"<<endl;
 }
 return 0;
}