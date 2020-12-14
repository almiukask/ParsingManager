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
	public class DataManager 
	{
		public List<Instance> Instances = new List<Instance>();
		public void CreateInstances(byte[] readFile)
		{
			
			IReceiveRequiredData receiver;
			ITimeInfo timeInfo;
			IMessageChecker checker;
			int instanceCounter = 0;
			bool firstMessage = true;
			Enum StartingMessageType = null;
			double lastKnownTime = 0;
			double currentTime = 0;
			string Input = System.Text.Encoding.ASCII.GetString(readFile);
			List<string> Lines = Input.Split("\r\n").ToList();
			checker = new MessageChecker();
			foreach (var Line in Lines)
			{
				string[] Values;	
				if (checker.IsStructureValid(Line)) 
				{
					Values = checker.SeparetValues(Line);
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
					var type = checker.GetMessageType(Values);
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
							if (checker.IsTypeWithTime(type)) 
							{
								timeInfo = (ITimeInfo)MessageLoader[type].Value;
								currentTime = timeInfo.GetCurrentTime();
							}
							if (type.Equals(StartingMessageType) || (currentTime > lastKnownTime))
							{
								if (Instances.Count != 0) instanceCounter++;
								Instances.Add(new Instance());
								StartingMessageType = type;
								lastKnownTime = currentTime;
							}
							receiver = _message;
							receiver.RetrieveSelectedData(Instances[instanceCounter]);
						}
					}

				}
			}
		}
		public List<Instance> GetInstances()
		{
			return Instances;
		}



	}
}
