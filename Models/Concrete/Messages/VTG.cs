using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class VTG
	{
		double Course;
		double CourseUnits;
		double CourseMagntic;
		char CourseMagUnits;
		double SpeedKnots;
		char SpeedKnotsUnits;
		double Speed;
		char SpeedUnits;
		char PositionMode;
		const int MessageCount = 11;

		public VTG(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}
		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], out Course);
			double.TryParse(SeparatedFields[2], out CourseUnits);
			double.TryParse(SeparatedFields[3], out CourseMagntic);
			char.TryParse(SeparatedFields[4], out CourseMagUnits);
			double.TryParse(SeparatedFields[5], out SpeedKnots);
			char.TryParse(SeparatedFields[6], out SpeedKnotsUnits);
			double.TryParse(SeparatedFields[7], out Speed);
			char.TryParse(SeparatedFields[8], out SpeedUnits);
			char.TryParse(SeparatedFields[9], out PositionMode);
			
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}
	}
}
