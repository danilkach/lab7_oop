using System;
using System.Net.Sockets;

namespace lab7_oop
{
    class Bank
    {
        public Bank()
        {
            for(int i = 0; i < 3; i++) 
                accs[i] = new Account();
        }

        public void setAdditional(double sum) { additional = sum; }
        public double total()
        {
            double result = 0;
            for (int i = 0; i < 3; i++)
                result += accs[i].getRemains();
            return result;
        }

        public void read()
        {
            for(int i = 0; i < 3; i++)
                accs[i].read();
        }
        public string maxAccount()
        {
            Account max = accs[0];
            if (accs[1].getRemains() > max.getRemains())
                max = accs[1];
            if (accs[2].getRemains() > max.getRemains())
                max = accs[2];
            return max.getNumber();
        }
        private double additional = 0;
        private Account[] accs = new Account[3];
    }
    class Account
    {
        public void read()
        {
            Console.Write("Введите тип счета: ");
            this.type = Console.ReadLine();
            Console.Write("Введите номер счета: ");
            this.number = Console.ReadLine();
            Console.Write("Введите фамилию владельца: ");
            this.second_name = Console.ReadLine();
            Console.Write("Введите остатки на счете: ");
            this.remains = Convert.ToDouble(Console.ReadLine());
        }
        public void display() { Console.WriteLine("Тип счета: {0}\nНомер счета: " + 
        "{1}\nФамилия владельца: {2}\nОстатки на счете: {3}", this.type, this.number, this.second_name, this.remains); }

        public static Account Add(Account a1, Account a2)
        {
            Account result = new Account();
            result.second_name = a1.second_name;
            result.type = a1.type;
            result.remains = a1.remains + a2.remains;
            result.number = a1.number.Substring(0, a1.number.Length / 2)
                            + a2.number.Substring(a2.number.Length - a2.number.Length / 2);
            return result;

        }

        void init(string type, string second_name, string number, double remains)
        {
            this.type = type;
            this.second_name = second_name;
            this.number = number;
            this.remains = remains;
        }
        public string getType() { return this.type; }
        public double getRemains() { return this.remains; }
        public string getNumber() { return this.number; }
        private string type;
        private string second_name;
        private string number;
        private double remains;
    };
    internal class Program
    {
        public static void Main(string[] args)
        {
            Bank vtb = new Bank();q
            vtb.read();
            vtb.setAdditional(500000);
            Console.WriteLine("Total babok v banke = {0}", vtb.total());
            Console.WriteLine("Max account is " + vtb.maxAccount());
        }
    }
}