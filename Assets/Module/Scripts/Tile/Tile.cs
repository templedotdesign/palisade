namespace Temple {
	public class Tile {
		int x;
		int y;
		TileTypes tileType;

		public int X { get { return x; }}
		public int Y { get { return y; }}
		public TileTypes TileType { get { return tileType; }}

		public Tile(int xIndex, int yIndex) {
			this.x = xIndex;
			this.y = yIndex;
			this.tileType = TileTypes.DEFAULT;
		}

		public Tile(int xIndex, int yIndex, TileTypes typeToSet) {
			this.x = xIndex;
			this.y = yIndex;
			this.tileType = typeToSet;
		}

		public void SetType(TileTypes typeToSet) {
			this.tileType = typeToSet;
		}
	}//end class Tile
}//end namespace Temple
