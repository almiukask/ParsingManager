using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Interfaces;
using ParsingManager.Models.Concrete;
using ParsingManager.Models.Concrete.Messages;
using ParsingManager;

namespace ExecutablePlayground
{
	class Program
	{
		static void Main(string[] args)
		{
			//string Bandymas = "$GPGSV,3,3,11,23,13,107,32,26,26,281,33,30,64,213,37*43\n\r";
			string[] Bandymas2 = {
				"$GPRMC,124748.00,A,5448.08452,N,02509.74067,E,63.156,330.72,170215,,,A*5A",
				"$GPVTG,330.72,T,,M,63.156,N,116.966,K,A*00",
				"$GPGGA,124748.00,5448.08452,N,02509.74067,E,1,10,0.87,169.4,M,25.7,M,,*5E",
				"$GPGSA,A,3,09,13,02,07,30,05,10,20,16,23,,,1.46,0.87,1.17*04",
				"$GPGSV,3,1,11,02,13,251,21,05,43,295,34,07,77,093,31,09,43,108,29*76",
				"$GPGSV,3,2,11,10,50,195,35,13,13,281,29,16,17,034,19,20,29,178,26*7A",
				"$GPGSV,3,3,11,23,13,107,32,26,26,281,33,30,64,213,37*43",
				"$GPGLL,5448.08452,N,02509.74067,E,124748.00,A,A*6F"
					};
			Instance instance = new Instance();
			foreach (var Bandymas in Bandymas2)
			{
				string[] Values;

				MessageChecker _parser = new MessageChecker(Bandymas);
				if (_parser.IsStructureValid())
				{
					Values = _parser.SeparetValues();
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
					//_parser.GetMessageType(Values);
					if (MessageLoader[_parser.GetMessageType(Values)].Value.CheckDataSize())
					{
						MessageLoader[_parser.GetMessageType(Values)].Value.FillMesage();
						var _message = MessageLoader[_parser.GetMessageType(Values)].Value.GetData();

						IReceiveRequiredData receiver;
						receiver = _message;
						receiver.RetrieveSelectedData(instance);

						//instance.UpdateAvailableInstanceData(_GSV);
						//Console.WriteLine(_VTG.Speed);
					}
				}
			}
			Console.WriteLine();
		}
	}
}
