using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.Interfaces;

namespace ParsingManager.Models.Concrete.Messages
{
	public class GNS : IMessage, IReceiveRequiredData, ITimeInfo
	{
		public double TimeStampUTC;
		public double Latitude;
		public char DirLatitude;
		public double Longitude;
		public char DirLongitude;
		public string PositionMode;
		public int NumberOfSVsUsed;
		public double HDOP;
		public double MSLAltitude;
		public double GeoidSeparation;
		public double DGNSSAge;
		public int DGNSSStationID;
		char NavigationStatus;// only NMEA 4.1
		bool NMEAV41 = false;
		const int FieldCountV40 = 15;
		const int FieldCountV41 = 16;
		public GNS(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
			NMEAV41 = CheckNMEAVersion(separatedFields);
		}

		public GNS(double timeStampUTC, double latitude, char dirLatitude, double longitude, char dirLongitude, string positionMode, int numberOfSVsUsed, double hDOP, double mSLAltitude, double geoidSeparation, double dGNSSAge, int dGNSSStationID)
		{
			TimeStampUTC = timeStampUTC;
			Latitude = latitude;
			DirLatitude = dirLatitude;
			Longitude = longitude;
			DirLongitude = dirLongitude;
			PositionMode = positionMode;
			NumberOfSVsUsed = numberOfSVsUsed;
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
			PositionMode = SeparatedFields[6];
			int.TryParse(SeparatedFields[7], out NumberOfSVsUsed);
			double.TryParse(SeparatedFields[8], NumberStyles.Any, CultureInfo.InvariantCulture, out HDOP);
			double.TryParse(SeparatedFields[9], NumberStyles.Any, CultureInfo.InvariantCulture, out MSLAltitude);
			double.TryParse(SeparatedFields[10], NumberStyles.Any, CultureInfo.InvariantCulture, out GeoidSeparation);
			double.TryParse(SeparatedFields[11], NumberStyles.Any, CultureInfo.InvariantCulture, out DGNSSAge);
			int.TryParse(SeparatedFields[12], out DGNSSStationID);
			if (NMEAV41)
				char.TryParse(SeparatedFields[13], out NavigationStatus); //only NMEA 4.1
		}
		public bool CheckDataSize()
		{
			return NMEAV41 ? FieldCountV41 == SeparatedFields.Length : FieldCountV40 == SeparatedFields.Length;
		}

		public IMessage GetData()
		{
			return this;
		}
		public void RetrieveSelectedData(Instance instance)
		{
			instance.TimeStampUTC = TimeStampUTC;
			instance.Latitude = Latitude;
			instance.DirLatitude = DirLatitude;
			instance.Longitude = Longitude;
			instance.DirLongitude = DirLongitude;
			instance.HDOP = HDOP;
			instance.MSLAltitude = MSLAltitude;
			instance.GeoidSeparation = GeoidSeparation;
			instance.NumberOfSVsUsed = NumberOfSVsUsed;
		}
		public double GetCurrentTime()
		{
			return TimeStampUTC;
		}
		bool CheckNMEAVersion(string[] fields)
		{
			if (fields.Length == FieldCountV41)
				return true;
			else
				return false;

		}
	}
}
