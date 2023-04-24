using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DueDateCalculatorTestCase
    {
        public int TurnaroundTime { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ExpectedCalculationResult { get; set; }
    }
}
