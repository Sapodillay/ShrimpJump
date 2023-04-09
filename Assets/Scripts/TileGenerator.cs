using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    float min_x_bound = -1.5f;
    float max_x_bound = 1.6f;

    float currentHeight = 0.0f;


    //Implement a tile manager
    [SerializeField] Tile tilePrefab;
    [SerializeField] BrokenTile brokenTilePrefab;


    [SerializeField] Player player;


    Queue<Tile> tiles = new Queue<Tile>();
    int tileCount = 15;




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
        Tile tile;

        if (tiles.Count > tileCount)
        {
            Debug.Log("Moving tile");
            Tile tileToDelete = tiles.Dequeue();
            //Add object pooling later.
            tile = tileToDelete;
        }
        else
        {
            tile = GetNewTile();
        }



        //Get random position between min_x and max_x.
        float tile_x = Random.Range(min_x_bound, max_x_bound);
        float tile_y = currentHeight;

        //extend current height, make this random in future.
        currentHeight += 1;

        
        tile.transform.position = new Vector2(tile_x, tile_y);
        tiles.Enqueue(tile);

    }



    private Tile GetNewTile()
    {




        return null;
    }




}
