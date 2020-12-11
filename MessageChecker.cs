﻿using System;
using System.Collections.Generic;

namespace ParsingManager
{
	public class MessageChecker
	{
		const char FirstSymbol = '$';
		const char chSumDelimiter = '*';
		const char FieldDelimiter = ',';
		const int chSumSizeCharsASCII = 2; //4 when using Read, 2 wehn reading Line
		const int constellationPlace = 2;
		const int firstElement = 0;
		readonly char[] Delimiters = { FieldDelimiter, chSumDelimiter };

		public MessageChecker(string parsingLine)
		{
			ParsingLine = parsingLine;
		}

		public MessageChecker()
		{
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
			return (Values[firstElement].ToCharArray()[constellationPlace]) switch
			{
				'N' => GnssConstellation.MIX,
				'P' => GnssConstellation.GPS,
				'L' => GnssConstellation.GLONASS,
				'A' => GnssConstellation.GALILEO,
				_ => null,
			};
		}
		public Enum GetMessageType(string[] Values)
		{
			char[] tempArray = { Values[0][3], Values[0][4], Values[0][5] };
			string packetType = new string(tempArray);

			return packetType switch
			{
				"RMC" => MessageType.RMC,
				"GNS" => MessageType.GNS,
				"GGA" => MessageType.GGA,
				"GLL" => MessageType.GLL,
				"VTG" => MessageType.VTG,
				"GSA" => MessageType.GSA,
				"GSV" => MessageType.GSV,
				_ => null,
			};
		}

		public bool IsTypeWithTime(Enum Type)
		{
			return Type switch
			{
				MessageType.RMC => true,
				MessageType.GNS => true,
				MessageType.GGA => true,
				MessageType.GLL => true,
				_ => false
			};
		}
		public enum GnssConstellation { GPS, GLONASS, GALILEO, MIX }
		public enum MessageType { RMC, GNS, GGA, GLL, VTG, GSA, GSV }

	}
}
