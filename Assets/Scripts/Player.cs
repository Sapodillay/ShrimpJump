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

    [SerializeField] FloatSO score;


    private void Update()
    {
        highestY = Mathf.Max(highestY, transform.position.y);
        score._float = getScore();

        
        if (transform.position.y < highestY - deathY)
        {
            //Kill player.
            Debug.Log("player died");
            
            GameManager.instance.m_onPlayerDeath.Invoke();
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
