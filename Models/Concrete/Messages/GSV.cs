﻿using System;
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
		readonly List<Satellite> Satellites = new List<Satellite>();
		public int SignalID = 0; //only NMEA 4.1
		bool NMEAV41 = false;

		int FieldCount;
		int SatellitesInMessge;
		readonly Enum constellation;
		const int MaxSatteliteCountPerMessage = 4;
		const int FieldsPerSatellite = 4;
		const int NumOfHeadFields = 4;
		const int SatelliteDataOffset = 4;
		const int NumberofNotTreatedFields = 1;
		const int NumberOfNMEAv41messages = 1;

		public GSV(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
			if (SeparatedFields.Length % 2 == 0) NMEAV41 = true;
			FieldCount = CountFiels();
			constellation = new MessageChecker().GetConstellation(SeparatedFields);
		}

		public GSV(int numberOfMessages, int numberOfCurrentMessage, int quantityOfSatellites, List<Satellite> satellites, int signalID)
		{
			NumberOfMessages = numberOfMessages;
			NumberOfCurrentMessage = numberOfCurrentMessage;
			QuantityOfSatellites = quantityOfSatellites;
			Satellites = satellites;
			SignalID = signalID;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{

			int temp;
			for (int i = 0; i < SatellitesInMessge; i++)
			{
				Satellites.Add(new Satellite());
				Satellites[i].Constellation = constellation;

				int.TryParse(SeparatedFields[(i + 1) * SatelliteDataOffset], out temp);
				Satellites[i].SatelliteID = temp;
				int.TryParse(SeparatedFields[(i + 1) * SatelliteDataOffset + 1], out temp);
				Satellites[i].SatelliteElevation = temp;
				int.TryParse(SeparatedFields[(i + 1) * SatelliteDataOffset + 2], out temp);
				Satellites[i].SatelliteAzimuth = temp;
				int.TryParse(SeparatedFields[(i + 1) * SatelliteDataOffset + 3], out temp);
				Satellites[i].SatelliteCNO = temp;

			}
			if (NMEAV41)
			{
				int.TryParse(SeparatedFields[NumOfHeadFields + SatellitesInMessge * FieldsPerSatellite], out temp);
				SignalID = temp;
			}
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
				return NMEAV41 ? FieldCount + NumberofNotTreatedFields + NumberOfNMEAv41messages : FieldCount + NumberofNotTreatedFields;
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
			if (NumberOfCurrentMessage == 1)
				instance.QuantityOfSatellites += QuantityOfSatellites;
			foreach (var sat in Satellites)
			{ 
				instance.SatellitesInfo.Add(sat);
				if (sat.SatelliteCNO > 0 & sat.SatelliteCNO < 99)
				{ 
					instance.AvgCNO += (double)sat.SatelliteCNO; 

				}
			}


		}
	}
}
