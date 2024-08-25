using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker;

public class InputValidation
{
	public static bool ValidateMenuOption(int start, int end, string? input)
	{
		// Empty string
		if (string.IsNullOrEmpty(input)) return false;
		int x;
		// Not a valid int
		if (!int.TryParse(input, out x)) return false;
		// Not in option range
		if (x < start || x > end) return false;
		// Only valid options left
		return true;
	}

	public static bool ValidateDate(string? input)
	{
		// Blank strings are a valid input, used for easy Today
		if (string.IsNullOrEmpty(input)) return true;

		DateTime day;
		return DateTime.TryParse(input, out day);
	}

	public static bool ValidateTime(string? input)
	{
		// Empty strings not valid for time
		if (string.IsNullOrEmpty(input)) return false;

		TimeOnly time;
		return TimeOnly.TryParse(input, out time);
	}

}
