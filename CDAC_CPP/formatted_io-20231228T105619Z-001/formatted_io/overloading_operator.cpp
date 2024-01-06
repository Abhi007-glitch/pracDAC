#include <iostream>

class X {
    int a;
    int b;
public:
    X() : a(0), b(0) {
    }

    friend std::istream& operator>>(std::istream& in, X& obj);
    friend std::ostream& operator<<(std::ostream& out, const X& obj);
};

std::istream& operator>>(std::istream& in, X& obj) {
    in >> obj.a >> obj.b;
    return in;
}

std::ostream& operator<<(std::ostream& out, const X& obj) {
    out << "(" << obj.a << ", " << obj.b << ")";
    return out;
}

int main() {
    X objX;

    std::cout << "Enter two integers for X - ";
    std::cin >> objX;

    std::cout << "You entered - " << objX << "\n";

    return 0;
}