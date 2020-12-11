using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.Interfaces 
{
	public interface IMessage : IReceiveRequiredData
	{
		public bool CheckDataSize();
		public void FillMesage();
		public IMessage GetData();

	}
}
