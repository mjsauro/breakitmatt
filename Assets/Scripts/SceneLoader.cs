﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


	public void LoadNextScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	public void LoadStartScene()
	{
		FindObjectOfType<GameSession>().ResetGameSession();
		SceneManager.LoadScene(0);

	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
