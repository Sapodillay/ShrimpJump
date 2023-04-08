using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{


    public string mainLevel = "SampleScene";

    public void PlayGame()
    {
        Debug.Log("Starting game...");
        SceneManager.LoadScene(mainLevel);

    }



}
