using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarSys_DueDateCalculator.DueDateCalculator
{
    public class DueDateCalculatorService : IDueDateCalculatorService
    {
        public DateTime CalculateDueDate(DateTime submitDate, int turnaroundTime)
        {
            int remainingTurnaroundTime = turnaroundTime;
            DateTime resultDateTime = submitDate;

            while (remainingTurnaroundTime > 0)
            {
                int remainingWorkingHoursThisDay = (new DateTime(resultDateTime.Year, resultDateTime.Month, resultDateTime.Day, 17, 0, 0) - resultDateTime).Hours;

                if (remainingWorkingHoursThisDay >= remainingTurnaroundTime)
                {
                    return resultDateTime.AddHours(remainingTurnaroundTime);
                }

                if (remainingWorkingHoursThisDay < remainingTurnaroundTime)
                {
                    resultDateTime = CalculateNextWorkingDay9HWithSameMinutesAndSeconds(resultDateTime);
                    remainingTurnaroundTime -= remainingWorkingHoursThisDay + 1;
                }
            }

            return resultDateTime;
        }

        private DateTime CalculateNextWorkingDay9HWithSameMinutesAndSeconds(DateTime resultDateTime)
        {
            if (resultDateTime.DayOfWeek == DayOfWeek.Friday)
            {
                resultDateTime = resultDateTime.AddDays(3);
            } else
            {
                resultDateTime = resultDateTime.AddDays(1);
            }

            return new DateTime(resultDateTime.Year, resultDateTime.Month, resultDateTime.Day, 9, resultDateTime.Minute, resultDateTime.Second);
        }
    }
}
