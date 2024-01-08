#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Course;
class Student;

class Student
{
  static int student_id_counter;

private:
  int roll_no;
  string name;
  string mobileNo;
  vector<int> enrolledCourse;

public:
  // Constructor
  Student()
  {
  }

  Student(string name, string mobileNo)
  {
    this->roll_no = student_id_counter++;
    this->name = name;
    this->mobileNo = mobileNo;
  }

  // Getters
  // getRollNo

  int getRollNo()
  {
    return this->roll_no;
  }

  // getName
  string getName()
  {
    return this->name;
  }

  // getMobile
  string getNumber()
  {
    return this->mobileNo;
  }

  // getAllCourse
  vector<int> getAllEnrolledCourse()
  {
    return this->enrolledCourse;
  }

  // setter if required

  // enrolling into new course
  void enrollToCourse(int id)
  {
    this->enrolledCourse.push_back(id);
  }
};

int Student ::student_id_counter = 0;

class Course
{

  static int course_id_counter;

private:
  int course_id;
  string courseName;
  int fees;
  vector<int> enrolledStudents;

public:
  // constructor
  Course()
  {
  }

  Course(string courseName, int fees)
  {
    this->courseName = courseName;
    this->course_id = course_id_counter++;
    this->fees = fees;
  }

  // get CourseId

  int getCourseId()
  {
    return this->course_id;
  }

  // getCourseName
  string getCourseName()
  {
    return this->courseName;
  }

  // getCourseFee
  int getCourseFees()
  {
    return this->fees;
  }

  // 
  vector<int> getAllEnrolledStudent()
  {
    return this->enrolledStudents;
  }

  //setter

  // adding a studen to the course 

  void addStudent(int id)
  {
    this->enrolledStudents.push_back(id);
  }

};

int main()
{

  vector<Student>* students =  new vector<Student>();
  vector<Course>* courses= new vector<Course>();
  bool flag=false;
  int option;
  while(!flag)
  {
   
   cout<<"1. Register a student "<<endl;
   cout<<"2. Add a new Course"<<endl;
   cout<<"3. Enroll to course"<<endl;
   cout<<"4. Get Student Course Details "<<endl;
   cout<<"5. Get Course's students Details"<<endl;
   cout<<"6. End the Program "<<endl;
   cout<<"7. Write Details to the file "<<endl;
  cin>>option;
  
  string name;
  string mobileNo;
  int fees;
  int studentId;
  int courseId;
  vector<Student>::iterator stuItr;
  vector<Course>::iterator courItr;

  switch(option)
  {

    case 1:
    //Student(string name, string mobileNo)
       cout<<"Enter name and mobile No"<<endl;
       cin>> name;
       cin>> mobileNo;
       Student *s = new Student(name,mobileNo);
       students->push_back(*s);
       break;

    case 2:  
        cout<<"Enter Course name and fees"<<endl;
       cin>> name;
       cin>> fees;
       Course *c = new Course(name,fees);
       courses->push_back(*c);  
     break;
      
    case 3:
       cout<<"Enter Student id"<<endl;
       cin>>studentId;
       stuItr = find(students->begin(),students->end(),studentId);
       if (stuItr==students->end())
       {
        cout<<"Enter a valid student id "<<endl;
        break;
       }

       for (int i =0;i<courses->size();i++)
       {
        cout<<(*courses)[i].getCourseId()<<". "<< (*courses)[i].getCourseName()<<endl;
       }
      cout<<"Enter selected course id: ";
      cin>>courseId;
      Student curStudent = (*students)[stuItr-students->begin()];
      curStudent.enrollToCourse(courseId);
      (*courses)[courseId].addStudent(curStudent.getRollNo());
      break;

    case 4:
      break;
    
    case 5:
     break;
    
    case 6:
      break;

    default:
        break;
  }

  return 0;
}