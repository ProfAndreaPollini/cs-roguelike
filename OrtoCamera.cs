using System;
using System.Numerics;
internal class OrtoCamera
{
    public Vector2 Center;
    public (int W, int H) Viewport;
    public OrtoCamera(int top, int left, int W, int H)
    {
        Top = top;
        Left = left;
        this.W = W;
        this.H = H;
        this.Zoom = 1;
    }

    public int Top { get; private set; }
    public int Left { get; private set; }
    public int W { get; }
    public int H { get; }
    public float Zoom { get; set; }

    internal void Move(int dx, int dy)
    {
        Left += dx;
        Top += dy;
    }
}