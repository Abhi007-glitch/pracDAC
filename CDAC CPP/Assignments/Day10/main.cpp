#include<iostream>
using namespace std;


class BigInt {

    int num;
   
   public:
    BigInt(int n);

    int GetVal()
    {
        return this->num;
    }

    // operators overloading

    //conparision 
    // formate 1 ) (BigInt == BigInt)
    bool operator == (BigInt obj)
    {
        if (this->num==obj.num)
        {
          return true;
        }
        return false;
    } 

    // formate 2) (BigInt == int)
    bool operator ==(int n)
    {
        if (this->num==n)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    //formate 3) (int == BigInt) -> *******(left operand defines the comparison)*****
     
    // ***********************************************(ISSUE + CONCEPT )**********************************************************************
    //                              here left operand is premitive type so can't define a member function for it.
    //                              So we need to global operator overloading for defining comparision
    //                              But if we want to comapare int with BigInt we need to access num( a private variable of BigInt)- not allowed
     
    // Solution 1 : Best Solution - reusing member function by calling it inside global operator overloading 
    
    // Soltion 2 : Using friend function - in friend funciton  we can acces the value of class data member 
       friend bool operator ==( int n ,BigInt);
    // ************************ Look in Global scope for further code ********************************************************************

          

    bool operator < (BigInt obj);
    bool operator > (BigInt obj);
    bool operator >= (BigInt obj);
    bool operator <= (BigInt obj);
   
    //unary operator 

    BigInt operator ++ ()
    {
      this->num++;
      return *this;
    }
    
    // weird just can define type no argumnet or default value 
    BigInt operator ++ (int)
    {
       BigInt result(*this);
       this->num++;
       return result;
    }

    BigInt operator >> (int n)
    {
       this->num = this->num>>n;
        return *this;
    }

    BigInt operator | (BigInt obj)
    {
        BigInt result (this->num | obj.num);
        return result;
    }

    
};

// *********************************** GLOBAL OPERATOR OverLoading ************************************************************************
// method 1: 

// bool operator == (int n, BigInt obj)
// {
//     return (obj==n); // based on left operand it would call member function of BigInt class for comparision 
// }


// method 2:
 // this works because we have declear this function as a friend function inside the class 
bool operator == ( int n , BigInt obj)
{
    if (obj.num==n)
    {
        return true;
    }
    else 
    {
        return false;
    }
}



// ******************************************************************************************************************************************


bool BigInt :: operator >(BigInt obj)
{
return (this->num >obj.num);
}
bool BigInt :: operator <(BigInt obj)
{
  return (this->num <obj.num); 
}

bool BigInt :: operator >=(BigInt obj)
{
    return (this->num >=obj.num);
}

bool BigInt :: operator <=(BigInt obj)
{
    return (this->num <= obj.num);
}



BigInt :: BigInt(int n)
{
    this->num = n;
}




int main()
{
    BigInt n(10), n1(30), n3(10);

    // if (n==n3)
    // {
    //     cout<<"Equal"<<endl;
    // }
    // if (n<n1)
    // {
    //     cout<<"less then n1"<<endl;
    // }
    // if (n>=n1)
    // {
    //     cout<<"Greater than or equal to the n1 "<<endl;
    // }

    // if (n3>=n)
    // {
    //     cout<<"N3 is greate or equal to n1"<<endl;
    // }
    // else 
    // {
    //     cout<<"N3 is less than n1 "<<endl;

    // }



    n++;
    if (n<n1)
    {
        cout<<"N is less then n1"<<endl;
        cout<<n.GetVal()<< " , "<<n1.GetVal()<<endl;
    }

    n>>2;
    cout<<"Updated value is " <<n.GetVal()<<endl;
    BigInt nu(1);
    BigInt result= nu|n;
    cout<<result.GetVal()<<endl;
    
    int temp=2;

    if (temp==n)
    {
        cout<<"n-> num == 2"<<endl;
    }
    else 
    {
        cout<<"n-> num != 2"<<endl;
        cout<<n.GetVal()<<endl;
    }

    return 0;
}