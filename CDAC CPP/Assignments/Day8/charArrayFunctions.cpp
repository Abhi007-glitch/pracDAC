#include <iostream>
using namespace std;

int size(char str[])
{
    return  sizeof(str)/sizeof(str[0]);
}


int strLen(char str[])
{
 int len=0;

 while(str[len]!='\0')
 {
  len++;
 }
 return len;
}


// void strCpy(src,dest)

void strCpy(char *src, char *dest)
{
   int size1,size2;
   int len1,len2;
   
   len1=strLen(src);
   len2=strLen(dest);

   if (len2<len1 && size2-1<len1)
   {
    cout<<"The given Src string can not be accomodated in destination string "<<endl;
   }

   for ( int i=0;i<len1;i++)
   {
     dest[i]=src[i];
    }
    
    dest[len1]='/0';

}




// bool StrCompare(str1,str2)

bool StrComp(char str1[], char str2[])
{
    int len1,len2;
    len1 = strLen(str1);
    len2 = strLen(str2);
    
   if (len1!=len2)
   {
    return false;
   }
   
   for ( int i =0;i<len1;i++)
   {
    if (str1[i]!=str2[i])
    {
      return false;
    }
   }
   return true;
}


//void toUpperCase(str)

void toUpperCase(char str[])
{
 int n = strLen(str);
 for ( int i=0;i<n;i++)
 {
    if (str[i]>='a')
    {
        str[i]= (char)(str[i]-32);
    }

 }

 cout<<"UpperCase Structure : "<< str<<endl;
}



// void toLowerCase(str)

void toLowerCase(char str[])
{

 int n = strLen(str);

 for ( int i=0;i<n;i++)
 {
    if (str[i]<'a')
    {
        str[i]= (char)(str[i]+32);
    }

 }

 cout<<"LowerCase Structure : "<< str<<endl;
}


int main()
{
    char str [100] ="Abhinav";
    cout<<"Length of Strting is : "<<strLen(str)<<endl;
    toUpperCase(str);
    toLowerCase(str);

    char str1 [100]= "Abhinav";
    
    cout<<StrComp(str,str1)<<endl;

}