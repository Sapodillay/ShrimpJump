using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Float Scriptable object")]
public class FloatSO : ScriptableObject
{
    [SerializeField] public float _float;
}
