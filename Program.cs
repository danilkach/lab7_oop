using System;
using System.Net.Sockets;

namespace lab7_oop
{
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

        public string getType() { return this.type; }
        public double getRemains() { return this.remains; }
        private string type;
        private string second_name;
        private string number;
        private double remains;
    };
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите количество счетов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Account[] accs = new Account[n];
            for(int i = 0; i < n; i++)
            {
                accs[i] = new Account();
                accs[i].read();
            }
            Console.Write("Введите остаток для проверки: ");
            double rem = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите тип счета: ");
            Console.WriteLine("Найденные счета: ");
            string type = Console.ReadLine();
            for(int i = 0; i < n; i++)
                if(accs[i].getType() == type && accs[i].getRemains() < rem)
                    accs[i].display();
        }
    }
}