#include <iostream>
#include<vector>
using namespace std;


class Employee{
   
    int baseSalary;
    int empId;
public:
    Employee()
    {
         
    }

    static int empCount;
    string name;
    
    virtual int calSalary()=0;
    virtual vector<string> getProjects()=0;
    virtual vector<string> getTechnologies()=0;
    
    void setName(string name)
    {
     this->name = name;
    }
    
    
    void setEmpId()
    {
      this->empId=empCount++;
    }
    
    int getBaseSalary()
    {
        return this->baseSalary;
    }

    void setBaseSalry(int salary)
    {
        this->baseSalary = salary;
    }
    // do we need destructor for a Absract class;
    
};


int Employee :: empCount=0;

class Tester : public Employee
{

   int days;
   int overTime;
   const int payPerHour;
   vector<string> projects ;
   vector<string> technologies;

   public :
   string position;
   int calSalary()
   {
      return (getBaseSalary()+overTime*payPerHour);
   }

   vector<string> getProjects()
   {
    return this->projects;
   }

   

   vector<string> getTechnologies()
   {
    return this->technologies;
   }


   int getOverTime()
   {
    return (this->overTime);
   }

   int getDays()
   {
    return (this->days);
   }

   int getPayPerHour()
   {
    return (this->payPerHour);
   }

  

  



};



class Developer : public Employee
{
   int days;
   int overTime;
   const int payPerHour;
   vector<string> projects ;
   vector<string> technologies;

   public :
   string position;
   int calSalary()
   {
      return (getBaseSalary()+overTime*payPerHour);
   }

   vector<string> getProjects()
   {
    return this->projects;
   }


   vector<string> getTechnologies()
   {
    return this->technologies;
   }


   int getOverTime()
   {
    return (this->overTime);
   }

   int getDays()
   {
    return (this->days);
   }

   int getPayPerHour()
   {
    return (this->payPerHour);
   }


};

int main()
{
     
    return 0;
}