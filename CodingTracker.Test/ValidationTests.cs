using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CodingTracker;

namespace CodingTracker.Test
{
    [TestClass]
    public class ValidationTests
    {
        // For menu input validation tests
        int start = 0;
        int end = 7;
        [TestMethod]
        public void InputValidation_ValidateMenuOption_InputInRange_ReturnTrue()
        {
            bool result = InputValidation.ValidateMenuOption(start, end, "3");
        }
    }
}
