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
		public double GeoidSeparation;
		public int NumberOfSVsUsed;
		public int QuantityOfSatellites;
		public List<Satellite> SatellitesInfo=new List<Satellite>();
		public double AvgCNO;

		public Instance()
		{
		}

		public Instance(double timeStampUTC, double speed, double pDOP, double hDOP, double vDOP, double longitude, char dirLongitude, double latitude, char dirLatitude, double mSLAltitude, double geoidSeparation, int numberOfSVsUsed, List<Satellite> satellitesInfo, int quantityOfSatellites, double avgCNO)
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
			GeoidSeparation = geoidSeparation;
			NumberOfSVsUsed = numberOfSVsUsed;
			SatellitesInfo = satellitesInfo;
			QuantityOfSatellites = quantityOfSatellites;
			AvgCNO = avgCNO;
		}
	}
}
