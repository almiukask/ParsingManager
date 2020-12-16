
namespace NMEA_Parser
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtFilepath = new System.Windows.Forms.TextBox();
			this.lblFilePath = new System.Windows.Forms.Label();
			this.DataGrid = new System.Windows.Forms.DataGridView();
			this.LoadFileBtn = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// txtFilepath
			// 
			this.txtFilepath.Location = new System.Drawing.Point(10, 27);
			this.txtFilepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFilepath.Name = "txtFilepath";
			this.txtFilepath.Size = new System.Drawing.Size(791, 23);
			this.txtFilepath.TabIndex = 1;
			// 
			// lblFilePath
			// 
			this.lblFilePath.AutoSize = true;
			this.lblFilePath.Location = new System.Drawing.Point(10, 10);
			this.lblFilePath.Name = "lblFilePath";
			this.lblFilePath.Size = new System.Drawing.Size(52, 15);
			this.lblFilePath.TabIndex = 2;
			this.lblFilePath.Text = "File Path";
			// 
			// DataGrid
			// 
			this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGrid.Location = new System.Drawing.Point(10, 54);
			this.DataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.RowHeadersWidth = 51;
			this.DataGrid.RowTemplate.Height = 29;
			this.DataGrid.Size = new System.Drawing.Size(926, 305);
			this.DataGrid.TabIndex = 3;
			// 
			// LoadFileBtn
			// 
			this.LoadFileBtn.Location = new System.Drawing.Point(807, 26);
			this.LoadFileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.LoadFileBtn.Name = "LoadFileBtn";
			this.LoadFileBtn.Size = new System.Drawing.Size(128, 22);
			this.LoadFileBtn.TabIndex = 8;
			this.LoadFileBtn.Text = "Select and Read";
			this.LoadFileBtn.UseVisualStyleBackColor = true;
			this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Multiselect = true;
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 368);
			this.Controls.Add(this.LoadFileBtn);
			this.Controls.Add(this.DataGrid);
			this.Controls.Add(this.lblFilePath);
			this.Controls.Add(this.txtFilepath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "NMEA parser";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtFilepath;
		private System.Windows.Forms.Label lblFilePath;
		private System.Windows.Forms.DataGridView DataGrid;
		private System.Windows.Forms.Button LoadFileBtn;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

