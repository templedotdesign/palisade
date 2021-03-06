﻿using UnityEngine;
using System.Collections.Generic;

namespace Temple {
	public class Mouse : MonoBehaviour {
		[SerializeField] bool outline;

		Vector2 position;
		Vector2 dragStartPosition;
		Vector2 dragEndPosition;

		int xIndex;
		int yIndex;

		TileMap worldMap;
		Dictionary<Tile, GameObject> tileGOBindings;


		public void AssociateMap(TileMap map, Dictionary<Tile, GameObject> bindings) {
			this.worldMap = map;
			this.tileGOBindings = bindings;
		}

		void Update() {
			this.position = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);

			this.xIndex = Mathf.FloorToInt (position.x);
			this.yIndex = Mathf.FloorToInt (position.y);

			if (WithinMapRange (worldMap, xIndex, yIndex) == false) {
				print ("Mouse is out of range.");
				return;
			}

			if (Input.GetMouseButtonDown (0)) {
				dragStartPosition = new Vector2 (xIndex, yIndex);
			}
			if (Input.GetMouseButton (0)) {
			
			}
			if (Input.GetMouseButtonUp (0)) {
				dragEndPosition = new Vector2 (xIndex, yIndex);
				DrawRect (dragStartPosition, dragEndPosition);
			}

		}

		bool WithinMapRange(TileMap map, int x, int y) {
			return (x >= 0 && x < map.Width) && (y >= 0 && y < map.Height);
		}
			
		void DrawRect(Vector2 start, Vector2 end) {
			int startX;
			int startY;
			int endX;
			int endY;

			if (start.x > end.x && start.y > end.y) {
				startX = (int)end.x;
				startY = (int)end.y;
				endX = (int)start.x;
				endY = (int)start.y;
			} else if (start.x < end.x && start.y < end.y ) {
				startX = (int)start.x;
				startY = (int)start.y;
				endX = (int)end.x;
				endY = (int)end.y;
			} else if (start.x < end.x && start.y > end.y ) {
				startX = (int)start.x;
				startY = (int)end.y;
				endX = (int)end.x;
				endY = (int)start.y;
			} else {
				startX = (int)end.x;
				startY = (int)start.y;
				endX = (int)start.x;
				endY = (int)end.y;
			}

			for (int x = startX; x <= endX; x++) {
				for (int y = startY; y <= endY; y++) {
					if (outline) {
						if ((x != startX && x != endX) && (y != startY && y != endY)) {
							continue;
						}
					}
					Tile t = worldMap.GetTileAt (x, y);
					tileGOBindings [t].GetComponentInChildren<SpriteRenderer> ().color = Color.blue;
				}
			}
		}
	}//end class Mouse
}//end namespace Temple
