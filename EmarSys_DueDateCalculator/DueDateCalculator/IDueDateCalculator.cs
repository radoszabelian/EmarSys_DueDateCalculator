namespace EmarSys_DueDateCalculator.DueDateCalculator
{
    public interface IDueDateCalculatorService
    {
        DateTime CalculateDueDate(DateTime submitDate, int turnaroundTime);
    }
}
