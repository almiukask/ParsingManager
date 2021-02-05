using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Interfaces;
using ParsingManager.Models.Concrete;
using ParsingManager.Models.Concrete.Messages;
using ParsingManager;
using System.Linq;
using System.Text.RegularExpressions;


namespace ParsingManager.DL
{
	public class DataManager : IDataManager
	{
		public List<Instance> Instances = new List<Instance>();
		public void CreateInstances(List<string> readFile)
		{

			IReceiveRequiredData _receiver;
			ITimeInfo _timeInfo;
			IMessageChecker _checker;
			int instanceCounter = 0;
			bool firstMessage = true;
			Enum StartingMessageType = null;
			double lastKnownTime = 0;
			double currentTime = 0;
			_checker = new MessageChecker();

			foreach (var Line in readFile)
			{
				string[] values;
				if (_checker.IsStructureValid(Line))
				{
					values = _checker.SeparetValues(Line);
					Dictionary<Enum, Lazy<IMessage>> MessageLoader = new Dictionary<Enum, Lazy<IMessage>>
				{
				{ MessageChecker.MessageType.GGA, new Lazy<IMessage>(() => new GGA(values)) },
				{ MessageChecker.MessageType.GLL, new Lazy<IMessage>(() => new GLL(values)) },
				{ MessageChecker.MessageType.GNS, new Lazy<IMessage>(() => new GNS(values)) },
				{ MessageChecker.MessageType.GSA, new Lazy<IMessage>(() => new GSA(values)) },
				{ MessageChecker.MessageType.GSV, new Lazy<IMessage>(() => new GSV(values)) },
				{ MessageChecker.MessageType.VTG, new Lazy<IMessage>(() => new VTG(values)) },
				{ MessageChecker.MessageType.RMC, new Lazy<IMessage>(() => new RMC(values)) }
				};
					var type = _checker.GetMessageType(values);
					if (type != null)
					{

						if (MessageLoader[type].Value.CheckDataSize())
						{
							if (firstMessage)
							{
								StartingMessageType = type;
								firstMessage = false;
							}
							MessageLoader[type].Value.FillMesage();
							var _message = MessageLoader[type].Value.GetData();
							if (_checker.IsTypeWithTime(type))
							{
								_timeInfo = (ITimeInfo)MessageLoader[type].Value;
								currentTime = _timeInfo.GetCurrentTime();
							}
							if (type.Equals(StartingMessageType) || (currentTime > lastKnownTime))
							{
								if (Instances.Count != 0) instanceCounter++;
								Instances.Add(new Instance());
								StartingMessageType = type;
								lastKnownTime = currentTime;
							}
							_receiver = _message;
							_receiver.RetrieveSelectedData(Instances[instanceCounter]);
						}
					}

				}
			}
		}
		//List<string> FormLines(byte[] readFile)
		//{
		//	string Input = Encoding.ASCII.GetString(readFile);
		//	List<string> lines = new List<string>();
		//	var match0 = Regex.Matches(Input, @"\$G([A-Z]{4}),(.*?)\*([0-9A-F]{2})", RegexOptions.Singleline);

		//	return lines;
		//}
		public List<Instance> GetInstances()
		{
			return Instances;
		}



	}
}
