using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.DL.Models.Concrete.Messages;

namespace ParsingManager.DL.Models.Concrete
{
	public class Instance
	{
		double TimeStampUTC;
		double Speed;
		double PDOP;
		double HDOP;
		double VDOP;
		double Longitude;
		char DirLongitude;
		double Latitude;
		char DirLatitude;
		double MSLAltitude;
		int NumberofSVs;
		List<Satellite> SatellitesInfo;


		public void UpdateAvailableInstanceData(object messageData)
		{
			//Type t = messageData.GetType();
			/*switch (messageData.GetType())
			{
				case typeof(GSV):
					break;
				case typeof(GSA):
					break; 
			}*/
			if (messageData.GetType() == typeof(GSV)) Console.WriteLine(1); 

		}


		public void GetTime()
		{
			
		}
		public void GetSpeed()
		{ }
		public void GetPDOP()
		{ }
		public void GetHDOP()
		{ }
		public void GetVDOP()
		{ }
		public void GetLatitude()
		{ }
		public void GetLongitude()
		{ }
		public void GetAltitude()
		{ }
		public void GetSatellites()
		{ }


	}
}
