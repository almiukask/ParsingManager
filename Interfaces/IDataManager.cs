using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Models.Concrete;

namespace ParsingManager.Interfaces
{
	public interface IDataManager
	{
		public void CreateInstances(List<string> readFile);
		public List<Instance> GetInstances();
	}
}
