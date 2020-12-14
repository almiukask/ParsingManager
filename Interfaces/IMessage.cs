using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Interfaces 
{
	public interface IMessage : IReceiveRequiredData
	{
		public bool CheckDataSize(string[] separatedFields);
		public void FillMesage(string[] separatedFields);
		public IMessage GetData();

	}
}
