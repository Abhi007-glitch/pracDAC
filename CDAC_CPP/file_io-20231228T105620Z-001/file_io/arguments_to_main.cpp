#include <iostream>

int main(int argc, char* argv[], char *env[]) {
    std::cout << "\nCommand line arguments are ...\n";
    for (int i = 0; i < argc; ++i) {
        std::cout << argv[i] << "\n";
    }

    std::cout << "\nEnvironment variables are ...\n";
    int i = 0;
    while (env[i]) {
        std::cout << env[i] << "\n";
        ++i;
    }

    return 0;
}