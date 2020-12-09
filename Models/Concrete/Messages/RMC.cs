using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class RMC
	{
		double TimeStampUTC;
		char Status;
		double Latitude;
		char DirLatitude;
		double Longitude;
		char DirLongitude;
		double Speed;
		double Course;
		string Date;
		double MagneticVariationValue;
		char MagVarIndicator;
		char PositionMode;
		char NavigationStatus;
		const int MessageCount = 15;
		public RMC(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}
		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], out TimeStampUTC);
			char.TryParse(SeparatedFields[2], out Status);
			double.TryParse(SeparatedFields[3], out Latitude);
			char.TryParse(SeparatedFields[4], out DirLatitude);
			double.TryParse(SeparatedFields[5], out Longitude);
			char.TryParse(SeparatedFields[6], out DirLongitude);
			double.TryParse(SeparatedFields[7], out Speed);
			double.TryParse(SeparatedFields[8], out Course);
			Date = SeparatedFields[9];
			double.TryParse(SeparatedFields[10], out MagneticVariationValue);
			char.TryParse(SeparatedFields[11], out MagVarIndicator);
			char.TryParse(SeparatedFields[12], out PositionMode);
			char.TryParse(SeparatedFields[13], out NavigationStatus);
			
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}
	}
}
