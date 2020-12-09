using System;
using System.Collections.Generic;

namespace ParsingManager
{
	public class ParserService
	{
		const char FirstSymbol = '$';
		const char chSumDelimiter = '*';
		const char FieldDelimiter = ',';
		const int chSumSizeBytesASCII = 2;
		const int constellationPlace = 1;
		const int firstElement = 0;
		char[] Delimiters = { FieldDelimiter, FirstSymbol, chSumDelimiter };

		public ParserService(string parsingLine)
		{
			ParsingLine = parsingLine;
		}

		public string ParsingLine { get; set; }

		public bool IsStructureValid(string parsingLine)
		{
			if (parsingLine[firstElement]==FirstSymbol && parsingLine[parsingLine.Length-chSumSizeBytesASCII]==chSumDelimiter) return true;
			else return false;
		}
		public string[] SeparetValues(string parsingLine)
		{
			string[] Values;
			Values = parsingLine.Split(Delimiters);
			return Values;
		}
		public Enum GetConstellation(string[] Values)
		{
			switch (Values[firstElement].ToCharArray()[constellationPlace])
			{ 
				case 'N':
					return GnssConstellation.MIX;
				case 'P':
					return GnssConstellation.GPS;
				case 'L':
					return GnssConstellation.GLONASS;
				case 'A':
					return GnssConstellation.GALILEO;
				default:
					return null;
			}
		}
		public Enum GetMessageType(string[] Values)
		{
			char[] tempArray = { Values[0][2], Values[0][3], Values[0][4] };
			string packetType = tempArray.ToString();
			
			switch (packetType)
			{
				case "RMC":
					return MessageType.RMC;
				case "GNS":
					return MessageType.GNS;
				case "GGA":
					return MessageType.GGA;
				case "GLL":
					return MessageType.GLL;
				case "VTG":
					return MessageType.VTG;
				case "GSA":
					return MessageType.GSA;
				case "GSV":
					return MessageType.GSV;
				default:
					return null;
			}
			
		}
		public enum GnssConstellation { GPS, GLONASS, GALILEO, MIX }
		public enum MessageType { RMC, GNS, GGA, GLL, VTG, GSA, GSV }

	}
}
