using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{


    public string mainLevel = "SampleScene";

    [SerializeField] TMPro.TextMeshProUGUI m_HighScoreText;
    [SerializeField] FloatSO highScoreFloat;


    private void OnEnable()
    {
        //Update high score text
        m_HighScoreText.text = "High score: " + highScoreFloat._float;


    }


    public void PlayGame()
    {
        

        Debug.Log("Starting game...");
        SceneManager.LoadScene(mainLevel);

    }



}
