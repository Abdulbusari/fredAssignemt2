using System.ComponentModel;
using System.Text;

namespace FredCarparl
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int capacity = 6;

            Dictionary<int, string> carpark = InitializeCarPark(capacity);
            int addcar = AddVehicle(carpark, "HGF-DSS");
            Console.WriteLine(VacateStall(carpark, addcar));
            Console.WriteLine(LeaveParkade(carpark, "HGF-DSS"));
            Console.WriteLine(Manifest(carpark));
            
        }

       static Dictionary<int, string?> InitializeCarPark(int capacity)
        {
            var carPark = new Dictionary<int, string?>();
            for(int i = 0; i < capacity; i++)
            {
                carPark.Add(i, null);
            }
            return carPark;
        }
        static int AddVehicle(Dictionary<int, string?> carPark, string license)
        {
            int slotnum = 0;
            foreach(KeyValuePair<int, string?> pair in carPark)
            {
                if(pair.Value == null)
                {
                    carPark[pair.Key] = license;
                    slotnum = pair.Key;
                }
            }
            return slotnum;
        }
        static bool VacateStall(Dictionary<int, string?> carPark, int stallNumber)
        {
            bool result = false;
            foreach(KeyValuePair<int, string?> pair in carPark)
            {
                if(pair.Key == stallNumber && pair.Value != null)
                {
                    result = true;
                }else
                {
                   result= false;
                }
            } 
            return result;
        }
        static bool LeaveParkade(Dictionary<int, string?> carPark, string licenseNumber)
        {
            bool result = false;

            foreach( KeyValuePair<int, string?> pair in carPark)
            {
                if (pair.Value == licenseNumber)
                {
                    carPark[pair.Key] = null;
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        static string Manifest(Dictionary<int, string?> carPark)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach(KeyValuePair<int, string?> pair in carPark)
            {
                stringBuilder.Append($"stall number{pair.Key} has car{pair.Value}\n");
            }
            return stringBuilder.ToString();
        }
    }
}