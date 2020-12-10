using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.Interfaces;


namespace ParsingManager.Models.Concrete.Messages
{
	public class VTG : IMessage, IReceiveRequiredData
	{
		public double Course;
		public char CourseUnits;
		public double CourseMagntic;
		public char CourseMagUnits;
		public double SpeedKnots;
		public char SpeedKnotsUnits;
		public double Speed;
		public char SpeedUnits;
		public char PositionMode;
		const int FieldCount = 11;

		public VTG(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}

		public VTG(double course, char courseUnits, double courseMagntic, char courseMagUnits, double speedKnots, char speedKnotsUnits, double speed, char speedUnits, char positionMode)
		{
			Course = course;
			CourseUnits = courseUnits;
			CourseMagntic = courseMagntic;
			CourseMagUnits = courseMagUnits;
			SpeedKnots = speedKnots;
			SpeedKnotsUnits = speedKnotsUnits;
			Speed = speed;
			SpeedUnits = speedUnits;
			PositionMode = positionMode;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], NumberStyles.Any, CultureInfo.InvariantCulture, out Course);
			char.TryParse(SeparatedFields[2], out CourseUnits);
			double.TryParse(SeparatedFields[3], NumberStyles.Any, CultureInfo.InvariantCulture, out CourseMagntic);
			char.TryParse(SeparatedFields[4], out CourseMagUnits);
			double.TryParse(SeparatedFields[5], NumberStyles.Any, CultureInfo.InvariantCulture, out SpeedKnots);
			char.TryParse(SeparatedFields[6], out SpeedKnotsUnits);
			double.TryParse(SeparatedFields[7], NumberStyles.Any, CultureInfo.InvariantCulture, out Speed);
			char.TryParse(SeparatedFields[8], out SpeedUnits);
			char.TryParse(SeparatedFields[9], out PositionMode);

		}
		public bool CheckDataSize()
		{
			return FieldCount == SeparatedFields.Length ? true : false;
		}
		public IMessage GetData()
		{
			return this;
		}
		public void RetrieveSelectedData(Instance instance)
		{
			instance.Speed = Speed;
		}
		}
}
