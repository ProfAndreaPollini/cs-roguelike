using System;
using System.Collections.Generic;
using Raylib_cs;


// (int, int) CellToScreen(float x, float y)
// {
//     return (
//         (int)(x * CELL_SIZE + 0.5 * CELL_SIZE),
//         (int)(y * CELL_SIZE + 0.5 * CELL_SIZE)
//     );
// }

namespace Rendering
{
    internal class Renderer
    {
        public List<IRenderModel> Layers;
        public Renderer()
        {
            Layers = new();
        }

        public void Add(IRenderModel model)
        {
            Layers.Add(model);
        }



        internal void Begin()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
            Raylib.DrawCircle(100, 100, 10, Color.DARKGREEN);
        }

        internal void End()
        {
            Raylib.EndDrawing();
        }

        internal void Render(Map map)
        {

        }

        internal void Render(Hero hero)
        {
            // (int x, int y) screenPos = CellToScreen(hero.Position.X, hero.Position.Y);
            // Raylib.DrawCircle(screenPos.x, screenPos.y, 10, Color.RED);
            // Raylib.DrawTexture(tx, 200, 200, Color.RED);
        }

        internal void Render()
        {
            foreach (var model in this.Layers)
            {
                model.Render();
            }
        }
    }

}