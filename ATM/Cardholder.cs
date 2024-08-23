using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATM
{
   public class Cardholder
    {
        private string _firstname;
        private string _lastname;
        private string _cardnumber;
        private int _pin;
        private double _balance;
        private string _phoneNumber;
        public Cardholder(string firstname, string lastname,string cardNum, int pin, double balance, string phonenumber)
        {
            _firstname = firstname;
                _lastname = lastname;
                _pin = pin;
                _balance = balance;
            _cardnumber = cardNum;
            _phoneNumber = phonenumber;
        }
        public string getFirstname()
        {
            return _firstname;
        }
        public void SetFirsName(string firsName)
        {
            _firstname = firsName;
        }
        public string getLastName()
        {
            return _lastname;
        }
        public void setLastName(string lastName)
        {
            _lastname = lastName;
        }
        public string getCardNumber()
        {
            return _cardnumber;
        }
        public void setCardNumber(string CardNum)
        {
            _cardnumber = CardNum;
        }
        public double getBalance()
        {
            return _balance;
        }
        public void SetBalance(double balance)
        {

        _balance = balance; 
        }
        public int getPin()
        {
            return _pin;
        }
        public void setPin(int pin)
        {
            _pin= pin;
        }
        public void setPhonenumber(string phone)
        {
            _phoneNumber = phone;
        }
        public string getnumber()
        {
            return _phoneNumber;
        }
    }
    public class Atm
    {
        public void printOption()
        {
            Console.WriteLine("Please enter any of the option");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3.Check Balance");
            Console.WriteLine("4. Reset pin");
            Console.WriteLine("5. exit");
        }
        public void Deposit(Cardholder cardHolder)
        {
            Console.WriteLine("Please deposit the Desire Amount");
            double amount=double.Parse(Console.ReadLine());
            if (amount > 0)
            {
                //cardHolder.SetBalance(amount);
                //Console.WriteLine($"Amount Deposited successfully, your new balance is {cardHolder.getBalance()}");
                cardHolder.SetBalance(cardHolder.getBalance() + amount); Console.WriteLine($"amount deposited successfully , your new balance is {cardHolder.getBalance()}");
            }
            else
            {
                Console.WriteLine("please Deposit the valid amount");
            }
        }
        public void Withdraw(Cardholder cardHolder)
        {
            Console.WriteLine("Please enter required amount to withdraw");
            double withDrawamount =double.Parse(Console.ReadLine());
            if (cardHolder.getBalance() < withDrawamount)
            {
                Console.WriteLine("Insufficient balance, please try again");
            }
            else
            {
                double newbalance=cardHolder.getBalance()-withDrawamount;
                cardHolder.SetBalance(newbalance);
                Console.WriteLine("Successfully withdarw, your new balance is : {0}",cardHolder.getBalance());

            }
        }
        public void BalanceInquiry(Cardholder cardHolder)
        {
           Console.WriteLine("Your good balance is {0}",cardHolder.getBalance());
        }
        public void WelcomeMsg()
        {
            List<Cardholder> cardHolders = new List<Cardholder>();
            cardHolders.Add(new Cardholder("adarsa", "gaire", "9897758767487878", 1234, 1000.00,"9867543210"));
            cardHolders.Add(new Cardholder("pujan", "gaire", "8978976377368236", 2067, 2675372.89,"9845674321"));
            cardHolders.Add(new Cardholder("bibek", "Ghimire", "73647367468483", 2345, 627357623.897,"9875789650"));
            cardHolders.Add(new Cardholder("suman", "shrestha", "6776537238274684", 3766, 26735267356727.82739,"9865743280"));
            cardHolders.Add(new Cardholder("Saroj", "Bhandari", "6473847844890", 6357, 330000,"9748748051"));
            Console.WriteLine("Welcome to ABC ATM");
            Console.WriteLine("Please enter your debit card number");
            string cardNumber = "";
            Cardholder currentUser;
            while (true)
            {
                try
                {
                    cardNumber = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(card => card.getCardNumber() == cardNumber);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Card Number,Please try again");
                    }
                } catch
                {
                    Console.WriteLine("Invalid card Number ,Please try again");
                }
            }
            Console.WriteLine("Please enter your pin");
            int pin = 0;
            int i = 0;
            while (i<3)
            {

                try
                {
                    pin = int.Parse(Console.ReadLine());
                    //currentUser = cardHolders.FirstOrDefault(card => card.getPin() == pin);
                    if (currentUser.getPin() == pin)
                    {
                        break;
                    }
                    else
                    {
                        i++;
                        Console.WriteLine($"Invalid Pin, Please try again attempt no. {i}");
                        Console.WriteLine("You can attempt only for 3 times");
                    }
                }
                catch
                {
                    i++;
                    Console.WriteLine($"Invalid Pin, Please try again,attempt no. {i}");
                    Console.WriteLine("You can only put number in Pin");
                    Console.WriteLine("You can attempt only for 3 times");
                }
            }
            if(i==3)
            {
                A:
                Console.WriteLine("You have attempted for more than 3 times please reset your pin!");
                string number = "0";
                Console.WriteLine("Enter your phone number to reset the pin");
                number=Console.ReadLine();
                if(number==currentUser.getnumber())
                {
                 forgetpin(currentUser);
                }
                else
                {
                    Console.WriteLine("Your number is not matched please try again!");
                    goto A;
                }
            }
            Console.WriteLine($"Welcome {currentUser.getFirstname()}");
            int option = 0;
            do
            {
                printOption();
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Deposit(currentUser);
                        break;
                    case 2:
                        Withdraw(currentUser);
                        break;
                    case 3:
                        BalanceInquiry(currentUser);
                        break;
                    case 4:
                        resetpin(currentUser);
                        break;
                    case 5:
                        Console.WriteLine("------------------------Thank You for using our service!-------------------------------------------");
                        break;
                    default:
                        break;
                }
            } while ( option != 5);
           
          
        }
        public void resetpin(Cardholder cardHolder)
        {
            try
            {
                Console.WriteLine(" Please enter the previous pin");
                int Currentpin = int.Parse(Console.ReadLine());
                if(Currentpin == cardHolder.getPin())
                {
                    Console.WriteLine("please enter your new pin");
                    int newPin = int.Parse(Console.ReadLine());
                    Console.WriteLine("verify you new pin");
                    int verifyPin = int.Parse(Console.ReadLine());
                    if(newPin==verifyPin)
                    {
                        cardHolder.setPin(newPin);
                        Console.WriteLine($"pin reset successfull, your new pin is {cardHolder.getPin()}");
                    }
                    else
                    {
                        Console.WriteLine("pin do not match, try again");
                    }
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine($"pin do not match, try again and {ex.Message}");
            }
        }
        public void forgetpin(Cardholder cardHolder)
        {
            B:
            Console.WriteLine("please enter your new pin");
            int newPin = int.Parse(Console.ReadLine());
            Console.WriteLine("verify you new pin");
            int verifyPin = int.Parse(Console.ReadLine());
            if (newPin == verifyPin)
            {
                cardHolder.setPin(newPin);
                Console.WriteLine($"pin reset successfull, your new pin is {cardHolder.getPin()}");
            }
            else
            {
                Console.WriteLine("pin do not match, try again");
                goto B;
            }
        }
    }
}
