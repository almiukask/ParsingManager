using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.DL.Interfaces;

namespace ParsingManager.DL.Models.Concrete.Messages
{
	public class GSV : IMessageService
	{
		public int NumberOfMessages;
		public int NumberOfCurrentMessage;
		public int QuantityOfSatellites;
		public List<int> SatelliteID= new List<int>();
		public List<int> SatelliteElevation = new List<int>();
		public List<int> SatelliteAzimuth = new List<int>();
		public List<int> SatelliteCNO = new List<int>();
		//public int SignalID; only NMEA 4.1

		int FieldCount;
		int SatellitesInMessge;
		const int MaxSatteliteCountPerMessage = 4;
		const int FieldsPerSatellite = 4;
		const int NumOfHeadFields = 4;
		const int NumberofNotTreatedFields = 1;

		public GSV(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
			FieldCount = CountFiels();
		}

		public GSV(int numberOfMessages, int numberOfCurrentMessage, int quantityOfSatellites, List<int> satelliteID, List<int> satelliteElevation, List<int> satelliteAzimuth, List<int> satelliteCNO /*,int signalID*/)
		{
			NumberOfMessages = numberOfMessages;
			NumberOfCurrentMessage = numberOfCurrentMessage;
			QuantityOfSatellites = quantityOfSatellites;
			SatelliteID = satelliteID;
			SatelliteElevation = satelliteElevation;
			SatelliteAzimuth = satelliteAzimuth;
			SatelliteCNO = satelliteCNO;
			//SignalID = signalID;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			int temp = 0;
			for (int i = 0; i < SatellitesInMessge; i++)
			{
				int.TryParse(SeparatedFields[i + 4], out temp);
				SatelliteID.Add(temp);
				int.TryParse(SeparatedFields[i + 5], out temp);
				SatelliteElevation.Add(temp);
				int.TryParse(SeparatedFields[i + 6], out temp);
				SatelliteAzimuth.Add(temp);
				int.TryParse(SeparatedFields[i + 7], out temp);
				SatelliteCNO.Add(temp);

			}
			int.TryParse(SeparatedFields[NumOfHeadFields + SatellitesInMessge * FieldsPerSatellite], out temp);
			//SignalID = temp;
		}
		public bool CheckDataSize()
		{
			return FieldCount == SeparatedFields.Length ? true : false;
		}
		public int CountFiels()
		{
			int.TryParse(SeparatedFields[1], out NumberOfMessages);
			int.TryParse(SeparatedFields[2], out NumberOfCurrentMessage);
			int.TryParse(SeparatedFields[3], out QuantityOfSatellites);
			if (NumberOfCurrentMessage != 0)
			{
				if (QuantityOfSatellites / (NumberOfCurrentMessage * MaxSatteliteCountPerMessage) > 0) SatellitesInMessge = 4;
				else SatellitesInMessge = QuantityOfSatellites % MaxSatteliteCountPerMessage;
				FieldCount = NumOfHeadFields + SatellitesInMessge * FieldsPerSatellite;
				return FieldCount + NumberofNotTreatedFields;
			}
			else
				return 0;
		}

		public object GetData()
		{
			return new GSV
			(
				NumberOfMessages, NumberOfCurrentMessage, QuantityOfSatellites,
				SatelliteID,
				SatelliteElevation,
				SatelliteAzimuth,
				SatelliteCNO
				//SignalID Only NMEA 4.1
				/*
				          * ,FieldCount, SatellitesInMessge*/
			);
		}
	}
}
