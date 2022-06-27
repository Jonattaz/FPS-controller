using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject intergirText;
    [SerializeField] protected Item item;
   
    public virtual void Awake(){
        // Número da layer que possui como nome Interactble 
        gameObject.layer = 6;
    }

   public abstract void OnInteract();
   public abstract void OnFocus();
   public abstract void OnLoseFocus();
}
