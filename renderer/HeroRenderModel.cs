namespace Rendering
{
    internal class HeroRenderModel : RenderModel
    {
        public HeroRenderModel(Hero hero)
        {
            Hero = hero;
        }

        public Hero Hero { get; }

        public override void Render()
        {
            base.Render();
        }
    }
}