using Raylib_cs;

namespace Rendering
{
    internal class MapRenderModel : RenderModel
    {
        public MapRenderModel(Map map)
        {
            Map = map;
        }

        public Map Map { get; }

        public override void Render(OrtoCamera camera)
        {
            for (int i = 0; i < camera.Viewport.H; i++)
            {
                for (int j = 0; j < camera.Viewport.W; j++)
                {
                    Tile c = Map[j, i];
                    switch (c.Kind)
                    {
                        case TileKind.TERRAIN:
                            //Console.WriteLine(i + " " + j);
                            (int x, int y) terrainPos = CellToScreen(j, i);
                            terrainPos.x -= (int)(0.5 * CELL_SIZE);
                            terrainPos.y -= (int)(0.5 * CELL_SIZE);
                            Raylib.DrawRectangle(terrainPos.x, terrainPos.y, terrainPos.x + CELL_SIZE, terrainPos.y + CELL_SIZE, Color.LIME);
                            break;
                        case TileKind.WALL:
                            //Console.WriteLine(i + " " + j);
                            (int x, int y) wallPos = CellToScreen(j, i);
                            wallPos.x -= (int)(0.5 * CELL_SIZE);
                            wallPos.y -= (int)(0.5 * CELL_SIZE);
                            Raylib.DrawRectangle(wallPos.x, wallPos.y, wallPos.x + CELL_SIZE, wallPos.y + CELL_SIZE, Color.GOLD);
                            break;
                        default:
                            break;
                    }
                }
            }
        }


    }
}
