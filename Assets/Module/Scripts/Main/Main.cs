using UnityEngine;
using System.Collections.Generic;

namespace Temple {
	public class Main : MonoBehaviour {
		[SerializeField]int width;
		[SerializeField]int height;

		[SerializeField]bool randomize;

		TileMap map;
		MapVisualizer mapViz;
		Mouse mouse;

		Dictionary<Tile, GameObject> tileGOBindings;

		TileMap Map { get { return map; }}

		void Start() {

			tileGOBindings = new Dictionary<Tile, GameObject> ();
			map = new TileMap (width, height);

			mapViz = GetComponent<MapVisualizer> ();
			mouse = GetComponent<Mouse> ();

			if (randomize) {
				map.RandomizeMap ();
			}

			mapViz.VisualizeTileMap (map, this.transform, tileGOBindings);
			mouse.AssociateMap (map, tileGOBindings);

		}

		void Update() {
		}
	}//end class Main
}//end namespace Temple
