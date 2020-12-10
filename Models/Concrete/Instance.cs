using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Models.Concrete.Messages;

namespace ParsingManager.Models.Concrete
{
	public class Instance
	{
		public double TimeStampUTC;
		public double Speed;
		public double PDOP;
		public double HDOP;
		public double VDOP;
		public double Longitude;
		public char DirLongitude;
		public double Latitude;
		public char DirLatitude;
		public double MSLAltitude;
		public int NumberOfSVsUsed;
		public int QuantityOfSatellites;
		public List<Satellite> SatellitesInfo=new List<Satellite>();

		public Instance()
		{
		}

		public Instance(double timeStampUTC, double speed, double pDOP, double hDOP, double vDOP, double longitude, char dirLongitude, double latitude, char dirLatitude, double mSLAltitude, int numberOfSVsUsed, List<Satellite> satellitesInfo, int quantityOfSatellites)
		{
			TimeStampUTC = timeStampUTC;
			Speed = speed;
			PDOP = pDOP;
			HDOP = hDOP;
			VDOP = vDOP;
			Longitude = longitude;
			DirLongitude = dirLongitude;
			Latitude = latitude;
			DirLatitude = dirLatitude;
			MSLAltitude = mSLAltitude;
			NumberOfSVsUsed = numberOfSVsUsed;
			SatellitesInfo = satellitesInfo;
			QuantityOfSatellites = quantityOfSatellites;
		}
	}
}
