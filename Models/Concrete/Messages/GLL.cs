using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.Interfaces;

namespace ParsingManager.Models.Concrete.Messages
{
	public class GLL : IMessage, IReceiveRequiredData, ITimeInfo
	{
		public double Latitude;
		public char DirLatitude;
		public double Longitude;
		public char DirLongitude;
		public double TimeStampUTC;
		public char NavigationStatus;
		public char PositionMode;
		const int FieldCount = 9;
		public GLL(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
		}

		public GLL(double latitude, char dirLatitude, double longitude, char dirLongitude, double timeStampUTC, char navigationStatus, char positionMode)
		{
			Latitude = latitude;
			DirLatitude = dirLatitude;
			Longitude = longitude;
			DirLongitude = dirLongitude;
			TimeStampUTC = timeStampUTC;
			NavigationStatus = navigationStatus;
			PositionMode = positionMode;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			double.TryParse(SeparatedFields[1], NumberStyles.Any, CultureInfo.InvariantCulture, out Latitude);
			char.TryParse(SeparatedFields[2], out DirLatitude);
			double.TryParse(SeparatedFields[3], NumberStyles.Any, CultureInfo.InvariantCulture, out Longitude);
			char.TryParse(SeparatedFields[4], out DirLongitude);
			double.TryParse(SeparatedFields[5], NumberStyles.Any, CultureInfo.InvariantCulture, out TimeStampUTC);
			char.TryParse(SeparatedFields[6], out NavigationStatus);
			char.TryParse(SeparatedFields[7], out PositionMode);
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
		}
		public double GetCurrentTime()
		{
			return TimeStampUTC;
		}
	}	
}
