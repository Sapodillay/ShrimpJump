using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Player : MonoBehaviour
{
    
    float highestY = 0f;


    //amount below highest Y that the player dies when hitting.
    [SerializeField] float deathY = 3f;

    private void OnDrawGizmos()
    {
        //Debug draw to see death level
        //Gizmos.DrawWireSphere(new Vector2(transform.position.x, highestY - deathY), 0.5f);
    }




    private void Update()
    {
        highestY = Mathf.Max(highestY, transform.position.y);
        
        if (transform.position.y < highestY - deathY)
        {
            //Kill player.
            Debug.Log("player died");
            UIHandler.instance.OnDeath();

        }

    }

    public float GetHighestY()
    {
        return highestY;
    }

    float scoreMultiplier = 10f;

    public int getScore()
    {
        return (int)(highestY * scoreMultiplier);
    }

    public int getDifficulty()
    {
        return (int)(highestY / 10);
    }
}
