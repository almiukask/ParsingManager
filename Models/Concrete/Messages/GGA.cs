using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.Interfaces;

namespace ParsingManager.Models.Concrete.Messages
{
	public class GGA : IMessage, IReceiveRequiredData, ITimeInfo
	{
		public double TimeStampUTC;
		public double Latitude;
		public char DirLatitude;
		public double Longitude;
		public char DirLongitude;
		public int QualityIndic;
		public int NumberOfSVsUsed;
		public double HDOP;
		public double MSLAltitude;
		public char AltitudeUnits;
		public double GeoidSeparation;
		public char SeparationUnits;
		public double DGNSSAge;
		public int DGNSSStationID;
		const int FieldCount = 16;

		//public GGA(string[] separatedFields)
		//{
		//	SeparatedFields = separatedFields;
		//}


		public GGA(double timeStampUTC, double latitude, char dirLatitude, double longitude, char dirLongitude, int qualityIndic, int numberOfSVsUsed, double hDOP, double mSLAltitude, char altitudeUnits, double geoidSeparation, char separationUnits, double dGNSSAge, int dGNSSStationID)
		{
			TimeStampUTC = timeStampUTC;
			Latitude = latitude;
			DirLatitude = dirLatitude;
			Longitude = longitude;
			DirLongitude = dirLongitude;
			QualityIndic = qualityIndic;
			NumberOfSVsUsed = numberOfSVsUsed;
			HDOP = hDOP;
			MSLAltitude = mSLAltitude;
			AltitudeUnits = altitudeUnits;
			GeoidSeparation = geoidSeparation;
			SeparationUnits = separationUnits;
			DGNSSAge = dGNSSAge;
			DGNSSStationID = dGNSSStationID;
		}

		public GGA()
		{
		}

		//public string[] SeparatedFields { get; set; }

		public void FillMesage(string[] separatedFields)
		{
			double.TryParse(separatedFields[1], NumberStyles.Any, CultureInfo.InvariantCulture, out TimeStampUTC);
			double.TryParse(separatedFields[2], NumberStyles.Any, CultureInfo.InvariantCulture, out Latitude);
			char.TryParse(separatedFields[3], out DirLatitude);
			double.TryParse(separatedFields[4], NumberStyles.Any, CultureInfo.InvariantCulture, out Longitude);
			char.TryParse(separatedFields[5], out DirLongitude);
			int.TryParse(separatedFields[6], out QualityIndic);
			int.TryParse(separatedFields[7], out NumberOfSVsUsed);
			double.TryParse(separatedFields[8], NumberStyles.Any, CultureInfo.InvariantCulture, out HDOP);
			double.TryParse(separatedFields[9], NumberStyles.Any, CultureInfo.InvariantCulture, out MSLAltitude);
			char.TryParse(separatedFields[10], out AltitudeUnits);
			double.TryParse(separatedFields[11], NumberStyles.Any, CultureInfo.InvariantCulture, out GeoidSeparation);
			char.TryParse(separatedFields[12], out SeparationUnits);
			double.TryParse(separatedFields[13], NumberStyles.Any, CultureInfo.InvariantCulture, out DGNSSAge);
			int.TryParse(separatedFields[14], out DGNSSStationID);
		}
		public bool CheckDataSize(string[] separatedFields)
		{
			return FieldCount == separatedFields.Length;
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
			instance.NumberOfSVsUsed = NumberOfSVsUsed;
		}
		public double GetCurrentTime()
		{
			return TimeStampUTC;
		}
	}
}
