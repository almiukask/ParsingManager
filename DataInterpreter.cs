using System;
using System.Collections.Generic;
using System.Text;
using ParsingManager.Models.Concrete;
using ParsingManager.Interfaces;

namespace ParsingManager
{
	public class DataInterpreter : IDataInterpreter
	{
		public void CalculateAverages(Vehicle DataForCalculation)
		{
			DataForCalculation.DOPs[Vehicle.TypeOfDOP.HDOP] = CalculateAvgDOP(DataForCalculation.Data, Vehicle.TypeOfDOP.HDOP);
			DataForCalculation.DOPs[Vehicle.TypeOfDOP.VDOP] = CalculateAvgDOP(DataForCalculation.Data, Vehicle.TypeOfDOP.VDOP);
			DataForCalculation.DOPs[Vehicle.TypeOfDOP.PDOP] = CalculateAvgDOP(DataForCalculation.Data, Vehicle.TypeOfDOP.PDOP);
			CalculateAvgSVsCNO(DataForCalculation.Data, DataForCalculation);
			DataForCalculation.AvgSVinUse = CalculateAvgSVsInUse(DataForCalculation.Data);
			CalculateAvgSVsQ(DataForCalculation.Data, DataForCalculation);
		}
		double CalculateAvgDOP(List<Instance> data, Enum DOPType)
		{
			double sum = 0;
			int validDOPs = 0;
			switch (DOPType)
			{
				case Vehicle.TypeOfDOP.HDOP:
					{
						foreach (var instance in data)
						{
							if (IsValueValid(instance.HDOP))
							{
								CalculateSum(ref sum, instance.HDOP);
								validDOPs++;
							}
						}
						break;
					}
				case Vehicle.TypeOfDOP.VDOP:
					{
						foreach (var instance in data)
						{
							if (IsValueValid(instance.VDOP))
							{
								CalculateSum(ref sum, instance.VDOP);
								validDOPs++;
							}
						}
						break;
					}
				case Vehicle.TypeOfDOP.PDOP:
					{
						foreach (var instance in data)
						{
							if (IsValueValid(instance.PDOP))
							{
								CalculateSum(ref sum, instance.PDOP);
								validDOPs++;
							}
						}
						break;
					}
				default:
					{
						return 0;
					}
			}
			return validDOPs != 0 ? sum / validDOPs : 0;
		}
		void CalculateAvgSVsCNO(List<Instance> data, Vehicle DataForCalculation)
		{
			double sumGA = 0;
			int GACounter = 0;
			double sumGL = 0;
			int GLCounter = 0;
			double sumGP = 0;
			int GPCounter = 0;
			double sumGN = 0;
			int GNCounter = 0;
			foreach (var instance in data)
			{
				foreach (var satellite in instance.SatellitesInfo)
				{
					if ((IsValueValid(satellite.SatelliteCNO)))
					{
						switch (satellite.Constellation)
						{
							case MessageChecker.GnssConstellation.GPS:
								{
									CalculateSum(ref sumGP, (double)satellite.SatelliteCNO);
									GPCounter++;
									break;
								}
							case MessageChecker.GnssConstellation.GLONASS:
								{
									CalculateSum(ref sumGL, (double)satellite.SatelliteCNO);
									GLCounter++;
									break;
								}
							case MessageChecker.GnssConstellation.GALILEO:
								{
									CalculateSum(ref sumGA, (double)satellite.SatelliteCNO);
									GACounter++;
									break;
								}
							case MessageChecker.GnssConstellation.MIX:
								{
									CalculateSum(ref sumGN, (double)satellite.SatelliteCNO);
									GNCounter++;
									break;
								}
						}
					}
				}
			}
			if (GPCounter != 0) DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.GPS] = sumGP / GPCounter;
			else DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.GPS] = 0;
			if (GLCounter != 0) DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.GLONASS] = sumGL / GLCounter;
			else DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.GLONASS] = 0;
			if (GACounter != 0) DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.GALILEO] = sumGA / GACounter;
			else DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.GALILEO] = 0;
			if (GNCounter != 0) DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.MIX] = sumGN / GNCounter;
			else DataForCalculation.AvgSatellitesCNO[MessageChecker.GnssConstellation.MIX] = 0;
		}

		void CalculateSum(ref double suma, double number)
		{
			suma += number;
		}

		bool IsValueValid(double value)
		{
			if (value < 99 && value > 0) return true;
			else return false;
		}

		void CalculateAvgSVsQ(List<Instance> data, Vehicle DataForCalculation)
		{
			double sum = 0;
			int counter = 0;
			foreach (var instance in data)
			{
				if (instance.QuantityOfSatellites > 0)
				{
					sum += instance.SatellitesInfo.Count;
					counter++;
				}
			}
			if (counter != 0) DataForCalculation.AvgQuantOfSatellites = sum / counter; else DataForCalculation.AvgQuantOfSatellites = 0;
		}
		double CalculateAvgSVsInUse(List<Instance> data)
		{
			double sum = 0;
			int counter = 0;
			foreach (var instance in data)
			{
				if (instance.NumberOfSVsUsed > 0)
				{
					sum += instance.NumberOfSVsUsed;
					counter++;
				}
			}
			return counter != 0 ? sum / counter : 0;
		}

	}
}
