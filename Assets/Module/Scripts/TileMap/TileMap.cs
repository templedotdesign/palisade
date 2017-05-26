namespace Temple {
	public class TileMap {
		Tile[,] tiles;

		public int Width { get; }
		public int Height { get; }

		public TileMap(int mapWidth, int mapHeight) {
			tiles = new Tile[mapWidth, mapHeight];
			for (int x = 0; x < mapWidth; x++) {
				for (int y = 0; y < mapHeight; y++) {
					tiles [x, y] = new Tile (x, y);
				}
			}
			Width = tiles.GetLength (0);
			Height = tiles.GetLength (1);
		}

		public Tile GetTileAt(int x, int y) {
			return tiles [x, y];
		}

		public void RandomizeMap() {
			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					Tile t = GetTileAt (x, y);
					int random = UnityEngine.Random.Range (0, 3);
					switch (random) {
					case 0:
						t.SetType (TileTypes.SOLID);
						break;
					case 1:
						t.SetType (TileTypes.LIQUID);
						break;
					case 2:
						t.SetType (TileTypes.GAS);
						break;
					default:
						break;
					}
				}
			}	
		}
	}//end class TileMap
}//end namespace Temple
