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


        public Renderer(OrtoCamera camera)
        {
            Camera = camera;
            Layers = new();
        }

        public OrtoCamera Camera { get; }

        public void Add(IRenderModel model)
        {
            Layers.Add(model);
        }



        internal void Begin()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);




            Raylib.DrawCircle(100, 100, 10, Color.DARKGREEN);

        }

        internal void End()
        {
            Raylib.DrawText(String.Format("Camera : {0} {1} {2} {3}", Camera.Center.X - 0.5 * Camera.Viewport.W,
                         Camera.Center.X + 0.5 * Camera.Viewport.W,
                        Camera.Center.Y - 0.5 * Camera.Viewport.H,
                         Camera.Center.Y + 0.5 * Camera.Viewport.H
                        ), 12, 12, 20, Color.BLACK);
            Raylib.EndDrawing();
        }

        internal void Render(Map map)
        {

        }

        internal void Render(Hero hero)
        {

        }

        internal void Render()
        {
            foreach (var model in this.Layers)
            {
                model.Render(Camera);
            }
        }
    }
}