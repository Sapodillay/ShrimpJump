using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float JumpBoost = 5.0f;
    [SerializeField] private float Gravity = 30f;
    Vector3 m_Position;

    //X resolution
    float min_x_bound = -1.5f;
    float max_x_bound = 1.6f;


    float velocityY;


    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        HandleMovement();


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected AAAAAAAAAAAAAA");
        velocityY = JumpBoost;

    }







    private void HandleMovement()
    {
        Vector3 mousePos = Input.mousePosition;
        //Clamp to side of screen
        //TODO: CLAMP TO SIDES OF SCREEN
        m_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        m_Position.x = Mathf.Clamp(m_Position.x, min_x_bound,max_x_bound);


        //Remove depth.
        m_Position.z = 0;
        transform.position = new Vector2(m_Position.x, transform.position.y + velocityY * Time.deltaTime);

        //Gravity 30= gravity
        velocityY -= Gravity * Time.deltaTime;


    }


}
