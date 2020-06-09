using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SubCalcUdregning
{
    class Program
    {
        static void Main(string[] args)
        {
            String WantedHosts = "2";
            String WantedSubs = "5";
            int calcedsubs;
            int intsubs = int.Parse(WantedSubs);
            int intHosts = int.Parse(WantedHosts) + 2;
            
            if (WantedHosts != null || WantedSubs != null)
            {
                Double subSearch = 0;
                for (int i = 0; i < intsubs; i++)
                {
                    subSearch = Math.Pow(2, i);
                    if (subSearch >= intsubs)
                    {
                        Console.WriteLine("Amount of possible subnets: {0}", subSearch);
                        calcedsubs = Convert.ToInt32(subSearch);
                        break;
                    }
                }

                Double hostSearch = 0;
                for (int i = 0; i <= intHosts; i++)
                {
                    hostSearch = Math.Pow(2, i);
                    if (hostSearch >= intHosts)
                    {
                        Console.WriteLine("Amount of possible Hosts: {0}", hostSearch);
                        break;
                    }
                }

                SubnetMaskFromSubs(Convert.ToString(subSearch));
                SubnetMaskFromHosts(Convert.ToString(hostSearch));
            }

            Console.ReadLine();
        }

        public static string SubnetMaskFromSubs(string SubMask)
        {
            string subnetmask = string.Empty;
            int calsubmask = 0;
            double result = 0;
            calsubmask = Convert.ToInt32(SubMask);

            if (!string.IsNullOrEmpty(SubMask) && calsubmask < 128)
            {
                result = (256 - (256 / calsubmask));
                double finalsubnet = result;
                subnetmask = "255.255.255." + Convert.ToString(finalsubnet);
            }
            if (!string.IsNullOrEmpty(SubMask) && calsubmask > 128 && calsubmask < 32768)
            {
                result = (256 - (calsubmask / 256));
                double finalsubnet = result;
                subnetmask = "255.255." + Convert.ToString(finalsubnet) + ".0";
            }
            if (!string.IsNullOrEmpty(SubMask) && calsubmask > 32768)
            {
                result = (256 - (calsubmask / 256 / 256));
                double finalsubnet = result;
                subnetmask = "255." + Convert.ToString(finalsubnet) + ".0.0";
            }
            Console.WriteLine("SubnetMask from subs is: " + subnetmask);
            return subnetmask;
        }

        public static string SubnetMaskFromHosts(string SubMask)
        {
            string subnetmask = string.Empty;
            int calsubmask = 0;
            double result = 0;
            calsubmask = Convert.ToInt32(SubMask);

            if (!string.IsNullOrEmpty(SubMask) && calsubmask < 256)
            {
                result = (256 - (calsubmask));
                double finalSubnet = result;
                subnetmask = "255.255.255." + Convert.ToString(finalSubnet);
            }
            if (!string.IsNullOrEmpty(SubMask) && calsubmask > 256 && calsubmask < 65536)
            {
                result = (256 - (calsubmask / 256));
                double finalSubnet = result;
                subnetmask = "255.255." + Convert.ToString(finalSubnet) + ".0";
            }
            if (!string.IsNullOrEmpty(SubMask) && calsubmask > 65536)
            {
                result = (256 - (calsubmask / 256 / 256));
                double finalSubnet = result;
                subnetmask = "255." + Convert.ToString(finalSubnet) + ".0.0";
            }
            Console.WriteLine("subnetmask from hosts is: " + subnetmask);
            return subnetmask;
        }
    }
}
       