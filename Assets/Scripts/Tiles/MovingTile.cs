using UnityEngine;

public class MovingTile : Tile
{


    float min_x_bound = -1.5f;
    float max_x_bound = 1.6f;

    [SerializeField] float maxTileSpeed = 2f;
    [SerializeField] float minTileSpeed = 0.1f;

    private float tileSpeed;
    private float elapsedTime;

    private void Awake()
    {
        //Seed time so not all tiles spawn at same location
        elapsedTime = Random.Range(0f, 1f);

        //Randomize tilespeed
        tileSpeed = Random.Range(minTileSpeed, maxTileSpeed);
    }

    private void Update()
    {

        elapsedTime += Time.deltaTime;

        float t = Mathf.Sin(elapsedTime * tileSpeed);
        float remappedSine = (t + 1f) * 0.5f;
        transform.position = new Vector2(Mathf.Lerp(min_x_bound, max_x_bound, remappedSine), transform.position.y);
    }

    public override void OnJump()
    {
        return;
    }
    public override void Recycle()
    {
        //
        this.Awake();
    }



}
