using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShortestPath {
	class Waypoint {
		public Point Point;
		public string GUID;
		public List<string> pairGUIDList = new List<string>();
		public Boolean isStart = false;
		public Boolean isEnd = false;
		public double Value = 99999.9;
		public Boolean Visited = false;

		public Waypoint(int X, int Y) {
			Point.X = X;
			Point.Y = Y;
			GUID = System.Guid.NewGuid().ToString();
		}

		public void addConnection(Waypoint inputWP) {
			if (!pairGUIDList.Contains(inputWP.GUID)) { 
				pairGUIDList.Add(inputWP.GUID);
			}
		}

		public List<Waypoint> listConnectedWaypoints() {
			List<Waypoint> tempWPList = new List<Waypoint>();
			foreach (string GUID in pairGUIDList) {
				tempWPList.Add(MapLayout.GUIDToWaypoint(GUID));
			}
			return tempWPList;
		}

	}

	struct WaypointPair {
		public Waypoint Waypoint1;
		public Waypoint Waypoint2;
		public double Distance;
	}

}
