// Write a program to calculate Net Salary of an employee. Accept Basic Salary (BS) from the user.                                   	HRA is 15% of BS										DA is 30% of BS											PF is 12.5% of GS										Gross Salary is BS + HRA + DA									Net Salary = Gross Salary – PF
// HRA is 15% of BS									
// DA is 30% of BS		
// PF is 12.5% of GS									
// Gross Salary is BS + HRA + DA								
// Net Salary = Gross Salary – PF



#include<iostream>
using namespace std;


int main()
{
    double baseSalary;
    double HRA,DA,PF,grossSalary;
    
    cout<<"Enter Your Base Salary"<<endl;
    cin>>baseSalary;
    // HRA is 15% of BS	
    HRA = baseSalary*(0.15);

    cout<<"HRA "<<HRA<<endl;
    // DA is 30% of BS	
    
    DA = baseSalary*(0.3);
       cout<<"DA "<<DA<<endl;
    // PF is 12.5% of GS
     
     PF = baseSalary*0.125;
   cout<<"PF "<<PF<<endl;
    // Gross Salary is BS + HRA + DA
     
     grossSalary= baseSalary+HRA+DA;
   cout<<"Gross Salary "<<grossSalary<<endl;
    // Net Salary = Gross Salary – PF
    
      double net = grossSalary-PF;

    cout<<"net "<<net<<endl;
    
    
    return 0;
}
