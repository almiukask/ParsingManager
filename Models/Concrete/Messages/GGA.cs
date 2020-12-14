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

		public GGA(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}


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

		public string[] SeparatedFields { get; set; }

		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], NumberStyles.Any, CultureInfo.InvariantCulture, out TimeStampUTC);
			double.TryParse(SeparatedFields[2], NumberStyles.Any, CultureInfo.InvariantCulture, out Latitude);
			char.TryParse(SeparatedFields[3], out DirLatitude);
			double.TryParse(SeparatedFields[4], NumberStyles.Any, CultureInfo.InvariantCulture, out Longitude);
			char.TryParse(SeparatedFields[5], out DirLongitude);
			int.TryParse(SeparatedFields[6], out QualityIndic);
			int.TryParse(SeparatedFields[7], out NumberOfSVsUsed);
			double.TryParse(SeparatedFields[8], NumberStyles.Any, CultureInfo.InvariantCulture, out HDOP);
			double.TryParse(SeparatedFields[9], NumberStyles.Any, CultureInfo.InvariantCulture, out MSLAltitude);
			char.TryParse(SeparatedFields[10], out AltitudeUnits);
			double.TryParse(SeparatedFields[11], NumberStyles.Any, CultureInfo.InvariantCulture, out GeoidSeparation);
			char.TryParse(SeparatedFields[12], out SeparationUnits);
			double.TryParse(SeparatedFields[13], NumberStyles.Any, CultureInfo.InvariantCulture, out DGNSSAge);
			int.TryParse(SeparatedFields[14], out DGNSSStationID);
		}
		public bool CheckDataSize()
		{
			return FieldCount == SeparatedFields.Length;
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
