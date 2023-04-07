using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMover : MonoBehaviour
{

    [SerializeField] GameObject player;

    float highest_y = 0f;

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(0,  highest_y, -10);
        highest_y = Mathf.Max(highest_y, player.transform.position.y);
    }
}
