using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.Interfaces;

namespace ParsingManager.Models.Concrete.Messages
{
	public class RMC : IMessage, IReceiveRequiredData, ITimeInfo
	{
		public double TimeStampUTC;
		public char Status;
		public double Latitude;
		public char DirLatitude;
		public double Longitude;
		public char DirLongitude;
		public double Speed;
		public double Course;
		public string Date;
		public double MagneticVariationValue;
		public char MagVarIndicator;
		public char PositionMode;
		char NavigationStatus; //Only NMEA 4.1
		bool NMEAV41 = false;
		const int FieldCountV40 = 14;
		const int FieldCountV41 = 15;
		public RMC(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
			NMEAV41 = CheckNMEAVersion(separatedFields);
		}

		public RMC(double timeStampUTC, char status, double latitude, char dirLatitude, double longitude, char dirLongitude, double speed, double course, string date, double magneticVariationValue, char magVarIndicator, char positionMode)
		{
			TimeStampUTC = timeStampUTC;
			Status = status;
			Latitude = latitude;
			DirLatitude = dirLatitude;
			Longitude = longitude;
			DirLongitude = dirLongitude;
			Speed = speed;
			Course = course;
			Date = date;
			MagneticVariationValue = magneticVariationValue;
			MagVarIndicator = magVarIndicator;
			PositionMode = positionMode;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], NumberStyles.Any, CultureInfo.InvariantCulture, out TimeStampUTC);
			char.TryParse(SeparatedFields[2], out Status);
			double.TryParse(SeparatedFields[3], NumberStyles.Any, CultureInfo.InvariantCulture, out Latitude);
			char.TryParse(SeparatedFields[4], out DirLatitude);
			double.TryParse(SeparatedFields[5], NumberStyles.Any, CultureInfo.InvariantCulture, out Longitude);
			char.TryParse(SeparatedFields[6], out DirLongitude);
			double.TryParse(SeparatedFields[7], NumberStyles.Any, CultureInfo.InvariantCulture, out Speed);
			double.TryParse(SeparatedFields[8], NumberStyles.Any, CultureInfo.InvariantCulture, out Course);
			Date = SeparatedFields[9];
			double.TryParse(SeparatedFields[10], NumberStyles.Any, CultureInfo.InvariantCulture, out MagneticVariationValue);
			char.TryParse(SeparatedFields[11], out MagVarIndicator);
			char.TryParse(SeparatedFields[12], out PositionMode);
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
			instance.Speed = Speed* 0.514444444; //knots conversion to meters/s
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
