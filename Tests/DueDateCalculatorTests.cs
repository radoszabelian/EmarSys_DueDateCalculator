using EmarSys_DueDateCalculator;
using EmarSys_DueDateCalculator.DueDateCalculator;

namespace Tests
{
    public class Tests
    {
        IDueDateCalculatorService _dueDateCalculatorService;

        [SetUp]
        public void Setup()
        {
            _dueDateCalculatorService = ServiceFactory.GetService<IDueDateCalculatorService>();
        }

        public static IEnumerable<DueDateCalculatorTestCase> GetCalculatorTestCase()
        {
            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 24, 9, 0, 0),
                TurnaroundTime = 8,
                // TODO ezt átgondolni, hogy pont 8 óra az 17H -e
                ExpectedCalculationResult = new DateTime(2023, 04, 24, 17, 0, 0) 
            };

            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 24, 9, 0, 0),
                TurnaroundTime = 1,
                ExpectedCalculationResult = new DateTime(2023, 04, 24, 10, 0, 0)
            };

            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 24, 9, 1, 7),
                TurnaroundTime = 2,
                ExpectedCalculationResult = new DateTime(2023, 04, 24, 11, 1, 7)
            };

            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 24, 13, 22, 43),
                TurnaroundTime = 8,
                ExpectedCalculationResult = new DateTime(2023, 04, 25, 13, 22, 43)
            };

            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 21, 13, 22, 43),
                TurnaroundTime = 8,
                ExpectedCalculationResult = new DateTime(2023, 04, 24, 13, 22, 43)
            };

            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 20, 14, 30, 15),
                TurnaroundTime = 23,
                ExpectedCalculationResult = new DateTime(2023, 04, 25, 13, 30, 15)
            };

            yield return new DueDateCalculatorTestCase()
            {
                SubmitDate = new DateTime(2023, 04, 25, 14, 12, 00),
                TurnaroundTime = 16,
                ExpectedCalculationResult = new DateTime(2023, 04, 27, 14, 12, 00)
            };
        }

        [TestCaseSource(nameof(GetCalculatorTestCase))]
        [Test]
        public void DueDateCalculatorTest(DueDateCalculatorTestCase testCase)
        {
            var result = _dueDateCalculatorService.CalculateDueDate(testCase.SubmitDate, testCase.TurnaroundTime);

            Assert.That(result, Is.EqualTo(testCase.ExpectedCalculationResult));
        }
    }
}