using System.Diagnostics;

public enum TileKind
{
    TERRAIN,
    WALL
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
internal class Tile
{
    public Tile()
    {
        Kind = TileKind.TERRAIN;
    }


    public TileKind Kind;




    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}