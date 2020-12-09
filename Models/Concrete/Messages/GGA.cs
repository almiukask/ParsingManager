using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class GGA
	{
		public double TimeStampUTC;
		public double Latitude;
		public char DirLatitude;
		public double Longitude;
		public char DirLongitude;
		public int QualityIndic;
		public int NumberofSVs;
		public double HDOP;
		public double MSLAltitude;
		public char AltitudeUnits;
		public double GeoidSeparation;
		public char SeparationUnits;
		public double DGNSSAge;
		public int DGNSSStationID;
		const int MessageCount = 16;

		public GGA(string[] separatedFields)
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
			int.TryParse(SeparatedFields[6], out QualityIndic);
			int.TryParse(SeparatedFields[7], out NumberofSVs);
			double.TryParse(SeparatedFields[8], out HDOP);
			double.TryParse(SeparatedFields[9], out MSLAltitude);
			char.TryParse(SeparatedFields[10], out AltitudeUnits);
			double.TryParse(SeparatedFields[11], out GeoidSeparation);
			char.TryParse(SeparatedFields[12], out SeparationUnits);
			double.TryParse(SeparatedFields[13], out DGNSSAge);
			int.TryParse(SeparatedFields[14], out DGNSSStationID);
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}


	}
}
