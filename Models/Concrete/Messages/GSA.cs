using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParsingManager.Interfaces;

namespace ParsingManager.Models.Concrete.Messages
{
	public class GSA : IMessage, IReceiveRequiredData
	{
		public char OperationMode;
		public int NavigationMode;
		public int Satellite1;
		public int Satellite2;
		public int Satellite3;
		public int Satellite4;
		public int Satellite5;
		public int Satellite6;
		public int Satellite7;
		public int Satellite8;
		public int Satellite9;
		public int Satellite10;
		public int Satellite11;
		public int Satellite12;
		public double PDOP;
		public double HDOP;
		public double VDOP;
		int SystemID; //Only NMEA 4.1
		const int FieldCountv40 = 19;
		const int FieldCountv41 = 20;
		bool NMEAV41 = false;
		public GSA(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
			NMEAV41 = CheckNMEAVersion(separatedFields);
		}

		public GSA(char operationMode, int navigationMode, int satellite1, int satellite2, int satellite3, int satellite4, int satellite5, int satellite6, int satellite7, int satellite8, int satellite9, int satellite10, int satellite11, int satellite12, double pDOP, double hDOP, double vDOP)
		{
			OperationMode = operationMode;
			NavigationMode = navigationMode;
			Satellite1 = satellite1;
			Satellite2 = satellite2;
			Satellite3 = satellite3;
			Satellite4 = satellite4;
			Satellite5 = satellite5;
			Satellite6 = satellite6;
			Satellite7 = satellite7;
			Satellite8 = satellite8;
			Satellite9 = satellite9;
			Satellite10 = satellite10;
			Satellite11 = satellite11;
			Satellite12 = satellite12;
			PDOP = pDOP;
			HDOP = hDOP;
			VDOP = vDOP;
		}

		public string[] SeparatedFields { get; set; }
		public void FillMesage()
		{

			char.TryParse(SeparatedFields[1], out OperationMode);
			int.TryParse(SeparatedFields[2], out NavigationMode);
			int.TryParse(SeparatedFields[3], out Satellite1);
			int.TryParse(SeparatedFields[4], out Satellite2);
			int.TryParse(SeparatedFields[5], out Satellite3);
			int.TryParse(SeparatedFields[6], out Satellite4);
			int.TryParse(SeparatedFields[7], out Satellite5);
			int.TryParse(SeparatedFields[8], out Satellite6);
			int.TryParse(SeparatedFields[9], out Satellite7);
			int.TryParse(SeparatedFields[10], out Satellite8);
			int.TryParse(SeparatedFields[11], out Satellite9);
			int.TryParse(SeparatedFields[12], out Satellite10);
			int.TryParse(SeparatedFields[13], out Satellite11);
			int.TryParse(SeparatedFields[14], out Satellite12);
			double.TryParse(SeparatedFields[15], NumberStyles.Any, CultureInfo.InvariantCulture, out PDOP);
			double.TryParse(SeparatedFields[16], NumberStyles.Any, CultureInfo.InvariantCulture, out HDOP);
			double.TryParse(SeparatedFields[17], NumberStyles.Any, CultureInfo.InvariantCulture, out VDOP);
			if (NMEAV41)
				int.TryParse(SeparatedFields[18], out SystemID); //only NMEA 4.1
		}
		public bool CheckDataSize()
		{
			if (NMEAV41)
				return FieldCountv41 == SeparatedFields.Length;
			else
			{
				return FieldCountv40 == SeparatedFields.Length;
			}
		}

		public IMessage GetData()
		{
			return this;
		}
		public void RetrieveSelectedData(Instance instance)
		{
			instance.HDOP = HDOP;
			instance.PDOP = PDOP;
			instance.VDOP = VDOP;
		}
		bool CheckNMEAVersion(string[] fields)
		{
			if (fields.Length == FieldCountv41)
				return true;
			else
				return false;

		}
	}
}
