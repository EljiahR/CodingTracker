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
			bool result = InputValidation.ValidateMenuOption(start, end, "5");
			Assert.IsTrue(result);
		}
		[TestMethod]
		[DataRow("-4")]
		[DataRow("12")]
		public void InputValidation_ValidateMenuOption_InputOutsideRange_ReturnFalse(string input)
		{
			bool result = InputValidation.ValidateMenuOption(start, end, input);
			Assert.IsFalse(result);
		}
	
		[TestMethod]
		public void InputValidation_ValidateMenuOption_InputIsLetter_ReturnFalse()
		{
			bool result = InputValidation.ValidateMenuOption(start, end, "b");
			Assert.IsFalse(result);
		}
	}
}
