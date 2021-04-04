using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
	[SerializeField]
	public static bool pause = false;

	public GameObject pauseMenu;
	public GameObject HowToPlayWindow;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			PauseGame();
		}
	}

	public void PauseGame() {
		if (!pause) {
			Time.timeScale = 0;
			pause = true;
			pauseMenu.SetActive(true);
		} else {
			Time.timeScale = 1;
			pause = false;
			pauseMenu.SetActive(false);
			HowToPlayWindow.SetActive(false);
		}
	}

	public void HowToPlay()
	{
		HowToPlayWindow.SetActive(true);
		pauseMenu.SetActive(false);
	}

	public void Back() {
		HowToPlayWindow.SetActive(false);
		pauseMenu.SetActive(true);
	}

	public void MainMenu() {
		PauseGame();
		SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
	}

	public void StartGame()
	{
		Time.timeScale = 1;
		pause = false;
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}
}
