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
                    resultDateTime = resultDateTime.AddHours(remainingTurnaroundTime);
                    remainingTurnaroundTime = 0;
                }
                else if (remainingWorkingHoursThisDay < remainingTurnaroundTime)
                {
                    resultDateTime = CalculateNextWorkingDayAt9amWithSameMinutesAndSeconds(resultDateTime);
                    remainingTurnaroundTime -= remainingWorkingHoursThisDay + 1;
                }
            }

            return resultDateTime;
        }

        private DateTime CalculateNextWorkingDayAt9amWithSameMinutesAndSeconds(DateTime resultDateTime)
        {
            resultDateTime = resultDateTime.DayOfWeek == DayOfWeek.Friday ? resultDateTime.AddDays(3) : resultDateTime.AddDays(1);

            return new DateTime(resultDateTime.Year, resultDateTime.Month,
                resultDateTime.Day, 9, resultDateTime.Minute, resultDateTime.Second);
        }
    }
}
