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
        public double total(int index)
        {
            double result = 0;
            for (int i = 0; i < 3; i++)
                result += accs[i].getRemains(index);
            return result + additional;
        }

        public void read(int index)
        {
            for(int i = 0; i < 3; i++)
                accs[i].read(index);
        }
        public string maxAccount(int index)
        {
            Account max = accs[0];
            if (accs[1].getRemains(index) > max.getRemains(index))
                max = accs[1];
            if (accs[2].getRemains(index) > max.getRemains(index))
                max = accs[2];
            return max.getNumber(index);
        }
        private double additional = 0;
        private Account[] accs = new Account[3];
    }
    class Account
    {
        public Account()
        {
            type = new string[arraySize];
            second_name = new string[arraySize];
            number = new string[arraySize];
            remains = new string[arraySize];
            typeAm = nameAm = remainsAm = numberAm = 0;
        }
        public void read(int index)
        {
            Console.Write("Введите тип счета: ");
            this.type[index] = Console.ReadLine();
            Console.Write("Введите номер счета: ");
            this.number[index] = Console.ReadLine();
            Console.Write("Введите фамилию владельца: ");
            this.second_name[index] = Console.ReadLine();
            Console.Write("Введите остатки на счете: ");
            this.remains[index] = Console.ReadLine();
            typeAm++;
            numberAm++;
            nameAm++;
            remainsAm++;
        }
        public void display() { Console.WriteLine("Тип счета: {0}\nНомер счета: " + 
        "{1}\nФамилия владельца: {2}\nОстатки на счете: {3}", this.type, this.number, this.second_name, this.remains); }

        public Account Add(Account a1, Account a2, int index1, int index2)
        {
            Account result = new Account();
            result.second_name[0] = a1.second_name[index1];
            result.type[0] = a1.type[index1];
            result.remains[0] = a1.remains[index1] + a2.remains[index2];
            result.number[0] = a1.number[index1].Substring(0, a1.number[index1].Length / 2)
                            + a2.number[index2].Substring(a2.number[index2].Length - a2.number[index2].Length / 2);
            return result;
        }

        void init(string type, string second_name, string number, string remains, int index)
        {
            this.type[index] = type;
            this.second_name[index] = second_name;
            this.number[index] = number;
            this.remains[index] = remains;
            typeAm++;
            numberAm++;
            nameAm++;
            remainsAm++;
        }
        public bool insert(string value, int index, String field)
        {
            int arrayAmount;
            string[] array;
            if(field == "type") {
                arrayAmount = typeAm;
                array = this.type;
            }
            else if(field == "number") {
                arrayAmount = numberAm;
                array = this.number;
            }
            else if (field == "remains")
            {
                arrayAmount = remainsAm;
                array = this.remains;
            }
            else if (field == "name")
            {
                arrayAmount = nameAm;
                array = this.second_name;
            }
            else return false;
            if(index > arrayAmount)
                if(arrayAmount == arraySize)
                    return false;
            bool exCaught = false;
            try
            {
                string a = array[index];
            }
            catch(Exception e)
            {
                array[arraySize + 1] = value;
                exCaught = true;
            }
            if(exCaught)
                if(field == "type")
                {
                    typeAm++;
                }
                else if(field == "number")
                {
                    numberAm++;
                }
                else if (field == "remains")
                {
                    remainsAm++;
                }
                else if (field == "name")
                {
                    nameAm++;
                }
            return true;
        }
        public string getType(int index) { return this.type[index]; }
        public double getRemains(int index) { return Convert.ToDouble(this.remains[index]); }
        public string getNumber(int index) { return this.number[index]; }
        public void setNumber(string value, int index) { this.number[index] = value; }
        private string[] type;
        private string[] second_name;
        private string[] number;
        private string[] remains;
        private static int typeAm;
        private static int nameAm;
        private static int numberAm;
        private static int remainsAm;
        private const int arraySize = 100;
    };
    internal class Program
    {
        public static void Main(string[] args)
        {
            Bank vtb = new Bank();
            vtb.read(0);
            vtb.setAdditional(500000);
            Account p1 = new Account(), p2 = new Account();
            p1.read(0);
            p2.read(0);
            p1.setNumber("12345678", 0);
            Console.WriteLine(p1.getNumber(0));
            Console.WriteLine("Total babok v banke = {0}", vtb.total(0));
            Console.WriteLine("Max account is " + vtb.maxAccount(0));
        }
    }
}