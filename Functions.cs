using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShortestPath {
	static class Functions {
		public static double Distance(Point Point1, Point Point2) {
			double a = (double)(Point2.X - Point1.X);
			double b = (double)(Point2.Y - Point1.Y);
			return Math.Sqrt(a * a + b * b);
		}

		public static Point Midpoint(Point Point1, Point Point2) {
			return new Point(((Point1.X + Point2.X)/2), ((Point1.Y + Point2.Y)/2));
		}

	}
}
