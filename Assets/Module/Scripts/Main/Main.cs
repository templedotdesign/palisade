using UnityEngine;
using System.Collections.Generic;

namespace Temple {
	public class Main : MonoBehaviour {
		[SerializeField]int width;
		[SerializeField]int height;

		[SerializeField]bool randomize;

		List<Agent> agents;

		TileMap map;
		Visualizer visualizer;
		Mouse mouse;

		Dictionary<Tile, GameObject> tileGOBindings;
		Dictionary<Agent, GameObject> agentGOBindings;

		void Start() {
			tileGOBindings = new Dictionary<Tile, GameObject> ();
			agentGOBindings = new Dictionary<Agent, GameObject> ();
			agents = new List<Agent> ();
			map = new TileMap (width, height);

			visualizer = GetComponent<Visualizer> ();
			mouse = GetComponent<Mouse> ();

			if (randomize) {
				map.RandomizeMap ();
			}

			visualizer.VisualizeWorldMap (map, tileGOBindings);
			mouse.AssociateMap (map, tileGOBindings);

			Tile center = map.GetTileAt (width / 2, height / 2);
			agents.Add (new Agent(new Vector2(center.X, center.Y), 1f, Species.BLUE));
			agents.Add (new Agent(new Vector2(center.X - 2, center.Y), 1f, Species.RED));
		}

		void Update() {
			foreach (Agent agent in agents) {
				agent.UpdateLocation ();
			}
			visualizer.VisualizeAgents (agents, agentGOBindings);
		}
	}//end class Main
}//end namespace Temple
