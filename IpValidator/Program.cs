using System.Diagnostics.Metrics;
using System.Text;

namespace IPValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;            
            while (repeat)
            {
                Console.Write("Enter IP Address:");
                string? IPAddress = Console.ReadLine();
                if (string.IsNullOrEmpty(IPAddress))
                {                    
                    repeat = true;
                }
                else
                {
                    string isValidStr = IsValidIP(IPAddress) ? "Valid" : "Invalid";
                    Console.WriteLine("This IP Address is " + isValidStr);
                    Console.Write("Try another IP Address? Type Yes to try more:");
                    string? cont = Console.ReadLine();
                    if (string.IsNullOrEmpty(cont))
                    {
                        repeat = false;
                    }
                    else
                    {
                        if (cont.ToUpper() == "YES")
                        {
                            repeat = true;
                        }
                        else
                        {
                            repeat = false;
                        }
                    }
                }
            }                    
        }

        public static bool IsValidIP(string IPAddress)
        {
            string[] octets = IPAddress.Split('.');

            if (octets.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                int octet;
                if (octets[i].Length > 1) 
                {
                    if (octets[i][0] == '0')
                    {
                        return false;
                    }
                }                
                if (!int.TryParse(octets[i], out octet))
                {
                    return false;
                }
                if (octet < 0 || octet > 255)
                {
                    return false;
                }
            }
            return true;
        }
    }
}