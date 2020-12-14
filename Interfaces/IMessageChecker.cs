using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Interfaces
{
	public interface IMessageChecker
	{
		public bool IsStructureValid(string parsingLine);
		public string[] SeparetValues(string parsingLine);
		public Enum GetConstellation(string[] Values);
		public Enum GetMessageType(string[] Values);
		public bool IsTypeWithTime(Enum Type);


	}
}
