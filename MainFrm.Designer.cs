namespace ShortestPath {
	partial class MainFrm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.MapPB = new System.Windows.Forms.PictureBox();
			this.StatusLbl = new System.Windows.Forms.Label();
			this.NextStepCmd = new System.Windows.Forms.Button();
			this.DebugCmd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.MapPB)).BeginInit();
			this.SuspendLayout();
			// 
			// MapPB
			// 
			this.MapPB.BackColor = System.Drawing.Color.White;
			this.MapPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapPB.Location = new System.Drawing.Point(12, 12);
			this.MapPB.Name = "MapPB";
			this.MapPB.Size = new System.Drawing.Size(500, 500);
			this.MapPB.TabIndex = 0;
			this.MapPB.TabStop = false;
			this.MapPB.Click += new System.EventHandler(this.MapPB_Click);
			this.MapPB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapPB_MouseClick);
			// 
			// StatusLbl
			// 
			this.StatusLbl.AutoSize = true;
			this.StatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StatusLbl.Location = new System.Drawing.Point(8, 515);
			this.StatusLbl.Name = "StatusLbl";
			this.StatusLbl.Size = new System.Drawing.Size(172, 16);
			this.StatusLbl.TabIndex = 1;
			this.StatusLbl.Text = "Step 1: Draw Waypoints";
			// 
			// NextStepCmd
			// 
			this.NextStepCmd.Location = new System.Drawing.Point(437, 515);
			this.NextStepCmd.Name = "NextStepCmd";
			this.NextStepCmd.Size = new System.Drawing.Size(75, 23);
			this.NextStepCmd.TabIndex = 2;
			this.NextStepCmd.Text = "Next Step";
			this.NextStepCmd.UseVisualStyleBackColor = true;
			this.NextStepCmd.Click += new System.EventHandler(this.NextStepCmd_Click);
			// 
			// DebugCmd
			// 
			this.DebugCmd.Location = new System.Drawing.Point(356, 515);
			this.DebugCmd.Name = "DebugCmd";
			this.DebugCmd.Size = new System.Drawing.Size(75, 23);
			this.DebugCmd.TabIndex = 3;
			this.DebugCmd.Text = "Debug";
			this.DebugCmd.UseVisualStyleBackColor = true;
			this.DebugCmd.Click += new System.EventHandler(this.DebugCmd_Click);
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 550);
			this.Controls.Add(this.DebugCmd);
			this.Controls.Add(this.NextStepCmd);
			this.Controls.Add(this.StatusLbl);
			this.Controls.Add(this.MapPB);
			this.Name = "MainFrm";
			this.Text = "Shortest Path";
			this.Load += new System.EventHandler(this.MainFrm_Load);
			((System.ComponentModel.ISupportInitialize)(this.MapPB)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox MapPB;
		private System.Windows.Forms.Label StatusLbl;
		private System.Windows.Forms.Button NextStepCmd;
		private System.Windows.Forms.Button DebugCmd;
	}
}

