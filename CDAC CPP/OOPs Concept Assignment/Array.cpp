#include<iostream>
using namespace std;

 

class MyArray{
    int *data;
   const int size;


  public:
// ********************** CONCEPT :- special constructor which run before even befor default value assignment by compiler ***********************     
     MyArray(int n): size(n)
     {
        // dynamic memory allocation for array and passing it to our data pointer
        data = new int[size];
     }
     
/// ************************************************ CONCEPT ***********************************************************************************
      //  int operator [] ( int n)
    //  {
       
    //  }

    //Note : when we return a value from a function that value is stored in the cpu register, so we have no idea of it's location - not a (lvalue type)-> no location defined for the value;

     // this would return int (obj[1] will be equal to a constant int value like 8,9), but we want to assign value so we need to pass something 
    //  which is some location (lvalue) so that it won't be constant (so we can pass pointer or a reference )
    

     // This method works - but have a complex syntax for accesing value 
    // int* operator [] ( int n)
    // {
    //   return &this->data[n];
    // }

   
    
    int& operator [] (int n)
    {
        return this->data[n];
    }
   
   

    

};



int main()
{
 
 MyArray arr(5);

// // defining value  via pointer method 
// *arr[0]=2;

// //accesing value via pointer
// cout<<*arr[0]<<endl;

 // defining value of our custom array just like normal array syntax
 arr[1]=2;

 //Accessing value of custom array with same syntac as in Built array.
 cout<<arr[1]<<endl;
return 0;
}