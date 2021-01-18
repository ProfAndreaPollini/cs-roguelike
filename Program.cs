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


Renderer renderer = new();

Hero hero = new();
Random rng = new();
hero.Position.X = rng.Next() % X_CELLS;
hero.Position.Y = rng.Next() % Y_CELLS;


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
        }
    }

    for (int i = 0; i < Width / CELL_SIZE; i++)
    {
        Raylib.DrawLine(i * CELL_SIZE, 0, i * CELL_SIZE, Raylib.GetScreenHeight(), Color.BROWN);
    }
    for (int j = 0; j < Height / CELL_SIZE; j++)
    {
        Raylib.DrawLine(0, j * CELL_SIZE, Raylib.GetScreenWidth(), j * CELL_SIZE, Color.BROWN);
    }
    for (int i = 0; i < Y_CELLS; i++)
    {
        for (int j = 0; j < X_CELLS; j++)
        {
            Tile c = map.CellAt(new Vector2(j, i));
            switch (c.Kind)
            {
                case TileKind.TERRAIN:
                    //Console.WriteLine(i + " " + j);
                    (int x, int y) terrainPos = CellToScreen(j, i);
                    terrainPos.x -= (int)(0.5 * CELL_SIZE);
                    terrainPos.y -= (int)(0.5 * CELL_SIZE);
                    Raylib.DrawRectangle(terrainPos.x, terrainPos.y, terrainPos.x + CELL_SIZE, terrainPos.y + CELL_SIZE, Color.LIME);
                    break;
                case TileKind.WALL:
                    //Console.WriteLine(i + " " + j);
                    (int x, int y) wallPos = CellToScreen(j, i);
                    wallPos.x -= (int)(0.5 * CELL_SIZE);
                    wallPos.y -= (int)(0.5 * CELL_SIZE);
                    Raylib.DrawRectangle(wallPos.x, wallPos.y, wallPos.x + CELL_SIZE, wallPos.y + CELL_SIZE, Color.GOLD);
                    break;
                default:
                    break;
            }
        }
    }



    renderer.Render();
    renderer.End();
}

Raylib.CloseWindow();


