#include <iostream>
#include <string>
using namespace std;



class Account
{

private:                      
     int Account_number; 
     int Account_balance;
    
    
     string Account_name; // name of account holder
public:
    static int acc_count;
   //getAcc_Number();
   int getAcc_Number()
   {
      return this->Account_number;
   }

   //getAcc_Balance();
    
    int getAcc_Balance()
    {
       return this->Account_balance;
    }

   //getAcc_name();

   string getAcc_Name()
   {
     return this->Account_name;
   }

   
   //setAcc_balance();

   void setAcc_Balance(int n)
   {
       this->Account_balance=n;
   }


   //setAcc_name;
   void setAcc_Name(string name)
   {
   this->Account_name=name;
   }
    
    // set_Account_Number
   void setAcc_Number(int n)
    {
    this->Account_number=n;
   }
     
     
};


int Account :: acc_count=0;

class AcccountType:public Account
{
    private:
       string type;
    
    
    public:
    
    //   AcccountType( string type,string name);
    //  bool validateWithDraw(int n);
    //     void withDrawMoney(int n);
    //      void depositMoney(int n);
    //    string get_AccoutType()
    
    AcccountType( string type,string name)
    {
     if (type=="saving")
     {
        this->type="saving";
        setAcc_Number(this->acc_count++);
        setAcc_Name(name);
        setAcc_Balance(0);
     }
     else if (type=="current")
     {
       this->type="current";
        setAcc_Number(acc_count++);
        setAcc_Name(name);
        setAcc_Balance(1000);
     }
     else 
     {
        cout<<"Enter a valid account Type"<<endl;
     }
    }

    // get_account_type
    string get_AccoutType()
    {
        return this->type;
    }


// validate Transaction
   bool validateWithDraw(int n)
   {
 if (getAcc_Balance()-n<0)
       {
        cout<<"Given Transaction can not be performed, low balance"<<endl;
        return false;
       }
       else 
       {
        return true;
       }
   }


// withdraw 
    void withDrawMoney(int n)
    {
      if (validateWithDraw(n))
      {
        setAcc_Balance(getAcc_Balance()-n);
        cout<<"transaction succesfull"<<endl;
      }
    }
    
// depositeMoney
    void depositMoney(int n)
    {
      setAcc_Balance(getAcc_Balance()+n);
      cout<<"transaction Succesfull"<<endl;
    }



// getBalance   
int getBalance()
{
    return this->getAcc_Balance();
}    


    //
};



int main()
{
    Account arr[10]; 

    bool flag=false;
    int option;
    string name;
    while (!flag)
    {
       cout<<"Select your Option"<<endl;
       cout<<"1.Create a new Account "<<endl;
       cout<<"2.check your balance "<<endl;
       cout<<"3.Deposit money"<<endl;
       cout<<"4.Transfer Money "<<endl;
       cout<<"Any Other key to end the program"<<endl;
       
       cin>>option;
       switch (option)
       {
       case 1:
            cout<<"Enter your name : "<<endl;
            cin>>name;
            cout<<"Select type of account You want to create ";
            cout<<"1.Current Account"<<endl;
            cout<<"2.Saving Account"<<endl;
            cin>>option;
            while(option!=1 && option!=2)
            {
                cout<<"select a valid option"<<endl;
            }
            
            if (option==1)
            {
                AcccountType user("current", name);
                
            }
            else 
            {

            }
            
        break;
    
       case 2:
        
        break;
       
       default:
        break;
       }
    }
    
     AcccountType user("saving","abhinav");
     cout<<user.get_AccoutType()<<endl;
     user.withDrawMoney(10);
     user.depositMoney(10);
      cout<<user.getBalance()<<endl;

    AcccountType user1("current","abhishek");
    cout<<user1.get_AccoutType()<<endl;
     user1.withDrawMoney(10);
     user1.depositMoney(10);
      cout<<user1.getBalance()<<endl;


    return 0;
}