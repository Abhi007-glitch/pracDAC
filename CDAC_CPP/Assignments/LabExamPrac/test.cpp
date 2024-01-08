#include <iostream>
#include <string>
using namespace std;

class Account
{
private:
    int accountnumber;
    int accountbalance = 0;
    char accountname[20];
    char accounttype;

public:
    static int accountcount;
    void addaccount();
    void withdraw();
    void deposit();
    void displayall();
    // void displayindi();
};

int Account::accountcount = 0;

void Account::addaccount()
{
    accountcount++;
    accountnumber = accountcount;
    cout<<"Account number is :"<<accountnumber;
    cout << "\nEnter Account name: ";
    cin >> accountname;
    cout << "\nEnter Account Type (C for Current, S for Savings): ";
    cin >> accounttype;
    if (accounttype == 'c' || accounttype == 'C')
    {
        accountbalance = 1000;
    }
    else if (accounttype == 's' || accounttype == 'S')
    {
        accountbalance = 0;
    }
    else
    {
        cout << "Invalid account type. Defaulting to Savings." << endl;
        accountbalance = 0;
    }
}

void Account::withdraw()
{
    int n;
    cout << "Enter the amount to be withdrawn: ";
    cin >> n;
    if (n > 0 && n <= accountbalance)
    {
        accountbalance -= n;
        cout << "Withdrawal successful." << endl;
    }
    else
    {
        cout << "Invalid amount or insufficient balance." << endl;
    }
}

void Account::deposit()
{
    int n;
    cout << "Enter the amount to be deposited: ";
    cin >> n;
    if (n > 0)
    {
        accountbalance += n;
        cout << "Deposit successful." << endl;
    }
    else
    {
        cout << "Invalid amount." << endl;
    }
}

void Account::displayall()
{
    cout << "Account number: " << accountnumber << endl;
    cout << "Account name: " << accountname << endl;
    cout << "Balance in the account: " << accountbalance << endl;
}

int main()
{
    Account a[100];
    int n, num = 0, i = 0; // Initialize i to 0
    do
    {
        cout << "\n1.Add Account\n2.Withdraw\n3.Deposit\n4.Display all Account Details\n5.Display Individual Account Details\n6.Exit";
        cout << "\nEnter Your Choice: ";
        cin >> n;

        switch (n)
        {
        case 1:
            cout << "Enter 1.Add users 0.Quit Adding Accounts: ";
            cin >> num;
            while (num != 0)
            {
                a[i].addaccount();
                i++;
                cout << "Enter 1.Add users 0.Quit Adding Accounts: ";
                cin >> num;
            }
            break;
        case 2:
            cout << "Enter the account number to withdraw: ";
            int accNum;
            cin >> accNum;
            if (accNum >= 1 && accNum <= i)
            {
                a[accNum - 1].withdraw();
            }
            else
            {
                cout << "Account doesn't exist. Cannot withdraw." << endl;
            }
            break;
        case 3:
            cout << "Enter the account number to deposit money: ";
            int accNumDeposit;
            cin >> accNumDeposit;
            if (accNumDeposit >= 1 && accNumDeposit <= i)
            {
                a[accNumDeposit - 1].deposit();
            }
            else
            {
                cout << "Account doesn't exist. Cannot deposit." << endl;
            }
            break;
        case 4:
            for (int j = 0; j < i; j++)
            {
                a[j].displayall();
            }
            break;
        // case 5:
        //     a.displayindi();
        //     break;
        default:
            cout << "\nInvalid input\n";
        }
    } while (n != 6);

    return 0;
}
