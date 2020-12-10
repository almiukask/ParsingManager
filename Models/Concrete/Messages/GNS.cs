using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.DL.Interfaces;

namespace ParsingManager.DL.Models.Concrete.Messages
{
	public class GNS : IMessageService
	{
		public double TimeStampUTC;
		public double Latitude;
		public char DirLatitude;
		public double Longitude;
		public char DirLongitude;
		public string PositionMode;
		public int NumberofSVs;
		public double HDOP;
		public double MSLAltitude;
		public double GeoidSeparation;
		public double DGNSSAge;
		public int DGNSSStationID;
		//char NavigationStatus; only NMEA 4.1
		const int FieldCount = 15;
		public GNS(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}

		public GNS(double timeStampUTC, double latitude, char dirLatitude, double longitude, char dirLongitude, string positionMode, int numberofSVs, double hDOP, double mSLAltitude, double geoidSeparation, double dGNSSAge, int dGNSSStationID)
		{
			TimeStampUTC = timeStampUTC;
			Latitude = latitude;
			DirLatitude = dirLatitude;
			Longitude = longitude;
			DirLongitude = dirLongitude;
			PositionMode = positionMode;
			NumberofSVs = numberofSVs;
			HDOP = hDOP;
			MSLAltitude = mSLAltitude;
			GeoidSeparation = geoidSeparation;
			DGNSSAge = dGNSSAge;
			DGNSSStationID = dGNSSStationID;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], NumberStyles.Any, CultureInfo.InvariantCulture, out TimeStampUTC);
			double.TryParse(SeparatedFields[2], NumberStyles.Any, CultureInfo.InvariantCulture, out Latitude);
			char.TryParse(SeparatedFields[3], out DirLatitude);
			double.TryParse(SeparatedFields[4], NumberStyles.Any, CultureInfo.InvariantCulture, out Longitude);
			char.TryParse(SeparatedFields[5], out DirLongitude);
			PositionMode= SeparatedFields[6];
			int.TryParse(SeparatedFields[7], out NumberofSVs);
			double.TryParse(SeparatedFields[8], NumberStyles.Any, CultureInfo.InvariantCulture, out HDOP);
			double.TryParse(SeparatedFields[9], NumberStyles.Any, CultureInfo.InvariantCulture, out MSLAltitude);
			double.TryParse(SeparatedFields[10], NumberStyles.Any, CultureInfo.InvariantCulture, out GeoidSeparation);
			double.TryParse(SeparatedFields[11], NumberStyles.Any, CultureInfo.InvariantCulture, out DGNSSAge);
			int.TryParse(SeparatedFields[12], out DGNSSStationID);
			//char.TryParse(SeparatedFields[13], out NavigationStatus); only NMEA 4.1
		}
		public bool CheckDataSize()
		{
			return FieldCount == SeparatedFields.Length ? true : false;
		}
		public object GetData()
		{
			return new GNS
				(TimeStampUTC, 
				Latitude, DirLatitude, 
				Longitude, DirLongitude, 
				PositionMode, NumberofSVs, HDOP, 
				MSLAltitude, 
				GeoidSeparation, 
				DGNSSAge, DGNSSStationID
				);
		}
	}
}
