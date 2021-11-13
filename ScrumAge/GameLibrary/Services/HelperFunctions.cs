using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Models;

namespace GameLibrary.Services
{
    public class HelperFunctions
    {
        public static int TotalNumResources(Dictionary<Resources, int> numResources)
        {
            int total = 0;

            Resources[] resources = { Resources.Coffee, Resources.USB_Sticks,
                                      Resources.CPU_Cores, Resources.Power };
            foreach (Resources resource in resources)
            {
                if (numResources.ContainsKey(resource))
                    total += numResources[resource];
            }

            return total;
        }
    }
}
