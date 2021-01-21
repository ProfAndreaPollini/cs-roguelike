using System.Numerics;
using Raylib_cs;

namespace Rendering
{
    internal class HeroRenderModel : RenderModel
    {
        public HeroRenderModel(Hero hero)
        {
            Hero = hero;
        }

        public HeroRenderModel(Hero hero, int cELL_SIZE) : this(hero)
        {
            CELL_SIZE = cELL_SIZE;
        }

        public Hero Hero { get; }
        public int CELL_SIZE { get; }

        public override void Render(OrtoCamera camera)
        {
            var cellSize = CELL_SIZE * camera.Zoom;
            var dx = new Vector2(0.5f * cellSize, 0.5f * cellSize);

            var screenPos = (Hero.Position - new Vector2(camera.Left, camera.Top)) * cellSize + dx;
            Raylib.DrawCircle((int)screenPos.X, (int)screenPos.Y, 0.5f * cellSize, Color.RED);
            //Raylib.DrawTexture(tx, 200, 200, Color.RED);
        }
    }
}