using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShortestPath {
	static class MapLayout {
		public static List<Waypoint> WaypointList = new List<Waypoint>();
		public static List<WaypointPair> WaypointPairs = new List<WaypointPair>();
		public static Waypoint StartWaypoint;
		public static Waypoint EndWaypoint;

		public static void clearLayout() {

		}

		public static void addWaypoint(int X, int Y) {
			Waypoint tempWP = new Waypoint(X, Y);
			if (overlapsExistingWaypoint(tempWP) == false) {
				WaypointList.Add(tempWP);
			}
			Forms.MainFrm.UpdatePictureBox();
		}

		public static void addRelationship(Point Point1, Point Point2) {
			Waypoint Waypoint1 = findClosestWaypoint(Point1);
			Waypoint Waypoint2 = findClosestWaypoint(Point2);
			if (Waypoint1.GUID != Waypoint2.GUID) {
				Waypoint1.addConnection(Waypoint2);
				Waypoint2.addConnection(Waypoint1);
			}
			updatePairList();
			Forms.MainFrm.UpdatePictureBox();
		}

		public static void updatePairList() {
			WaypointPairs.Clear();
			WaypointPair tempWPP = new WaypointPair();
			List<string> completedPairString = new List<string>();
			string tempPairString1, tempPairString2;
			foreach (Waypoint baseWP in MapLayout.WaypointList) {
				foreach (Waypoint targetWP in baseWP.listConnectedWaypoints()) {
					tempPairString1 = baseWP.GUID + " " + targetWP.GUID;
					tempPairString2 = targetWP.GUID + " " + baseWP.GUID;
					if (!completedPairString.Contains(tempPairString1) && !completedPairString.Contains(tempPairString2)) {
						tempWPP.Waypoint1 = baseWP;
						tempWPP.Waypoint2 = targetWP;
						tempWPP.Distance = Functions.Distance(baseWP.Point, targetWP.Point);
						WaypointPairs.Add(tempWPP);
						completedPairString.Add(tempPairString1);
					}
				}
			}
		}

		public static void markConnections(Waypoint inputWP) {
			double tempDist;
			foreach (Waypoint currentConn in inputWP.listConnectedWaypoints()) {
				if (currentConn.Visited == false) {
					tempDist = Functions.Distance(inputWP.Point, currentConn.Point);
					currentConn.Value = inputWP.Value + tempDist;
				}
			}
			Forms.MainFrm.UpdatePictureBox();
		}

		public static void addStart(Point inputPoint) {
			Waypoint closestWP = findClosestWaypoint(inputPoint);
			if (!closestWP.isEnd) {
				closestWP.isStart = true;
				closestWP.Value = 0;
				StartWaypoint = closestWP;
				Forms.MainFrm.UpdatePictureBox();
			}
		}

		public static void addEnd(Point inputPoint) {
			Waypoint closestWP = findClosestWaypoint(inputPoint);
			if (!closestWP.isStart) {
				closestWP.isEnd = true;
				EndWaypoint = closestWP;
				Forms.MainFrm.UpdatePictureBox();
			}

		}

		private static Boolean overlapsExistingWaypoint(Waypoint inputWP) {
			foreach (Waypoint currentWP in WaypointList) {
				if (Functions.Distance(inputWP.Point, currentWP.Point) < 10) {
					return true;
				}
			}
			return false;
		}

		private static Waypoint findClosestWaypoint(Point inputPoint) {
			Waypoint closestWP = new Waypoint(-9999, -9999);
			double tempDistance;
			double closestDistance = Functions.Distance(closestWP.Point, inputPoint);
			foreach (Waypoint currentWP in WaypointList) {
				tempDistance = Functions.Distance(currentWP.Point, inputPoint);
				if (tempDistance < closestDistance) {
					closestWP = currentWP;
					closestDistance = tempDistance;
				}
			}
			return closestWP;
		}

		public static void printWaypointList() {
			foreach (Waypoint currentWP in WaypointList) {
				Console.WriteLine(currentWP.GUID + " - (" + currentWP.Point.X.ToString() + ", " + currentWP.Point.Y.ToString() + ")");
			}
		}

		public static Waypoint GUIDToWaypoint(string GUID) {
			foreach (Waypoint tempWP in WaypointList) {
				if (tempWP.GUID == GUID) {
					return tempWP;
				}
			}
			return null;
		}

	}
}

