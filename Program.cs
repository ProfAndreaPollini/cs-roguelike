using System.Numerics;
using System;
using Raylib_cs;
using static Raylib_cs.KeyboardKey;

const int Width = 800;
const int Height = 400;

const int CELL_SIZE = 20;
const int X_CELLS = Width / CELL_SIZE;
const int Y_CELLS = Height / CELL_SIZE;

Console.WriteLine("Hello World!");
Raylib.InitWindow(Width, Height, "Hello World");

Cell[] map = new Cell[X_CELLS * Y_CELLS];

for (int i = 0; i < X_CELLS * Y_CELLS; i++)
{
    map[i] = new();
}

map[0].Kind = CellKind.WALL;
map[2].Kind = CellKind.WALL;
map[X_CELLS + 1].Kind = CellKind.WALL;
Hero hero = new();
Random rng = new();
hero.Position.X = rng.Next() % X_CELLS;
hero.Position.Y = rng.Next() % Y_CELLS;

(int, int) CellToScreen(float x, float y)
{
    return (
        (int)(x * CELL_SIZE + 0.5 * CELL_SIZE),
        (int)(y * CELL_SIZE + 0.5 * CELL_SIZE)
    );
}

int PositionToMapIdx(Vector2 pos)
{
    return (int)(pos.X + pos.Y * X_CELLS);
}

bool CanMoveToCell(Cell c) => c.Kind != CellKind.WALL;
bool IsPositionInsideMap(Vector2 position, int minx, int maxx, int miny, int maxy) => position.X >= minx && position.X < maxx && position.Y >= miny && position.Y < maxy;

Image img = Raylib.LoadImage("res/md-curses.png");
Texture2D tx = Raylib.LoadTextureFromImage(img);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);
    Raylib.DrawCircle(100, 100, 10, Color.DARKGREEN);

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
        int mapIdx = PositionToMapIdx(desired_position);
        if (CanMoveToCell(map[mapIdx]))
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
            Cell c = map[i * X_CELLS + j];
            switch (c.Kind)
            {
                case CellKind.TERRAIN:
                    //Console.WriteLine(i + " " + j);
                    (int x, int y) terrainPos = CellToScreen(j, i);
                    terrainPos.x -= (int)(0.5 * CELL_SIZE);
                    terrainPos.y -= (int)(0.5 * CELL_SIZE);
                    Raylib.DrawRectangle(terrainPos.x, terrainPos.y, terrainPos.x + CELL_SIZE, terrainPos.y + CELL_SIZE, Color.LIME);
                    break;
                case CellKind.WALL:
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

    (int x, int y) screenPos = CellToScreen(hero.Position.X, hero.Position.Y);
    Raylib.DrawCircle(screenPos.x, screenPos.y, 10, Color.RED);
    Raylib.DrawTexture(tx, 200, 200, Color.RED);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();


