﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Door goldDoor;
    [SerializeField] private Image goldKey;

    private GameObject[] hearts; 
	private MyCharManager player;

	private float heartCount = 3f;

	// Use this for initialization
	void Start () {
		hearts = GameObject.FindGameObjectsWithTag("Heart");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<MyCharManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.Health == 0f && heartCount > 0f)
		{
			heartCount = 0f;
			GameObject image1 = GameObject.Find("1heart");
			GameObject image2 = GameObject.Find("2heart");
			GameObject image3 = GameObject.Find("3heart");
			image1.SetActive(false);
			image2.SetActive(false);
			image3.SetActive(false);
		}
		else if (player.Health == 1f && heartCount > 1f)
		{
			heartCount = 2f;
			GameObject image1 = GameObject.Find("2heart");
			GameObject image2 = GameObject.Find("3heart");
			image1.SetActive(false);
			image2.SetActive(false);
		}
		else if (player.Health == 2f && heartCount > 2)
		{
			heartCount = 2f;
			GameObject image = GameObject.Find("3heart");
			image.SetActive(false); 
		}
		
		if (player.Health == 3f && heartCount < 3)
		{
			heartCount = 3;
			RefreshHearts();
		}

        // Displaying gold key
        if (goldDoor.doorKey == false)
        {
            goldKey.enabled = false;
        }
        else
        {
            goldKey.enabled = true;
        }
    }

	void RefreshHearts() 
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if (!hearts[i].activeSelf)
			{
				hearts[i].SetActive(true);
			}		
		}
	}
}