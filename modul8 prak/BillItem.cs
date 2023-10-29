using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_dom
{
    public enum Season
    {
        Весна, Лето, Осень, Зима
    }

    public enum Discount
    {
        Нет, Ветеран_трудa, Ветеран_войны
    }

    public class BillItem
    {
        public string Name { get; set; }
        public decimal Charged { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Total => Charged - DiscountAmount;

        public BillItem(string name, decimal charged, decimal discountAmount)
        {
            Name = name;
            Charged = charged;
            DiscountAmount = discountAmount;
        }
    }

}
