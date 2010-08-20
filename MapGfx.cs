using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ShortestPath {
	static class MapGfx {
		public static Bitmap drawMap() {
			Bitmap bmpReturn = new Bitmap(500, 500);
			Pen blackPen = new Pen(Color.Black, 1);
			Pen darkGrayPen = new Pen(Color.DarkGray, 1);
			Pen redPen = new Pen(Color.Red, 1);
			SolidBrush blackBrush = new SolidBrush(Color.Black);
			SolidBrush orangeBrush = new SolidBrush(Color.Orange);
			Graphics gfxBitmap = Graphics.FromImage(bmpReturn);

			foreach (Waypoint currentWP in MapLayout.WaypointList) {
				if (currentWP.isStart || currentWP.isEnd) {
					gfxBitmap.FillEllipse(orangeBrush, (currentWP.Point.X - 25), (currentWP.Point.Y - 25), 50, 50);
				} else {
					gfxBitmap.FillEllipse(blackBrush, (currentWP.Point.X - 25), (currentWP.Point.Y - 25), 50, 50);
				}
			}
			
			if (Forms.MainFrm.currentStep >= 2) {
				foreach (WaypointPair WPP in MapLayout.WaypointPairs) {
					string distStr = Math.Round(WPP.Distance, 0).ToString();
					gfxBitmap.DrawLine(darkGrayPen, WPP.Waypoint1.Point.X, WPP.Waypoint1.Point.Y, WPP.Waypoint2.Point.X, WPP.Waypoint2.Point.Y);
					Size tempSize = TextRenderer.MeasureText(gfxBitmap, distStr, new Font("Microsoft Sans Serif", 10), new Size(int.MaxValue, int.MaxValue));
					Point TLPoint = Functions.Midpoint(WPP.Waypoint1.Point, WPP.Waypoint2.Point);
					TLPoint.X -= tempSize.Width / 2;
					TLPoint.Y -= tempSize.Height / 2;
					gfxBitmap.DrawString(distStr, new Font("Microsoft Sans Serif", 10), Brushes.Black, TLPoint);
				}
			}

			if (Forms.MainFrm.currentStep >= 4) {
				foreach (Waypoint currentWP in MapLayout.WaypointList) {
					string valueStr = Math.Round(currentWP.Value, 0).ToString();
					Size tempSize = TextRenderer.MeasureText(gfxBitmap, valueStr, new Font("Microsoft Sans Serif", 10), new Size(int.MaxValue, int.MaxValue));
					Point TLPoint = new Point(currentWP.Point.X - (tempSize.Width / 2), currentWP.Point.Y - (tempSize.Height / 2));
					gfxBitmap.DrawString(valueStr, new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.White, TLPoint);
				}
			}

			return bmpReturn;
		}
	}
}
