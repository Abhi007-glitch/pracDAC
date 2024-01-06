// Online C++ compiler to run C++ program online
#include <iostream>
#include <string>
using namespace std;

class Date {
	int day;
	int month;
	int year;
	char date;
public:
	Date()
	{}
	Date(int day, int month, int year):day(day),month(month),year(year){
	   
	}
	void Read(){
	    cout<<"enter day"<<endl;
	    cin>>this->day;
	    cout<<"enter month"<<endl;
	    cin>>this->month;
	    cout<<"enter year"<<endl;
	    cin>>this->year;
	}
	void Write(){
	    cout<<this->day<<"/"<<this->month<<"/"<<this->year<<endl;
	}
	bool operator==(Date d2){
	    return ((day==d2.day)&&(month==d2.month)&&(year=d2.year));
	}

	Date& operator++(){
		++day;
		int maxDay = daysInMonth(month, year);
        if (day > maxDay) {
            day = 1;
            month++;
            if (month > 12) {
                month = 1;
                year++;
            }
        }
        
        return *this;
	}
    
	 int daysInMonth(int m, int y) {
        switch (m) {
            case 4: case 6: case 9: case 11:
                return 30;
            case 2:
                return (isLeapYear(y)) ? 29 : 28;
            default:
                return 31;
        }
    }
	 bool isLeapYear(int y) {
        return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
    }
};
int main() {
   Date d1;
    d1.Read();
    d1.Write();
    Date d2;
	d2.Read();
    d2.Write();
    if(d1==d2){
        cout<<"true";
    }else 
    cout<<"false";
	++d1;

    return 0;
}