using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenu;

	public GameObject howToPlay;

	public void StartGame()
	{
		Time.timeScale = 1;
		PauseScript.pause = false;
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

	public void ExitTheGame()
	{
		Application.Quit();
	}

	public void HowToPlay()
	{
		howToPlay.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void Back()
	{
		mainMenu.SetActive(true);
		howToPlay.SetActive(false);
	}
}