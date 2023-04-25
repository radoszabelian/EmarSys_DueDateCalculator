using EmarSys_DueDateCalculator.DueDateCalculator;

namespace EmarSys_DueDateCalculator
{
    public static class ServiceFactory
    {
        public static T? GetService<T>() where T : class
        {
            if (typeof(T) == typeof(IDueDateCalculatorService))
            {
                return (T)(object)new DueDateCalculatorService();
            }

            return null;
        }
    }
}
