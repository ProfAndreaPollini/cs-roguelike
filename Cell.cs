using System.Diagnostics;

public enum CellKind
{
    TERRAIN,
    WALL
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
internal class Cell
{
    public Cell()
    {
        Kind = CellKind.TERRAIN;
    }


    public CellKind Kind;




    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}