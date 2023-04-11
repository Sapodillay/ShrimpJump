using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI m_scoreDisplay;

    [SerializeField] GameObject deathUI;
    [SerializeField] TMPro.TextMeshProUGUI m_deathScore;
    [SerializeField] TMPro.TextMeshProUGUI m_deathHighScore;

    [SerializeField] FloatSO m_score;
    [SerializeField] FloatSO m_highScore;


    public static UIHandler instance;

    private void Awake()
    {
        instance = this;
        GameManager.instance.m_onPlayerDeath.AddListener(OnDeath);

    }


    private void FixedUpdate()
    {
        m_scoreDisplay.text = "Score: " + m_score._float;
    }

    public void OnDeath()
    {
        deathUI.SetActive(true);
        m_deathScore.text = "Your score is: " + m_score._float;
        m_deathHighScore.text = "Your high score is: " + m_highScore._float;
    }

    public void OnReset()
    {
        deathUI.SetActive(false);
        GameManager.instance.m_onRetry.Invoke();
    }



}
