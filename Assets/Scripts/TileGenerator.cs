using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    float min_x_bound = -1.5f;
    float max_x_bound = 1.6f;

    float currentHeight = 0.0f;

    [SerializeField] GameObject tilePrefab;

    [SerializeField] Player player;


    Queue<GameObject> tiles = new Queue<GameObject>();
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
        GameObject tile;

        if (tiles.Count > tileCount)
        {
            Debug.Log("Moving tile");
            GameObject tileToDelete = tiles.Dequeue();
            //Add object pooling later.
            tile = tileToDelete;
        }
        else
        {
            tile = Instantiate(tilePrefab);
        }



        //Get random position between min_x and max_x.
        float tile_x = Random.Range(min_x_bound, max_x_bound);
        float tile_y = currentHeight;

        //extend current height, make this random in future.
        currentHeight += 1;

        
        tile.transform.position = new Vector2(tile_x, tile_y);
        tiles.Enqueue(tile);

    }





}
