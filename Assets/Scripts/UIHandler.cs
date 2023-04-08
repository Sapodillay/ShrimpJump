using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] TMPro.TextMeshProUGUI m_scoreDisplay;

    [SerializeField] GameObject deathUI;
    [SerializeField] TMPro.TextMeshProUGUI m_deathScore;


    public static UIHandler instance;

    private void Awake()
    {
        instance = this;
    }


    private void FixedUpdate()
    {
        m_scoreDisplay.text = "Score: " + player.getScore();
    }

    public void OnDeath()
    {
        deathUI.SetActive(true);
        m_deathScore.text = "Your score is: " + player.getScore();
    }

    public void OnReset()
    {
        deathUI.SetActive(false);       
    }



}
