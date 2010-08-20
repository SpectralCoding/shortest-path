using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShortestPath {
	public partial class MainFrm : Form {
		public MainFrm() {
			InitializeComponent();
		}

		public int currentStep = 1;
		private Boolean firstPoint = true;
		private Point Point1, Point2;

		public delegate void UpdatePictureBoxDelegate();
		public void UpdatePictureBox() {
			if (this.InvokeRequired) {
				this.Invoke(new UpdatePictureBoxDelegate(UpdatePictureBox));
			} else {
				MapPB.Image = MapGfx.drawMap();
			}
		}

		private void MapPB_Click(object sender, EventArgs e) {
			
		}

		private void DebugCmd_Click(object sender, EventArgs e) {
			MapLayout.printWaypointList();
		}

		private void MapPB_MouseClick(object sender, MouseEventArgs e) {
			if (currentStep == 1) {
				MapLayout.addWaypoint(e.X, e.Y);
			} else if (currentStep == 2) {
				if (firstPoint == true) {
					firstPoint = false;
					Point1.X = e.X; Point1.Y = e.Y;
				} else if (firstPoint == false) {
					firstPoint = true;
					Point2.X = e.X; Point2.Y = e.Y;
					MapLayout.addRelationship(Point1, Point2);
				}
			} else if (currentStep == 3) {
				MapLayout.addStart(new Point(e.X, e.Y));
				NextStepCmd_Click(null, null);
			} else if (currentStep == 4) {
				MapLayout.addEnd(new Point(e.X, e.Y));
				NextStepCmd_Click(null, null);
			}
		}

		private void MainFrm_Load(object sender, EventArgs e) {
			Forms.MainFrm = this;
			MapLayout.addWaypoint(107, 74);
			MapLayout.addWaypoint(72, 424);
			MapLayout.addWaypoint(158, 303);
			MapLayout.addWaypoint(285, 77);
			MapLayout.addWaypoint(234, 190);
			MapLayout.addWaypoint(384, 403);
			MapLayout.addWaypoint(283, 432);
			MapLayout.addWaypoint(452, 208);
			MapLayout.addWaypoint(104, 241);
			MapLayout.addWaypoint(321, 347);
			NextStepCmd_Click(null, null);
			MapLayout.addRelationship(new Point(107, 74), new Point(104, 241));
			MapLayout.addRelationship(new Point(104, 241), new Point(72, 424));
			MapLayout.addRelationship(new Point(107, 74), new Point(285, 77));
			MapLayout.addRelationship(new Point(285, 77), new Point(452, 208));
			MapLayout.addRelationship(new Point(452, 208), new Point(384, 403));
			MapLayout.addRelationship(new Point(384, 403), new Point(283, 432));
			MapLayout.addRelationship(new Point(283, 432), new Point(72, 424));
			MapLayout.addRelationship(new Point(104, 241), new Point(158, 303));
			MapLayout.addRelationship(new Point(158, 303), new Point(72, 424));
			MapLayout.addRelationship(new Point(158, 303), new Point(283, 432));
			MapLayout.addRelationship(new Point(158, 303), new Point(321, 347));
			MapLayout.addRelationship(new Point(104, 241), new Point(234, 190));
			MapLayout.addRelationship(new Point(234, 190), new Point(321, 347));
			MapLayout.addRelationship(new Point(234, 190), new Point(107, 74));
			MapLayout.addRelationship(new Point(321, 347), new Point(384, 403));
			MapLayout.addRelationship(new Point(234, 190), new Point(452, 208));
			MapLayout.addRelationship(new Point(234, 190), new Point(285, 77));
			MapLayout.addRelationship(new Point(321, 347), new Point(283, 432));
			MapLayout.addRelationship(new Point(158, 303), new Point(234, 190));
			MapLayout.addRelationship(new Point(321, 347), new Point(452, 208));
			NextStepCmd_Click(null, null);
			MapLayout.addStart(new Point(107, 74));
			NextStepCmd_Click(null, null);
			MapLayout.addEnd(new Point(283, 432));
			NextStepCmd_Click(null, null);
			MapLayout.markConnections(MapLayout.StartWaypoint);
		}

		private void NextStepCmd_Click(object sender, EventArgs e) {
			if (currentStep == 1) {
				currentStep++;
				StatusLbl.Text = "Step 2: Setup Relationships (Pick Two Points)";
			} else if (currentStep == 2) {
				if (firstPoint == false) {
					firstPoint = true;
					Point1.X = -1; Point1.Y = -1;
					Point2.X = -1; Point2.Y = -1;
				}
				currentStep++;
				StatusLbl.Text = "Step 3: Pick Start Point";
			} else if (currentStep == 3) {
				currentStep++;
				StatusLbl.Text = "Step 4: Pick End Point";
			} else if (currentStep == 4) {
				currentStep++;
				StatusLbl.Text = "Finished!";
			}

		}
	}
}
