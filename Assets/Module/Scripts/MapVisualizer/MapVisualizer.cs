using UnityEngine;
using System.Collections.Generic;

namespace Temple {
	public class MapVisualizer : MonoBehaviour {
		[SerializeField]Sprite blankSprite;
		[SerializeField]Sprite solidSprite;
		[SerializeField]Sprite liquidSprite;
		[SerializeField]Sprite gasSprite;


		public void VisualizeTileMap(TileMap map, Transform parent, Dictionary<Tile, GameObject> bindings) {
			for (int x = 0; x < map.Width; x++) {
				for (int y = 0; y < map.Height; y++) {
					Tile t = map.GetTileAt (x, y);
					GameObject tileGO = new GameObject ();
					tileGO.name = "Tile(" + x + ", " + y + ")";
					tileGO.transform.SetParent (parent);

					GameObject tileGraphics = new GameObject ();
					tileGraphics.name = "Graphics";
					tileGraphics.AddComponent<SpriteRenderer> ().sprite = SetSpriteByTileType(t);
					tileGraphics.transform.SetParent (tileGO.transform);

					tileGO.transform.position = new Vector2 (x, y);

					bindings.Add (t, tileGO);
				}
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
				print ("MapVisualizer::SetSpriteByTileType::UnrecognizedTileType:: " + type);
				return blankSprite;
			}
		}
	}//end class MapVisualizer
}//end namespace Temple
