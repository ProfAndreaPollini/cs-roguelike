using System;
using System.Numerics;
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
            // for (int i = 0; i < camera.Viewport.H; i++)
            // {
            //     for (int j = 0; j < camera.Viewport.W; j++)
            //     {
            //         Vector2 dx = new((float)j, (float)i);
            //         Vector2 cellPos = dx * Map.CELL_SIZE - camera.Center;
            //         if (cellPos.X < 0 || cellPos.Y < 0) continue;
            //         Vector2 cell = cellPos / Map.CELL_SIZE;

            //         Console.WriteLine($"({cell.X}, {cell.Y}) <= ({cellPos.X}, {cellPos.Y})");
            //         Tile c = Map.CellAt(cell);

            //         Raylib.DrawText($"({cellPos.X},{cellPos.Y})", (int)cellPos.X, (int)cellPos.Y, 10, Color.BLACK);
            //         switch (c.Kind)
            //         {
            //             case TileKind.TERRAIN:
            //                 //Console.WriteLine(i + " " + j);
            //                 cellPos.X -= 0.5f * Map.CELL_SIZE;
            //                 cellPos.Y -= 0.5f * Map.CELL_SIZE;

            //                 Raylib.DrawRectangle(
            //                     (int)cellPos.X,
            //                     (int)cellPos.Y,
            //                     (int)cellPos.X + Map.CELL_SIZE,
            //                     (int)cellPos.Y + Map.CELL_SIZE,
            //                     Color.LIME);
            //                 break;
            //             case TileKind.WALL:
            //                 cellPos.X -= 0.5f * Map.CELL_SIZE;
            //                 cellPos.Y -= 0.5f * Map.CELL_SIZE;

            //                 Raylib.DrawRectangle(
            //                     (int)cellPos.X,
            //                     (int)cellPos.Y,
            //                     (int)cellPos.X + Map.CELL_SIZE,
            //                     (int)cellPos.Y + Map.CELL_SIZE,
            //                     Color.LIME);
            //                 //Console.WriteLine(i + " " + j);
            //                 // (int x, int y) wallPos = CellToScreen(cell.X, cell.Y);
            //                 // wallPos.x -= (int)(0.5 * Map.CELL_SIZE);
            //                 // wallPos.y -= (int)(0.5 * Map.CELL_SIZE);
            //                 // Raylib.DrawRectangle(wallPos.x, wallPos.y, wallPos.x + Map.CELL_SIZE, wallPos.y + Map.CELL_SIZE, Color.GOLD);
            //                 break;
            //             default:
            //                 break;
            //         }
            //     }
            // }
        }


    }
}
