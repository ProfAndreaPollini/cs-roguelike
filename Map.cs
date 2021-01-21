using System;
using System.Numerics;

internal class Map
{
    public Map(int Width, int Height)
    {
        this.Width = Width;
        this.Height = Height;
        this.Tiles = new Tile[Height][];
        for (int i = 0; i < Height; i++)
        {
            this.Tiles[i] = new Tile[Width];
        }
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                this.Tiles[i][j] = new Tile();
            }
        }
        for (int i = 5; i < 20; i++)
        {
            this.Tiles[i][i].Kind = TileKind.WALL;
        }
    }
    public Tile this[int y, int x] => this.Tiles[y][x];
    public Tile GetTile(int y, int x) => this.Tiles[y][x];
    private Tile[][] Tiles; //! ci accediamo con Tile[y][x]
    public int Width { get; }
    public int Height { get; }
}

// internal class Map
// {
//     private int XCells { get; }
//     private int YCells { get; }
//     public int CELL_SIZE { get; }

//     private Tile[] cells;

//     public Map(int xCells, int yCells)
//     {
//         this.XCells = xCells;
//         this.YCells = yCells;
//         this.cells = new Tile[xCells * yCells];

//         for (int i = 0; i < xCells * yCells; i++)
//         {
//             this.cells[i] = new();
//         }

//         this.cells[0].Kind = TileKind.WALL;
//         this.cells[2].Kind = TileKind.WALL;
//         this.cells[xCells + 1].Kind = TileKind.WALL;
//     }

//     public Map(int xCells, int yCells, int cELL_SIZE) : this(xCells, yCells)
//     {
//         CELL_SIZE = cELL_SIZE;
//     }

//     public Tile this[int x, int y] => this.cells[(int)(x + y * this.XCells)];



// }