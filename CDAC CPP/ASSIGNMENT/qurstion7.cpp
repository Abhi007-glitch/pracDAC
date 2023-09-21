// Write a program to find leap year by using:								
// a. if-else and logical operators (&& and ||)							
// b. Conditional Operators (? :)							
// (A leap year is divisible by 4 and is not divisible by 100 but it could be divisible by 400)



#include<iostream>
using namespace std;


int main()
{
    int year;

    cout<<"Enter Year to be checked for Leap Year : "<<endl;
    cin>> year;

    if (year%4==0 && year%100!=0 && year%400==0)
    return 0;
}