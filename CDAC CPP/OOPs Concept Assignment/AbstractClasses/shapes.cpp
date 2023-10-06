#include<iostream>
using namespace std;


struct point
{
int x;
int y;
};


class Object {
    protected:
       point pt[2];
    public:
    Object()
    {
        cout<<"Default constructor of object class got called"<<endl;
    }
    Object(int x1,int y1,int x2, int y2)
    {
         this->pt[0].x=x1;
        this->pt[0].y=y1;
        this->pt[1].x=x2;
        this->pt[1].y=y2;
    }

    ~Object()
    {
        cout<<"destuructor of Object got called "<<endl;
    }

    void move(int x, int y)
    {
        cout<<"Logic to move a object based on x and y axis co-ordinate changes"<<endl;
    }

    void Draw()
    {
        cout<<"Drawing Object type object "<<endl;
    }

};



class Line : public Object {
     
  
    Line(int x1, int y1, int x2, int y2) : Object(x1,y1,x2,y2)
    {
        cout<<"Line Constructor got called and parameterized constructor of Object class got called"<<endl;
    }
    ~Line()
    {
        cout<<"Line destructor got called "<<endl;
    };

};

class Rect : public Object{
    

    Rect(int x1, int y1,int x2, int y2)
    {
        this->pt[0].x=x1;
        this->pt[0].y=y1;
        this->pt[1].x=x2;
        this->pt[1].y=y2;
    };

    ~Rect()
    {
        cout<<"Rectangle Destructor got called "<<endl;
    };
};


