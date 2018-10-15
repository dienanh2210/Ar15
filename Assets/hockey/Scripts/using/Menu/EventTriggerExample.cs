using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EventTriggerExample : EventTrigger
{
    private Animator anim;
    
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
    public override void OnPointerEnter(PointerEventData data)
    {
       
        anim.SetBool("isButton", true);

    }
    public override void OnPointerExit(PointerEventData data)
    {
     
        anim.SetBool("isButton", false);

    }
}
