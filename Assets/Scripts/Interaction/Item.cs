using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Item : ScriptableObject
{
    [Header ("Item configuration")]
    // Controla se o objeto é pegavél ou não
     public bool grabbable;
    // Audio que toca ao interagir com o item
     public AudioClip audioClip;
    // Texto que aparece ao interagir com o item
    public string text;
}
