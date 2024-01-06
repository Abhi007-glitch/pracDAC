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

    fin.seekg(0, std::ios::end);
    long pos = fin.tellg();
    std::cout << "File had - " << (pos / sizeof(int)) << " integers.\n";

    int no;
    int i = 0;
    fin.seekg(i * sizeof(int), std::ios::beg);
    fin.read(reinterpret_cast<char*>(&no), sizeof(no));
    while (!fin.eof()) {
        std::cout << no << "\n";

        i += 2;
        fin.seekg(i * sizeof(int), std::ios::beg);
        fin.read(reinterpret_cast<char*>(&no), sizeof(no));
    }

    return 0;
}