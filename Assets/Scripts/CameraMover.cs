using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMover : MonoBehaviour
{

    [SerializeField] Player player;

    void Update()
    {
        Camera.main.transform.position = new Vector3(0,  player.GetHighestY(), -10);
    }
}
