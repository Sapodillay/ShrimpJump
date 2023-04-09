using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{




    public virtual void OnJump()
    {
        Debug.Log("On tile interacted");

    }
    
    public virtual void Recycle()
    {

    }


}
