using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class GSV
	{
		int NumberOfMessages;
		int NumberOfCurrentMessage;
		int QuantityOfSatellites;
		List<int> SatelliteID;
		List<int> SatelliteElevation;
		List<int> SatelliteAzimuth;
		List<int> SatelliteCNO;
		int SignalID;

		int MessageCount;
		int SatellitesInMessge;
		const int MaxSatteliteCountPerMessage = 4;
		const int FieldsPerSatellite = 4;
		const int NumOfHeadFields = 4;
		const int NumberofNotTreatedFields = 2;

		public GSV(string[] separatedFields)
		{
			SeparatedFields = separatedFields;	
			MessageCount= CountFiels();
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
			SignalID = temp;
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}
		public int CountFiels()
		{
			int.TryParse(SeparatedFields[1], out NumberOfMessages);
			int.TryParse(SeparatedFields[2], out NumberOfCurrentMessage);
			int.TryParse(SeparatedFields[3], out QuantityOfSatellites);
			if (NumberOfCurrentMessage != 0)
			{
				if (QuantityOfSatellites / NumberOfCurrentMessage * MaxSatteliteCountPerMessage > 0) SatellitesInMessge = 4;
				else SatellitesInMessge = QuantityOfSatellites % NumberOfCurrentMessage;
				MessageCount = NumOfHeadFields + SatellitesInMessge * FieldsPerSatellite;
				return MessageCount+NumberofNotTreatedFields;
			}
			else
				return 0;
		}
	}
}
