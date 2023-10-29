using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul8_dom
{
    public class UtilityBill
    {
        public decimal heatingRate { get; set; }
        public decimal waterRate { get; set; }
        public decimal gasRate { get; set; }
        public decimal repairRate { get; set; }

        public decimal area { get; set; }
        public int residents { get; set; }
        public Season season { get; set; }
        public Discount discount { get; set; }

        public UtilityBill(decimal area, int residents, Season season, Discount discount)
        {
            heatingRate = 3.50m;
            waterRate = 4.00m;
            gasRate = 2.75m;
            repairRate = 1.50m;

            this.area = area;
            this.residents = residents;
            this.season = season;
            this.discount = discount;
        }

        public List<BillItem> CalculateBills()
        {
            var bills = new List<BillItem>();

            decimal heatingCharge = (season == Season.Осень || season == Season.Зима) ? heatingRate * 2.2m * area : heatingRate * area;
            decimal waterCharge = waterRate * residents;
            decimal gasCharge = gasRate * residents;
            decimal repairCharge = repairRate * area;

            bills.Add(new BillItem("Отопление", heatingCharge, CalculateDiscount(heatingCharge)));
            bills.Add(new BillItem("Вода", waterCharge, CalculateDiscount(waterCharge)));
            bills.Add(new BillItem("Газ", gasCharge, CalculateDiscount(gasCharge)));
            bills.Add(new BillItem("Текущий ремонт", repairCharge, CalculateDiscount(repairCharge)));

            return bills;
        }

        private decimal CalculateDiscount(decimal amount)
        {
            switch (discount)
            {
                case Discount.Ветеран_трудa:
                    return amount * 0.30m;
                case Discount.Ветеран_войны:
                    return amount * 0.50m;
                default:
                    return 0m;
            }
        }
    }

}
