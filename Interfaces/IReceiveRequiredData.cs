using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Models.Concrete;

namespace ParsingManager.Interfaces
{
	public interface IReceiveRequiredData 
	{
		public void RetrieveSelectedData(Instance instance);
	}
}
