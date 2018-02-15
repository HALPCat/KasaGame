﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, ITriggerObject<IActionObject> {
    [SerializeField]
    public GameObject[] actionObjects;
    //public IActionObject[] actionObjects;
    //public List<IActionObject> listaaa = new List<IActionObject>();
    private bool inTrigger;

   /* void Wake()
    {
        for(int i = 0; i < inspectorGameObjects.Length; i++)
        {
            actionObjects[i] = inspectorGameObjects[i].GetComponent<IActionObject>();
        }

        //actionObject = inspectorObject.GetComponent<IActionObject>();//
        if (actionObjects == null) inspectorGameObjects = null;
    }*/

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    private void Update()
    {
        if (inTrigger)
        {
            if(Input.GetButtonDown("action"))
            {
                for(int i = 0; i < actionObjects.Length; i++)
                {
                    Trigger(actionObjects[i].GetComponent<IActionObject>());
                    Debug.Log("numero: " + i);
                }
            }
        }
    }

    public void Trigger(IActionObject actionObject)
    {
        actionObject.Action();
    }

    private void OnGUI()
    {
        if (inTrigger)
        {
                GUI.Box(new Rect(450, 400, 200, 25), "Press E to interact");
        }
    }
}
