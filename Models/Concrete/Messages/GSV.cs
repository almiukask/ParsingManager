using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Interfaces;

namespace ParsingManager.Models.Concrete.Messages
{
	public class GSV : IMessage, IReceiveRequiredData
	{
		public int NumberOfMessages;
		public int NumberOfCurrentMessage;
		public int QuantityOfSatellites;
		List<Satellite> Satellites = new List<Satellite>();
		//public int SignalID; only NMEA 4.1

		int FieldCount;
		int SatellitesInMessge;
		Enum constellation; 
		const int MaxSatteliteCountPerMessage = 4;
		const int FieldsPerSatellite = 4;
		const int NumOfHeadFields = 4;
		const int NumberofNotTreatedFields = 1;

		public GSV(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
			FieldCount = CountFiels();
			constellation = new MessageChecker().GetConstellation(SeparatedFields);
		}

		public GSV(int numberOfMessages, int numberOfCurrentMessage, int quantityOfSatellites, List<Satellite> satellites /*,int signalID*/)
		{
			NumberOfMessages = numberOfMessages;
			NumberOfCurrentMessage = numberOfCurrentMessage;
			QuantityOfSatellites = quantityOfSatellites;
			Satellites = satellites;
			//SignalID = signalID;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{
			for (int i = 0; i < SatellitesInMessge; i++)
			{
				Satellites.Add(new Satellite());
				Satellites[i].Constellation = constellation;
				int.TryParse(SeparatedFields[i + 4], out int temp);
				Satellites[i].SatelliteID = temp;
				int.TryParse(SeparatedFields[i + 5], out temp);
				Satellites[i].SatelliteElevation = temp;
				int.TryParse(SeparatedFields[i + 6], out temp);
				Satellites[i].SatelliteAzimuth = temp;
				int.TryParse(SeparatedFields[i + 7], out temp);
				Satellites[i].SatelliteCNO = temp;

			}
			//int.TryParse(SeparatedFields[NumOfHeadFields + SatellitesInMessge * FieldsPerSatellite], out temp);
			//SignalID = temp;
		}
		public bool CheckDataSize()
		{
			return FieldCount == SeparatedFields.Length;
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


		public IMessage GetData()
		{
			return this;
		}
		public void RetrieveSelectedData(Instance instance)
		{
			
			foreach (var sat in Satellites)
			{ instance.SatellitesInfo.Add(sat); }
			instance.QuantityOfSatellites = QuantityOfSatellites;

		}
		}
}
