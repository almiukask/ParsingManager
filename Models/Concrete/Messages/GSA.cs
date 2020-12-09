using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Models.Concrete.Messages
{
	class GSA
	{
		char OperationMode;
		int NavigationMode;
		int Satellite1;
		int Satellite2;
		int Satellite3;
		int Satellite4;
		int Satellite5;
		int Satellite6;
		int Satellite7;
		int Satellite8;
		int Satellite9;
		int Satellite10;
		int Satellite11;
		int Satellite12;
		double PDOP;
		double HDOP;
		double VDOP;
		int SystemID;
		const int MessageCount = 20;
		public GSA(string[] separatedFields)
		{
			SeparatedFields = separatedFields;
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
			double.TryParse(SeparatedFields[15], out PDOP);
			double.TryParse(SeparatedFields[16], out HDOP);
			double.TryParse(SeparatedFields[17], out VDOP);
			int.TryParse(SeparatedFields[18], out SystemID);
		}
		public bool CheckDataSize()
		{
			return MessageCount == SeparatedFields.Length ? true : false;
		}

	}
}
