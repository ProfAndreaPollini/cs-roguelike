using System.Runtime.CompilerServices;
using System.Numerics;
using System;
using Raylib_cs;
using static Raylib_cs.KeyboardKey;
using Rendering;

const int Width = 800;
const int Height = 400;

const int CELL_SIZE = 20;
const int X_CELLS = Width / CELL_SIZE;
const int Y_CELLS = Height / CELL_SIZE;

Console.WriteLine("Hello World!");
Raylib.InitWindow(Width, Height, "Hello World");




Map map = new(X_CELLS, Y_CELLS);



Hero hero = new();
Random rng = new();
hero.Position.X = rng.Next() % X_CELLS;
hero.Position.Y = rng.Next() % Y_CELLS;

OrtoCamera camera = new();
camera.Center = hero.Position;
camera.Viewport = (X_CELLS / 2, Y_CELLS / 2);
Renderer renderer = new(camera);


renderer.Add(new HeroRenderModel(hero));

(int, int) CellToScreen(float x, float y)
{
    return (
        (int)(x * CELL_SIZE + 0.5 * CELL_SIZE),
        (int)(y * CELL_SIZE + 0.5 * CELL_SIZE)
    );
}


bool CanMoveToCell(Tile c) => c.Kind != TileKind.WALL;
bool IsPositionInsideMap(Vector2 position, int minx, int maxx, int miny, int maxy) => position.X >= minx && position.X < maxx && position.Y >= miny && position.Y < maxy;

Image img = Raylib.LoadImage("res/md-curses.png");
Texture2D tx = Raylib.LoadTextureFromImage(img);

while (!Raylib.WindowShouldClose())
{

    renderer.Begin();


    Vector2 dx = new();

    if (Raylib.IsKeyPressed(KEY_W))
    {
        dx += new Vector2(0, -1);
    }
    if (Raylib.IsKeyPressed(KEY_S))
    {
        dx += new Vector2(0, 1);
    }
    if (Raylib.IsKeyPressed(KEY_D))
    {
        dx += new Vector2(1, 0);
    }
    if (Raylib.IsKeyPressed(KEY_A))
    {
        dx += new Vector2(-1, 0);
    }




    Vector2 desired_position = hero.Position + dx;
    if (IsPositionInsideMap(desired_position, 0, X_CELLS, 0, Y_CELLS))
    {
        //int mapIdx = PositionToMapIdx(desired_position);
        Tile desiredCell = map.CellAt(desired_position);
        if (CanMoveToCell(desiredCell))
        {
            hero.Position = desired_position;
            camera.Center = hero.Position;
        }
    }

    // for (int i = 0; i < Width / CELL_SIZE; i++)
    // {
    //     Raylib.DrawLine(i * CELL_SIZE, 0, i * CELL_SIZE, Raylib.GetScreenHeight(), Color.BROWN);
    // }
    // for (int j = 0; j < Height / CELL_SIZE; j++)
    // {
    //     Raylib.DrawLine(0, j * CELL_SIZE, Raylib.GetScreenWidth(), j * CELL_SIZE, Color.BROWN);
    // }


    (int x, int y) screenPos = CellToScreen(hero.Position.X, hero.Position.Y);
    Raylib.DrawCircle(screenPos.x, screenPos.y, 10, Color.RED);
    Raylib.DrawTexture(tx, 200, 200, Color.RED);

    renderer.Render();
    renderer.End();
}

Raylib.CloseWindow();


