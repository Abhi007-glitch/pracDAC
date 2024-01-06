#include <iostream>
#include <fstream>

int main(int argc, char *argv[]) {
    if (argc != 2) {
        std::cout << "Usage: " << argv[0] << " <filename>\n";
        return 1;
    }

    std::ifstream fin(argv[1], std::ios::binary);
    if (!fin) {
        std::cout << "Failed to open file " << argv[1] << " for reading.\n";
        return 2;
    }

    int no;
    fin.read(reinterpret_cast<char*>(&no), sizeof(no));
    while (!fin.eof()) {
        std::cout << no << "\n";
        fin.read(reinterpret_cast<char*>(&no), sizeof(no));
    }

    return 0;
}