#include <iostream>
using namespace std;


int findMax(int *arr, int n)
{
int max=arr[0];
for ( int i=1;i<n;i++)
{
    if (arr[i]>max)
    {
        max =arr[i];
    }
}
return max;
}

int findMin(int *arr, int n)
{
    int min=arr[0];

    for ( int i =1;i<n ;i++)
    {
        if (arr[i]<min)
        {
            min=arr[i];
        }
    }
    return min;
    
}

int findSecondMin(int *arr, int n)
{
    if (n==1)
    {
        return -1; // if 1 element no secMin possible 
    }
  int min = arr[0];
  int secMin = arr[1];
  for ( int i =1;i<n;i++)
  {
    if (arr[i]<min)
    {
        secMin=min;
        min = arr[i];
    }
    else if (arr[i]<secMin)
    {
        secMin =arr[i];
    }
  }
  

  return secMin;
}

int findSecondMax(int *arr, int n)
{

  int max = arr[0];
  int secMax = arr[0];

  if (n==1)
  {
    return -1; // second max not possible in array of size 1
  }

  for ( int i=1;i<n;i++)
  {
    if (arr[i]>max)
    {
        secMax=max;
        max=arr[i];
    }
    else if (arr[i]>secMax)
    {
        secMax=arr[i];
    }
  }

  return secMax;

}

bool CheckIfPresent(int *arr, int n, int cur)
{
 
 for ( int i=0;i<n;i++)
 {
    if (arr[i]==cur)
    {
        return true;
    }
 }
 return false;

}

int main()
{

    int arr[] = {1,3,5,9,2,11,4,22,3};
    int temp = 3;
    cout<<"Max value is : " <<findMax(arr, 9)<<endl;

    cout<<"Min value is : "<<findMin(arr,9)<<endl;

    cout<<"Second Min value is : "<<findSecondMin(arr,9)<<endl;

    cout<<"Second max value is : "<<findSecondMax(arr,9)<<endl;

    cout <<"checking if value "<<temp<<" is  present "<<(CheckIfPresent(arr,9,temp))<<endl;
   
    return 0;
}