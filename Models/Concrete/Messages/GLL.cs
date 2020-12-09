using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class GLL
	{
		double Latitude;
		char DirLatitude;
		double Longitude;
		char DirLongitude;
		double TimeStampUTC;
		char NavigationStatus;
		char PositionMode;
		const int MessageCount = 9;
		public GLL(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}
		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], out Latitude);
			char.TryParse(SeparatedFields[2], out DirLatitude);
			double.TryParse(SeparatedFields[3], out Longitude);
			char.TryParse(SeparatedFields[4], out DirLongitude);
			double.TryParse(SeparatedFields[5], out TimeStampUTC);
			char.TryParse(SeparatedFields[6], out NavigationStatus);
			char.TryParse(SeparatedFields[7], out PositionMode);
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}
	}
}
