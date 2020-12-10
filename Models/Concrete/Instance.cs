using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.DL.Models.Concrete
{
	public class Instance
	{
		double timestampUTC;
		double Speed;
		double PDOP;
		double HDOP;
		double VDOP;
		double Longtitude;
		double Lattiotude;
		double Altitude;
		int numberOfSatellites;
		List<Satellite> SatellitesInfo;

	}
}
