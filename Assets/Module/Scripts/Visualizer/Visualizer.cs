using UnityEngine;
using System.Collections.Generic;

namespace Temple {
	public class Visualizer : MonoBehaviour {
		[SerializeField]Sprite blankSprite;
		[SerializeField]Sprite solidSprite;
		[SerializeField]Sprite liquidSprite;
		[SerializeField]Sprite gasSprite;
		[SerializeField]Sprite blueSprite;
		[SerializeField]Sprite redSprite;

		GameObject worldMapParent;
		GameObject agentsParent;

		void Start() {
			worldMapParent = new GameObject ();
			worldMapParent.name = "WorldMap";
			worldMapParent.transform.SetParent (this.transform);

			agentsParent = new GameObject ();
			agentsParent.name = "Agents";
			agentsParent.transform.SetParent (this.transform);
		}

		public void VisualizeWorldMap(TileMap map, Dictionary<Tile, GameObject> bindings) {
			for (int x = 0; x < map.Width; x++) {
				for (int y = 0; y < map.Height; y++) {
					Tile t = map.GetTileAt (x, y);
					GameObject tileGO = new GameObject ();
					tileGO.name = "Tile(" + x + ", " + y + ")";
					tileGO.transform.SetParent (worldMapParent.transform);

					GameObject tileGraphics = new GameObject ();
					tileGraphics.name = "Graphics";
					tileGraphics.AddComponent<SpriteRenderer> ().sprite = SetSpriteByTileType(t);
					tileGraphics.transform.SetParent (tileGO.transform);

					tileGO.transform.position = new Vector2 (x, y);

					bindings.Add (t, tileGO);
				}
			}
		}

		public void VisualizeAgents(List<Agent> agents, Dictionary<Agent, GameObject> bindings) {
			foreach (Agent agent in agents) {
				if (bindings.ContainsKey (agent) == false) {
					GameObject agentGO = new GameObject ();
					int random = Random.Range (0, int.MaxValue);
					agentGO.name = "Agent " + random;

					GameObject agentGraphics = new GameObject ();
					agentGraphics.name = "Graphics";
					agentGraphics.AddComponent<SpriteRenderer> ().sprite = SetSpriteBySpecies (agent);
					agentGraphics.transform.SetParent (agentGO.transform);

					bindings.Add (agent, agentGO);
				}

				bindings [agent].transform.position = agent.Location;
			}
		}

		Sprite SetSpriteByTileType(Tile t) {
			TileTypes type = t.TileType;
			switch(type) {
			case TileTypes.SOLID:
				return solidSprite;
			case TileTypes.LIQUID:
				return liquidSprite;
			case TileTypes.GAS:
				return gasSprite;
			default:
				print ("MapVisualizer::SetSpriteByTileType::UnrecognizedTileType::" + type);
				return blankSprite;
			}
		}

		Sprite SetSpriteBySpecies(Agent a) {
			Species species = a.Species;
			switch(species) {
			case Species.BLUE:
				return blueSprite;
			case Species.RED:
				return redSprite;
			default:
				print ("MapVisualizer::SetSpriteBySpecies::UnrecognizedSpecies::" + species);
				return blankSprite;
			}
		}
	}//end class MapVisualizer
}//end namespace Temple
