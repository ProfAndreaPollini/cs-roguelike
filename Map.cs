using System.Numerics;

internal class Map
{
    private int xCells;
    private int yCells;
    private Tile[] cells;

    public Map(int xCells, int yCells)
    {
        this.xCells = xCells;
        this.yCells = yCells;
        this.cells = new Tile[xCells * yCells];

        for (int i = 0; i < xCells * yCells; i++)
        {
            this.cells[i] = new();
        }

        this.cells[0].Kind = TileKind.WALL;
        this.cells[2].Kind = TileKind.WALL;
        this.cells[xCells + 1].Kind = TileKind.WALL;
    }

    public Tile CellAt(Vector2 pos)
    {
        return this.cells[(int)(pos.X + pos.Y * this.xCells)];
    }

}