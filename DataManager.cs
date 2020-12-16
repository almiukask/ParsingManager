using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Interfaces;
using ParsingManager.Models.Concrete;
using ParsingManager.Models.Concrete.Messages;
using ParsingManager;
using System.Linq;


namespace ParsingManager.DL
{
	public class DataManager : IDataManager
	{
		public List<Instance> Instances = new List<Instance>();
		public void CreateInstances(byte[] readFile)
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
			foreach (var Line in FormLines(readFile))
			{
				string[] Values;	
				if (_checker.IsStructureValid(Line)) 
				{
					Values = _checker.SeparetValues(Line);
					Dictionary<Enum, Lazy<IMessage>> MessageLoader = new Dictionary<Enum, Lazy<IMessage>>
				{
				{ MessageChecker.MessageType.GGA, new Lazy<IMessage>(() => new GGA(Values)) },
				{ MessageChecker.MessageType.GLL, new Lazy<IMessage>(() => new GLL(Values)) },
				{ MessageChecker.MessageType.GNS, new Lazy<IMessage>(() => new GNS(Values)) },
				{ MessageChecker.MessageType.GSA, new Lazy<IMessage>(() => new GSA(Values)) },
				{ MessageChecker.MessageType.GSV, new Lazy<IMessage>(() => new GSV(Values)) },
				{ MessageChecker.MessageType.VTG, new Lazy<IMessage>(() => new VTG(Values)) },
				{ MessageChecker.MessageType.RMC, new Lazy<IMessage>(() => new RMC(Values)) }
				};
					var type = _checker.GetMessageType(Values);
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
		List<string> FormLines(byte[] readFile)
		{
			string[] LineDelimiters = { "\r\n", "\n" };
			string Input = Encoding.ASCII.GetString(readFile);
			List<string> lines = new List<string>();
			lines = Input.Split(LineDelimiters[0]).ToList();
			if (lines.Count <= 1)
				lines = Input.Split(LineDelimiters[1]).ToList();
			return lines;
		}
		public List<Instance> GetInstances()
		{
			return Instances;
		}



	}
}
