using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParsingManager.DL;
using ParsingManager.DL.Services;
using ParsingManager.Models.Concrete;
using ParsingManager;
using ParsingManager.Interfaces;


namespace NMEA_Parser
{
	public partial class Form1 : Form
	{
		IFileUploader _uploader; 
		IDataManager _fileHandler;
		IDataInterpreter _interpreter;
		public Form1()
		{
			InitializeComponent();
		}

		private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{

		}

		private void LoadFileBtn_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "txt files (*.txt)|*.txt|ubx files (*.ubx)|*.ubx|All files (*.*)|*.*";
			PrepareGridView();
			StringBuilder pathsToShow = new StringBuilder();
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
				//string[] names=openFileDialog1.FileNames;
				List<Vehicle> DUTs = new List<Vehicle>();
				int counter = 0;
				foreach (var name in openFileDialog1.FileNames)
				{
					byte[] File;
					_uploader= new FileUploader();
					File = _uploader.ReadFileStream(name);
					_fileHandler = new DataManager();
					_fileHandler.CreateInstances(File);
					DUTs.Add(new Vehicle { Data = _fileHandler.GetInstances() });
					_interpreter = new DataInterpreter();
					_interpreter.CalculateAverages(DUTs[counter]);
					counter++;
					pathsToShow.Append($"\"{name}\"");
					pathsToShow.AppendLine();
					
				}
				txtFilepath.Text = pathsToShow.ToString();
				ConstructColumns();
				LoadDataToGrid(DUTs, openFileDialog1.SafeFileNames);
				
			}
			

		}
		void PrepareGridView()
		{
			DataGrid.AllowUserToDeleteRows = false;
			DataGrid.ReadOnly = true;
			DataGrid.DefaultCellStyle.Format = "0.0##";
			DataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			DataGrid.Rows.Clear();
			DataGrid.Columns.Clear();
			DataGrid.Refresh();
		}

		private void LoadDataToGrid(List<Vehicle> duts, string[] names )
		{
			int cnt = 0;
			foreach (var name in names)
			{
				DataGrid.Rows.Add(new object[]
				{
					name,
					duts[cnt].DOPs[Vehicle.TypeOfDOP.PDOP],
					duts[cnt].DOPs[Vehicle.TypeOfDOP.HDOP],
					duts[cnt].DOPs[Vehicle.TypeOfDOP.VDOP],
					duts[cnt].AvgQuantOfSatellites,
					duts[cnt].AvgSVinUse,
					duts[cnt].AvgSatellitesCNO[MessageChecker.GnssConstellation.GPS],
					duts[cnt].AvgSatellitesCNO[MessageChecker.GnssConstellation.GLONASS],
					duts[cnt].AvgSatellitesCNO[MessageChecker.GnssConstellation.GALILEO]
				});
				cnt++;
			}
		}

		private void ConstructColumns()
		{

			DataGrid.Columns.Add("Device", "Device");
			DataGrid.Columns.Add("PDOP", "PDOP");
			DataGrid.Columns.Add("HDOP", "HDOP");
			DataGrid.Columns.Add("VDOP", "VDOP");
			DataGrid.Columns.Add("SVs Tracked", "SVs Tracked");
			DataGrid.Columns.Add("SVs Used", "SVs Used");
			DataGrid.Columns.Add("GPS C/N0", "GPS C/N0");
			DataGrid.Columns.Add("GLONASS C/N0", "GLONASS C/N0");
			DataGrid.Columns.Add("GALILEO C/N0", "GALILEO C/N0");
		}
		private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

		private void BtnLoad_Click(object sender, EventArgs e)
		{

		}
	}
}
