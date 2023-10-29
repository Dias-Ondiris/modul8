using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_prak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SquaringArray sqArray = new SquaringArray(5);
            int n=10;
            do
            {
                try
                {
                    Console.WriteLine($"Пишите размер массива ");
                    n = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                }
            }
            while (true);
            for (int i = 0; i < n; i++)
            {
                do { try
                    {
                        Console.WriteLine($"Пишите {i}-элемент");
                        sqArray[i] = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch { 
                    }
                    }
                while (true);
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"sqArray[{i}] = {sqArray[i]}");
            }


            //////////////////////
            ///
            decimal area;
            int residents;
            Season season;
            Discount discount;
            do{try{Console.WriteLine($"Введите площадь помешение");
                    area = Convert.ToDecimal(Console.ReadLine());
                    break;}
                catch{}
            }while (true);
            do
            {
                try
                {
                    Console.WriteLine($"Введите число житилей");
                    residents = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch { }
            } while (true);
            do
            {
                try
                {
                    Console.WriteLine("Введите сезон (Весна, Лето, Осень, Зима):");
                    string seasonInput = Console.ReadLine();
                    if (!(seasonInput == "Весна" || seasonInput == "Лето" || seasonInput == "Осень" || seasonInput == "Зима")) continue;
                    season = (Season)Enum.Parse(typeof(Season), seasonInput); 
                    break;
                }
                catch
                {
                }
            } while (true);
            do
            {
                try
                {
                    Console.WriteLine("Введите тип льготы (Нет, Ветеран труда, Ветеран войны):");
                    string discountInput = Console.ReadLine();
                    if (discountInput == "Ветеран труда" || discountInput == "Ветеран_трудa") discountInput = "Ветеран_трудa";
                    else if(discountInput == "Ветеран войны") discountInput = "Ветеран_войны";
                    discount = (Discount)Enum.Parse(typeof(Discount), discountInput); 
                    break;
                }
                catch
                {
                }
            } while (true);
            Console.WriteLine($"{area.ToString().PadRight(15, ' ')}\t\t{residents.ToString().PadRight(15, ' ')}\t\t{season.ToString().PadRight(15, ' ')}\t\t{discount.ToString()}");
            UtilityBill bill = new UtilityBill(area: area, residents: residents, season: season, discount: discount);

            var billItems = bill.CalculateBills();
            decimal totalSum = 0m;
            Console.WriteLine("Вид платежа\t\tНачислено\t\tЛьготная скидка\t\tИтого");

            foreach (var item in billItems)
            {
                Console.WriteLine($"{item.Name.PadRight(15, ' ')}\t\t{item.Charged.ToString().PadRight(15, ' ')}\t\t{item.DiscountAmount.ToString().PadRight(15, ' ')}\t\t{item.Total}");
                totalSum += item.Total;
            }

            Console.WriteLine($"Общая сумма к оплате: {totalSum}");

            
                
            Console.ReadKey();


        }
    }
}
