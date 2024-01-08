#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Student
{
  static int roll_no_counter;

private:
  string name;
  int roll_no;
  string mobile_no;
  StudentTOCouse SC;

public:
  Student(string name, string mobile_no)
  {
    this->roll_no = roll_no_counter++;
    this->name = name;
    this->mobile_no = mobile_no;
    this->SC = StudentTOCouse(roll_no);
  }
  Student()
  {
  }
  vector<Course> getCourses()
  {
    return SC.getEnrollerdCousers();
  }
  int getStudentId()
  {
    return this->roll_no;
  }

  friend ostream &operator<<(ostream &os, Student s);
};

ostream &operator<<(ostream &os, Student s)
{
  os << "[";
  os << "Roll_no : " << s.roll_no << " Name: " << s.name << " phone_no: " << s.mobile_no << "\n";
  return os;
}

int Student ::roll_no_counter = 0;

class Course
{
  static int course_id_counter;

private:
  string course_name;
  int course_id;
  int fees;
  CourseToStudent CS;

public:
  Course(string course_name, int fees)
  {
    this->course_id = course_id_counter++;
    this->course_name = course_name;
    this->fees = fees;
    this->CS = CourseToStudent(course_id);
  }
  Course()
  {
  }

  friend ostream &operator<<(ostream &os, Course s);
};

ostream &operator<<(ostream &os, Course c)
{
  os << "[";
  os << "Couser id : " << c.course_id << " Name: " << c.course_name << " fees: " << c.fees << "\n";
  os << "]";
  return os;
}
int Course::course_id_counter = 0;

class StudentTOCouse
{
  int id;
  vector<Course> courses;

public:
  StudentTOCouse(int id)
  {
    this->id = id;
  }

  StudentTOCouse()
  {
  }

  void AddCouser(Course s)
  {
    courses.push_back(s);
  }

  vector<Course> getEnrollerdCousers()
  {
    return courses;
  }
  void evictFromCouser(Course s)
  {
    vector<Course>::iterator it;
    it = find(courses.begin(), courses.end(), s);

    if (it != courses.end())
    {
      courses.erase(it);
    }
    else
    {
      cout << "No such course enrolled !!" << endl;
    }
  }

  friend ostream &operator<<(ostream &os, StudentTOCouse SC);
};

ostream &operator<<(ostream &os, StudentTOCouse SC)
{
  for (Course c : SC.courses)
  {
    cout << c << " ,";
  }
  return os;
}

class CourseToStudent
{
  int course_id;
  vector<Student> students;

public:
  CourseToStudent()
  {
  }

  CourseToStudent(int course_id)
  {
    this->course_id = course_id;
  }

  friend ostream &operator<<(ostream &os, CourseToStudent CS);

  void AddStudentToCourse(Student s)
  {
    this->students.push_back(s);
  }

  void evictStudentFromCourse(int student_id)
  {
    vector<Student>::iterator it;

    it = find_if(students.begin(), students.end(), [student_id](Student curStudent)
                 { return curStudent.getStudentId() == student_id; });

    if (it != students.end())
    {
      cout << "No such student find with given id found in the course!!" << endl;
    }
    else
    {
      students.erase(it);
      cout << "Successfully evicted student form the course !! " << endl;
    }
  }
};

ostream &operator<<(ostream &os, CourseToStudent CS)
{
  for (Student s : CS.students)
  {
    os << s << "\n";
  }
  return os;
}

void addStudentToCourse(Student s, Course course_id)
{
}

int main()
{

  Course c1("DAC", 108000);
  Course c2("DAI", 175000);
  Course c3("HPC", 10000);

  Student s1("Abhianv", "7999656632");
  Student s2("Abhishek", "7999656632");
  Student s3("Jatin", "7999656632");
  Student s4("Yatin", "7999656632");
  Student s5("Vaibhav", "7999656632");
  Student s6("Valay", "7999656632");

  return 0;
}