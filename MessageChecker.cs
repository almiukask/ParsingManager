using System;
using System.Collections.Generic;

namespace ParsingManager
{
	public class MessageChecker
	{
		const char FirstSymbol = '$';
		const char chSumDelimiter = '*';
		const char FieldDelimiter = ',';
		const int chSumSizeCharsASCII = 2; //4 when using Read, 2 wehn reading Line
		const int constellationPlace = 1;
		const int firstElement = 0;
		char[] Delimiters = { FieldDelimiter, chSumDelimiter };

		public MessageChecker(string parsingLine)
		{
			ParsingLine = parsingLine;
		}

		public string ParsingLine { get; set; }

		public bool IsStructureValid()
		{
			if (ParsingLine[firstElement] == FirstSymbol && ParsingLine[(ParsingLine.Length-1) - chSumSizeCharsASCII] == chSumDelimiter) return true;
			else return false;
		}
		public string[] SeparetValues()
		{
			string[] Values;
			Values = ParsingLine.Split(Delimiters);
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
			char[] tempArray = { Values[0][3], Values[0][4], Values[0][5] };
			string packetType = new string(tempArray);

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
