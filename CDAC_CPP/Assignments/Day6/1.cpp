#include <iostream>
using namespace std;

    void swap(int& a, int& b) {
        int temp = a;
        a = b;
        b = temp;
    }
    
    void swap(float& a, float& b) {
        float temp = a;
        a = b;
        b = temp;
    }
    
    void swap(char& a, char& b) {
        char temp = a;
        a = b;
        b = temp;
    }


int main() {
    int a = 5, b = 10;
    swap(a, b);
    cout << "Swapped integers: a = " << a << ", b = " << b << std::endl;
    
    float x = 3.14, y = 2.71;
    swap(x, y);
    cout << "Swapped floats: x = " << x << ", y = " << y << std::endl;
    
    char c1 = 'A', c2 = 'B';
    swap(c1, c2);
    cout << "Swapped characters: c1 = " << c1 << ", c2 = " << c2 << std::endl;
    
    return 0;
}
