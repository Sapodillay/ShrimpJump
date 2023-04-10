using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    float min_x_bound = -1.5f;
    float max_x_bound = 1.6f;

    float currentHeight = 0.0f;


    //Implement a tile manager
    [SerializeField] Tile tilePrefab;
    [SerializeField] BrokenTile brokenTilePrefab;
    [SerializeField] MovingTile movingTilePrefab;


    [SerializeField] Player player;


    Queue<Tile> tiles = new Queue<Tile>();
    Queue<BrokenTile> brokenTiles = new Queue<BrokenTile>();
    Queue<MovingTile> movingTiles = new Queue<MovingTile>();

    [SerializeField] int tileCount = 15;




    private void FixedUpdate()
    {
        float highestY = player.GetHighestY();
       if (highestY + 5 > currentHeight)
        {
            GenerateNewTile();
        }
    }

    private void GenerateNewTile()
    {



        Tile tile = GetNewTile();

        //Get random position between min_x and max_x.
        float tile_x = Random.Range(min_x_bound, max_x_bound);
        float tile_y = currentHeight;

        //extend current height, make this random in future.
        currentHeight += 1;

        
        tile.transform.position = new Vector2(tile_x, tile_y);
    }


    /// <summary>
    /// Handles object pooling and tile management
    /// </summary>
    /// <returns></returns>
    private Tile GetNewTile()
    {
        List<TileTypes> types = new List<TileTypes>
        {
            TileTypes.None
        };
        if (player.getDifficulty() >= 2)
        {
            types.Add(TileTypes.Broken);
        }
        if (player.getDifficulty() >= 1)
        {
            Debug.Log("Adding moving...");
            types.Add(TileTypes.MovingTile);
        }
        return getRandomType(types);
    }




    enum TileTypes
    {
        None,
        Broken,
        MovingTile,
    }

    private Tile getRandomType(List<TileTypes> validTypes)
    {

        TileTypes type = validTypes[Random.Range(0, validTypes.Count)];
        Debug.Log(validTypes.Count);

        Tile tile;
        switch (type)
        {
            case TileTypes.None:
                if (tiles.Count > tileCount)
                {
                    tile = tiles.Dequeue();
                    tiles.Enqueue(tile);
                    return tile;
                }
                tile = Instantiate(tilePrefab);
                tiles.Enqueue((tile));
                return tile;
            case TileTypes.Broken:
                BrokenTile brokenTile;
                if (brokenTiles.Count > tileCount)
                {
                    brokenTile = brokenTiles.Dequeue();
                    brokenTile.Recycle();
                    brokenTiles.Enqueue(brokenTile);
                    return brokenTile;
                }
                brokenTile = Instantiate(brokenTilePrefab);
                brokenTiles.Enqueue((brokenTile));
                return brokenTile;
            case TileTypes.MovingTile:
                MovingTile movingTile;
                if (movingTiles.Count > tileCount)
                {
                    movingTile = movingTiles.Dequeue();
                    movingTile.Recycle();
                    movingTiles.Enqueue(movingTile);
                    return movingTile;
                }
                movingTile = Instantiate(movingTilePrefab);
                movingTiles.Enqueue((movingTile));
                return movingTile;
        }

        return null;
    }







}
