#include <iostream>
#include <fstream> 
using namespace std;





class CustomArray{
    
    const int size;
    int * arr;
   public :
   CustomArray(int n): size(n) // intializing constant variable value for each object
   {
      arr = (int*) malloc(n*sizeof(int));  // all get's intialized to zero 
   }
   
  //  int operator [] (int i)  // this function is usefull to only get value not set value 
  //  {
  //   return arr[i];
  //  }


   int& operator [] (int i)  // will work for both getting and setting the value 
   {
     return arr[i];
   }

   bool operator == (CustomArray arr1)
   {

    if (size!=arr1.getSize())
    {
      return false;
    }

      for (int i=0;i<size;i++)
      {
        if (arr[i]!=arr1[i])
        {
          return false;
        }
      }
      return true;

   }
    
  int getSize()
  {
    return this->size;
  }
    

   friend ostream& operator<< (ostream& os,CustomArray arr1);

   friend istream& operator>> (istream& is, CustomArray arr1);
   
};



istream& operator>> (istream& is, CustomArray arr2)
{
  for(int i =0;i<arr2.getSize();i++)
  {
    is>>arr2[i];
  }
return is;
}

ostream& operator<< (ostream& os, CustomArray arr1)
{
  os<<"[";
  for(int i = 0 ; i < arr1.getSize()-1;i++)
  {
    os<<arr1[i]<<" ,";
  }
  os<<arr1[arr1.getSize()-1];
  os<<"]\n";
  return os;
}



int main()
{
   CustomArray arr1(5);
   for ( int i=0;i<5;i++)
   {
    cout<<arr1[i]<<endl;
   }
   
   arr1[0]=1;

   arr1[0]=arr1[0]+2;
   cout<<(arr1[0]>2)<<endl;
   cout<<arr1[0]<<endl;

cout<<"Printing arr2"<<endl;

  CustomArray arr2(arr1);
  arr2[4]=10;

  for ( int i=0;i<arr2.getSize();i++)
  {
   cout<<arr2[i]<<endl;
  }

  CustomArray arr3(arr2);
  if (arr2==arr3)
  {
    cout<<"Equal"<<endl;
  }
cout<<arr2<<endl;

   CustomArray arr5(5);
   cout<<"taking input with operator overloaded"<<endl;
   cin>>arr5;
   cout<<"printing array after taking input using operator overloaded"<<endl;
   cout<<arr5<<endl;




 
  string fileName = "CustomArray.txt";
   ofstream outFileStream(fileName);
  if (!outFileStream)
  {
    cout<<"Unable to create file ";
  }
  else{
    
   outFileStream<<arr5;
  }

return 0;
}