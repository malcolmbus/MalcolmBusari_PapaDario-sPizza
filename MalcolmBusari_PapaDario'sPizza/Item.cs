using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalcolmBusari_PapaDario_sPizza
{
    abstract class Item
    {
        public static int generateOrderNumber()
        {
            Random rnd = new Random();
            int orderNo = rnd.Next(1000, 5000);
            return orderNo;
        }

        public abstract void DeleteTable(string connectionString);
    }
}
