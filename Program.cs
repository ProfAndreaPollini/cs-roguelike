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




Map map = new(1000, 1000);



Hero hero = new();
Random rng = new();
hero.Position.X = rng.Next() % X_CELLS;
hero.Position.Y = rng.Next() % Y_CELLS;

OrtoCamera camera = new(10, 10, 20, 5);
camera.Center = new(hero.Position.X * CELL_SIZE, hero.Position.Y * CELL_SIZE);
camera.Viewport = (CELL_SIZE * X_CELLS / 2, CELL_SIZE * Y_CELLS / 2);
Renderer renderer = new(camera);


// renderer.Add(new MapRenderModel(map));
// renderer.Add(new HeroRenderModel(hero, CELL_SIZE));


// (int, int) CellToScreen(float x, float y)
// {
//     return (
//         (int)(x * CELL_SIZE + 0.5 * CELL_SIZE),
//         (int)(y * CELL_SIZE + 0.5 * CELL_SIZE)
//     );
// }


// bool CanMoveToCell(Tile c) => c.Kind != TileKind.WALL;
// bool IsPositionInsideMap(Vector2 position, int minx, int maxx, int miny, int maxy) => position.X >= minx && position.X < maxx && position.Y >= miny && position.Y < maxy;

Image img = Raylib.LoadImage("res/md-curses.png");
Texture2D tx = Raylib.LoadTextureFromImage(img);



while (!Raylib.WindowShouldClose())
{

    renderer.Begin();


    Vector2 dx = new();

    if (Raylib.IsKeyPressed(KEY_W))
    {
        // dx += new Vector2(0, -1);
        camera.Move(0, -1);
    }
    if (Raylib.IsKeyPressed(KEY_S))
    {
        // dx += new Vector2(0, 1);
        camera.Move(0, 1);
    }
    if (Raylib.IsKeyPressed(KEY_D))
    {
        //dx += new Vector2(1, 0);
        camera.Move(1, 0);
    }
    if (Raylib.IsKeyPressed(KEY_A))
    {
        //dx += new Vector2(-1, 0);
        camera.Move(-1, 0);
    }
    if (Raylib.IsKeyPressed(KEY_PAGE_UP))
    {
        camera.Zoom *= 1.05f;
    }
    if (Raylib.IsKeyPressed(KEY_PAGE_DOWN))
    {
        camera.Zoom *= 0.95f;
    }

    for (int y = camera.Top; y < camera.Top + camera.H; y++)
    {
        for (int x = camera.Left; x < camera.Left + camera.W; x++)
        {
            Tile tile = map.GetTile(y, x);
            //Console.WriteLine($"({x * 16},{y * 16})");
            int tileSize = (int)(25 * camera.Zoom);
            switch (tile.Kind)
            {
                case TileKind.WALL:
                    Raylib.DrawRectangle((x - camera.Left) * tileSize, (y - camera.Top) * tileSize, tileSize, tileSize, Color.GRAY);
                    break;
                case TileKind.TERRAIN:
                    Raylib.DrawRectangle((x - camera.Left) * tileSize, (y - camera.Top) * tileSize, tileSize, tileSize, Color.LIME);
                    break;
            }
            Raylib.DrawText($"{x},{y}", (x - camera.Left) * tileSize, (y - camera.Top) * tileSize, 6, Color.BLACK);
        }
    }



    // Vector2 desired_position = hero.Position + dx;
    // if (IsPositionInsideMap(desired_position, 0, X_CELLS, 0, Y_CELLS))
    // {
    //     //int mapIdx = PositionToMapIdx(desired_position);
    //     Tile desiredCell = map.CellAt(desired_position);
    //     if (CanMoveToCell(desiredCell))
    //     {
    //         hero.Position = desired_position;
    //         //camera.Center = hero.Position;
    //     }
    // }

    // for (int i = 0; i < Width / CELL_SIZE; i++)
    // {
    //     Raylib.DrawLine(i * CELL_SIZE, 0, i * CELL_SIZE, Raylib.GetScreenHeight(), Color.BROWN);
    // }
    // for (int j = 0; j < Height / CELL_SIZE; j++)
    // {
    //     Raylib.DrawLine(0, j * CELL_SIZE, Raylib.GetScreenWidth(), j * CELL_SIZE, Color.BROWN);
    // }



    renderer.Render();


    renderer.End();
}

Raylib.CloseWindow();


