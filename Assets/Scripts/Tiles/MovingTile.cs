using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : Tile
{


    float min_x_bound = -1.5f;
    float max_x_bound = 1.6f;
    int tileSpeed;

    float duration;
    float freq = 1f;

    private float elapsedTime;


    private void Awake()
    {
        elapsedTime = Random.Range(0f, 1f);
        freq = Random.Range(0.1f, 2f);
    }

    private void Update()
    {

        elapsedTime += Time.deltaTime;



        float t = Mathf.Sin(elapsedTime * freq);
        float remappedSine = (t + 1f) * 0.5f;
        transform.position = new Vector2(Mathf.Lerp(min_x_bound, max_x_bound, remappedSine), transform.position.y);
    }




}
