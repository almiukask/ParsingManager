using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.DL.Interfaces
{
	public interface IMessage
	{
		public bool CheckDataSize();
		public void FillMesage();
		public IMessage GetData();
	}
}
