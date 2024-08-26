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
		public void InputValidation_ValidateMenuOption_InputGreaterThanRange_ReturnFalse()
		{
			bool result = InputValidation.ValidateMenuOption(start, end, "12");
			Assert.IsFalse(result);
		}
		[TestMethod]
		public void InputValidation_ValidateMenuOption_InputIsLessThanRange_ReturnFalse()
		{
			bool result = InputValidation.ValidateMenuOption(start, end, "-4");
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
