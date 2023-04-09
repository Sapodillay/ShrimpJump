using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BrokenTile : Tile
{

    public int jumpTillBroken = 1;

    BoxCollider2D m_collider;
    SpriteRenderer m_spriteRenderer;
    [SerializeField] Sprite m_brokenSprite;

    private void Awake()
    {
        m_collider = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public override void OnJump()
    {
        jumpTillBroken -= 1;
        if (jumpTillBroken == 0)
        {
            //Break tile.
            m_collider.enabled = false;
            m_spriteRenderer.sprite = m_brokenSprite;
        }
    }

    public override void Recycle()
    {
        

    }


}
