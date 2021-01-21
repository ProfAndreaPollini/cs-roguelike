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

        private (int, int) CellToScreen(float x, float y)
        {
            return (
                (int)(x * CELL_SIZE + 0.5 * CELL_SIZE),
                (int)(y * CELL_SIZE + 0.5 * CELL_SIZE)
            );
        }
        public override void Render(OrtoCamera camera)
        {
            (int x, int y) screenPos = CellToScreen(Hero.Position.X, Hero.Position.Y);
            Raylib.DrawCircle(screenPos.x, screenPos.y, 10, Color.RED);
            //Raylib.DrawTexture(tx, 200, 200, Color.RED);
        }
    }
}