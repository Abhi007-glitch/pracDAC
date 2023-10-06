#include<iostream>
using namespace std;


 class Base {
    public: 
     int i=0;

     Base()
     {
        cout<<"Base class Constructor got called"<<endl;
     }
    ~Base()
     {
      cout<<"Base class Destructor got called "<<endl;
     }

};



/// *****************virtual class are used to avoid creation of multiple instance of same class type in derived classes.*********************
class Derived1 : virtual public Base{

    public :
     int j =1;

    Derived1()
    {
        cout<<"Derived1 class constructor got called"<<endl;

    }

    ~Derived1()
    {
        cout<<"Derived1 class destructor got called "<<endl;
    }
};

class Derived2: virtual public Base {
    public:
      int k=2;

    Derived2()
    {
        cout<<"Derived2 class constructor got called"<<endl;

    }

    ~Derived2()
    {
        cout<<"Derived2 class destructor got called "<<endl;
    }
};


class Derived : public Derived1, public Derived2 {
    public :
       int l=5;

    Derived()
   {
        cout<<"Derivedclass constructor got called"<<endl;

    }

    ~Derived()
     {
        cout<<"Derived class destructor got called "<<endl;
    }
};



int main()
{
    Base base;
    cout<<"Base "<<base.i<<endl;

   cout<<endl;
   cout<<endl;

    Derived1 der1;
    cout<<"Der1 "<<der1.i<<endl;

    cout<<endl;
   cout<<endl;

    Derived2 der2;
    cout<<"Der2 "<<der2.i<<endl;

    cout<<endl;
   cout<<endl;

    Derived der;
    cout<<"derived : j,k"<<der.j<<" "<<der.k<<endl;
    cout<<"Derived : "<<der.Derived1::i<<endl;   // juggad solution 
    cout<<"Derived Solution using Virtual class concept "<< der.i<<endl;
    cout<<endl;
   cout<<endl;

    return 0;
}



