#include<iostream>
#include "String.h"
using namespace std;




//default constructor 
String :: String ()
{
    this->size = 0;
    this->len=0;
    this->str=NULL;
}  

 // parameterized  constructor
  String :: String(const char (&input)[])
    {
        int total = 0;
       int j =0;
       while(input[j] && input[j]!='\0')
       {
          j++;
          total++;
       }
      this->size = total+1;


       int length=0;
       str = new char [this->size];

       for ( int i=0;i<this->size-1;i++)
       {
        str[i]=input[i];
       
        length++;
       }

       this->len=length;

    }
   

   // constructor -2

  String :: String( String &input)
   {
    
    this->size= input.size;
    this->len = input.len;
    
   
    this->str = new char[this->size];
    // deepCopy

    for ( int i=0;i<this->size;i++)
       {
        str[i]=input.str[i];
        if (input.str[i]=='\0')
        {
            return;
        }
       }

   }
    


  // Size of 

  int String ::  Size()
  {
    return this->len;
  }

  void String :: Compare( String &s1, String &s2)
  {
    char *str1= s1.str;
    char *str2 = s2.str;

    
    int n = (s1.len<s2.len)?s1.len:s2.len;

   for ( int i=0;i<n;i++)
   {
    if (str1[i]<str2[i])
    {
        cout<<"String "<<str2<<"is Greater than "<<str1<<endl;
    }
    else if (str1[i]>str[2])
    {
     cout<<"String "<<str1<<"is Greater than "<<str2<<endl;
    }
   }

  }

// operator Overloading 

String String::  operator + (String &str2)
{
    String *ans = new String();
    ans->size = this->len+str2.len +1;
    ans->len = ans->size-1;

    ans->str= new char[ans->size];

    char * temp = ans->str;
    char * cp1 = this->str;
    for ( int i =0;i<this->len;i++)
    {
        temp[i]= cp1[i];
    }

    char *cp2= str2.str;
  
    for ( int i =0;i<str2.len;i++)
    {
       temp[i+this->len]=cp2[i];
    }

     
    temp[this->len+str2.len]='\0';
   

   return *ans;
   
}


String String:: operator = (String &str2)
{
    this->size =str2.size;
    this->len = str2.len;

    this->str= new char[str2.size];
    
    for ( int i =0;i<str2.len;i++)
    {
       this->str[i]= str2.str[i];
    }
    this->str[this->len]='\0';

    return *this;

}



int String:: getSize()
{
    return this->size;
}

char * String :: getStringVal()
{
    return this->str;
}







