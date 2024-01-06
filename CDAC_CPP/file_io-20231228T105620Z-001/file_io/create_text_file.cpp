#include <iostream>
#include <fstream>

int main(int argc, char *argv[]) {
    if (argc != 2) {
        std::cout << "Usage: " << argv[0] << " <filename>\n";
        return 1;
    }

    std::ofstream fout(argv[1]);
    if (!fout) {
        std::cout << "Failed to create file " << argv[1] << "\n";
        return 2;
    }

    int no;
    std::cout << "Enter numbers to write to file (0 to stop): ";
    std::cin >> no;
    while (no != 0) {
        fout << no << "\n";
        std::cin >> no;
    }

    return 0;
}