#include<iostream>
using namespace std;

class String {

    char *str;
    int size;
    int len;

public:

//default constructor 
String ();


 // parameterized  constructor
    String(const char (&input)[]);
    
   // constructor -2

   String( String &input);
   


  // Size of 

  int Size();


  void Compare( String &s1, String &s2);

// operator Overloading 

String operator + (String &str2);



String operator = (String &str2);




int getSize();

char * getStringVal();




};


