using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Models.Concrete;

namespace ParsingManager.Interfaces
{
	public interface IDataManager
	{
		public void CreateInstances(byte[] readFile);
		public List<Instance> GetInstances();
	}
}
