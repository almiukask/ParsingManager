using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingManager.DL.Interfaces
{
	public interface IMessageService
	{
		public bool CheckDataSize();
		public void FillMesage();

		public object GetData();
	}
}
