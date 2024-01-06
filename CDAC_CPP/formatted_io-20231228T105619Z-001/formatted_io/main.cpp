#include <iostream>
#include <iomanip>

void testWidthAndFillUsingIosMember() {
    int nums1[] = {1, 200, -4, 1000, -43};
    int nums2[] = {250, -2500, 100, 2, 50000};

    std::cout << "\nNormal...\n";
    for (int i = 0; i < sizeof(nums1)/sizeof(nums1[0]); ++i) {
        std::cout << nums1[i] << " ";
    }
    std::cout << "\n";
    for (int i = 0; i < sizeof(nums2)/sizeof(nums2[0]); ++i) {
        std::cout << nums2[i] << " ";
    }
    std::cout << "\n";

    std::cout << "\nWith fixed width...\n";
    for (int i = 0; i < sizeof(nums1)/sizeof(nums1[0]); ++i) {
        std::cout.width(10);
        std::cout << nums1[i] << " ";
    }
    std::cout << "\n";
    for (int i = 0; i < sizeof(nums2)/sizeof(nums2[0]); ++i) {
        std::cout.width(10);
        std::cout << nums2[i] << " ";
    }
    std::cout << "\n";

    std::cout << "\nWith fixed width and fill...\n";
    std::cout.fill('*');
    for (int i = 0; i < sizeof(nums1)/sizeof(nums1[0]); ++i) {
        std::cout << std::setw(10) << nums1[i] << " ";
    }
    std::cout << "\n";
    for (int i = 0; i < sizeof(nums2)/sizeof(nums2[0]); ++i) {
        std::cout << std::setw(10) << nums2[i] << " ";
    }
    std::cout << "\n";
}

void testBaseUsingManipulator() {
    std::cout << "\nPrint in hex ...\n";
    std::cout << std::hex << 1234 << "\n";

    std::cout << "\nPrint in hex with show base...\n";
    std::cout << std::showbase << 1234 << "\n";
    std::cout << "\nPrint in octal with show base...\n";
    std::cout << std::oct << 1234 << "\n";

    std::cout << "\nPrint in octal ...\n";
    std::cout << 1234 << "\n";
}

int main() {
    testWidthAndFillUsingIosMember();
    testBaseUsingManipulator();
}