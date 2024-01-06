#include <iostream>
#include <fstream>
#include <string>

int main(int argc, char *argv[]) {
    if (argc != 2) {
        std::cout << "Usage: " << argv[0] << " <filename>\n";
        return 1;
    }

    std::ifstream fin(argv[1]);
    if (!fin) {
        std::cout << "Failed to open file " << argv[1] << " for reading.\n";
        return 2;
    }

    std::cout << "File contents when reading individual characters ...\n";
    char ch;
    fin >> ch;
    while (!fin.eof()) {
        std::cout << ch;
        fin >> ch;
    }

    std::cout << "\nFile contents when reading lines ...\n";
    fin.close();
    fin.open(argv[1]);
    if (!fin) {
        std::cout << "Failed to open file " << argv[1] << " for reading.\n";
        return 3;
    }

    for (std::string line; std::getline(fin, line); ) {
        std::cout << line << "\n";
    }

   return 0;
}