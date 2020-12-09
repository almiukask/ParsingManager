using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class GNS
	{
		double TimeStampUTC;
		double Latitude;
		char DirLatitude;
		double Longitude;
		char DirLongitude;
		char PositionMode;
		int NumberofSVs;
		double HDOP;
		double MSLAltitude;
		double GeoidSeparation;
		double DGNSSAge;
		int DGNSSStationID;
		char NavigationStatus;
		const int MessageCount = 15;
		public GNS(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}
		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], out TimeStampUTC);
			double.TryParse(SeparatedFields[2], out Latitude);
			char.TryParse(SeparatedFields[3], out DirLatitude);
			double.TryParse(SeparatedFields[4], out Longitude);
			char.TryParse(SeparatedFields[5], out DirLongitude);
			char.TryParse(SeparatedFields[6], out PositionMode);
			int.TryParse(SeparatedFields[7], out NumberofSVs);
			double.TryParse(SeparatedFields[8], out HDOP);
			double.TryParse(SeparatedFields[9], out MSLAltitude);
			double.TryParse(SeparatedFields[10], out GeoidSeparation);
			double.TryParse(SeparatedFields[11], out DGNSSAge);
			int.TryParse(SeparatedFields[12], out DGNSSStationID);
			char.TryParse(SeparatedFields[13], out NavigationStatus);
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}
	}
}
