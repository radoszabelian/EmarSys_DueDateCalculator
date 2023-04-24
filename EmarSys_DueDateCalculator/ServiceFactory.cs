using EmarSys_DueDateCalculator.DueDateCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarSys_DueDateCalculator
{
    public static class ServiceFactory
    {
        public static T GetService<T>() where T : class
        {
            if (typeof(T) == typeof(IDueDateCalculatorService))
            {
                return (T)(object)new DueDateCalculatorService();
            }

            return null;
        }
    }
}
