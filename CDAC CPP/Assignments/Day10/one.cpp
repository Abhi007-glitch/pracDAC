#include <iostream>

#include <cstring> 
using namespace std;
class String {
public:
  // Default constructor
  String() : data(nullptr), length(0) {}

  // Copy constructor
  String(const String& other) : data(nullptr), length(other.length) {
    if (other.data != nullptr) {
      data = new char[length + 1];
      strcpy(data, other.data);
    }
  }
   void setData(const char* newData) {
    delete[] data;
    length = strlen(newData);
    data = new char[length + 1];
    strcpy(data, newData);
  }
  void display(){
      for(int i=0;i<length;i++){
          cout<<data[i];
      }
  }
  // Destructor
  ~String() {
    delete[] data;
  }

private:
  char* data;
  int length;
};
int main(){
   String s1;
   s1.setData("hello");
   s1.display();
    return 0;
}