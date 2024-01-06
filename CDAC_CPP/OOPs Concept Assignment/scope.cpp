#include<iostream>
using namespace std;

class Base
{
 
protected:
   int pro=10;
private:
    /* data */
    int pri=11;
public:
int pub=1;
   int getPrivate()
   {
    return this->pri;
   };
};


class DerivedPro : protected Base{
   
   public:
   void getProtected()
   {
    cout<<this->pro<<endl;
   }
   void getPrivateVal()
   {
      cout<<this->getPrivate()<<endl;
   }
   void getPublic()
   {
    cout<<this->pub<<endl;
   }

   
};

class DerivedPub : public Base{

public:
   void getProtected()
   {
    cout<<this->pro<<endl;
   }
   void getPrivateVal()
   {
      cout<<this->getPrivate()<<endl;
   }
   

};

class DerivedPri : private Base{
   
   public:
   void getProtected()
   {
    cout<<pro<<endl;
   }
   void getPrivateVal()
   {
    cout<<this->getPrivate()<<endl;
   }
   void getPublicVal()
   {
    cout<<pub<<endl;
   }
     
};



int main()
{

    // cout<<"Public object access :"<<endl;
    // DerivedPub pub;
    // cout<<pub.pub<<endl;
    // pub.getProtected();
    // cout<<endl;
    // pub.getPrivateVal();

    // cout<<endl;


    // cout<<"Protected object access"<<endl;
    // DerivedPro pro;
    // pro.getPublic();
    // pro.getProtected();
    // pro.getPrivateVal();
    
    // cout<<endl;
    

    cout<<"Private object access"<<endl;

    DerivedPri pri;
    pri.getPublicVal();
    pri.getPrivateVal();
    pri.getProtected();


    return 0;
}





