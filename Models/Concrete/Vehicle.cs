using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete
{
	public class Vehicle
	{
		public List<Instance> Data = new List<Instance>();

		public Dictionary<Enum, double> AvgSatellitesCNO = new Dictionary<Enum, double>
		{
			{ MessageChecker.GnssConstellation.GPS, 0 },
			{ MessageChecker.GnssConstellation.GLONASS, 0 },
			{ MessageChecker.GnssConstellation.GALILEO, 0 },
			{ MessageChecker.GnssConstellation.MIX, 0 }
		};


		public Dictionary<Enum, double> DOPs = new Dictionary<Enum, double>
		{
			{ TypeOfDOP.HDOP, 0 },
			{ TypeOfDOP.VDOP, 0 },
			{ TypeOfDOP.PDOP, 0 }
		};

		public double AvgQuantOfSatellites;

		public double AvgSVinUse;

		public enum TypeOfDOP {HDOP, VDOP, PDOP}


	}
}
