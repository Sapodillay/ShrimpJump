using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BrokenTile : Tile
{
    public int jumpTillBroken = 1;

    private int m_jumpTillBroken;

    BoxCollider2D m_collider;
    SpriteRenderer m_spriteRenderer;
    [SerializeField] Sprite m_brokenSprite;
    Sprite m_defaultSprite;

    private void Awake()
    {
        m_collider = GetComponent<BoxCollider2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        //cache default sprite
        m_defaultSprite = m_spriteRenderer.sprite;
        m_jumpTillBroken = jumpTillBroken;
    }


    public override void OnJump()
    {
        m_jumpTillBroken -= 1;
        if (m_jumpTillBroken == 0)
        {
            //Break tile.
            m_collider.enabled = false;
            m_spriteRenderer.sprite = m_brokenSprite;
        }
    }

    public override void Recycle()
    {
        m_jumpTillBroken = jumpTillBroken;
        m_spriteRenderer.sprite = m_defaultSprite;
        m_collider.enabled = true;

    }


}
