﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	[SerializeField] private GameObject menuCanvasObj;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button quitButton;

	public static bool isPaused = false;
	// Use this for initialization
	void Awake () {
		resumeButton.onClick.AddListener(CloseGameMenu);
	}
	
	// Update is called once per frame
	void Update () {
		HandleMenu();
	}

	public void LaunchGameMenu()
	{
		menuCanvasObj.SetActive(true);
		isPaused = true;
		Time.timeScale = 0f;
		Cursor.visible = true;
	}

	public void CloseGameMenu()
	{
		menuCanvasObj.SetActive(false);
		isPaused = false;
		Time.timeScale = 1f;
		Cursor.visible = false;
	}

	private void HandleMenu()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!isPaused)
			{
				LaunchGameMenu();
			} 
			else
			{
				CloseGameMenu();
			}
		}
	}

	public void ReturnToMainMenu()
	{
		Time.timeScale = 1f;
		isPaused = false;
		MySceneManager manager = Object.FindObjectOfType<MySceneManager>();
		manager.LoadMainMenu();
	}
}
