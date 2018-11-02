using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public static SceneController instance;

	public string loadingSceneName = "Loading";

	public float secondsBeforeLoad;

	private string sceneToLoad = "";
	

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
			return;
		}
		DontDestroyOnLoad(this);
	}

	/// <summary>
	/// Basic LoadScene
	/// </summary>
	/// <param name="name">Name of the scene</param>
	public void LoadScene(string name)
	{
		if (SceneManager.GetSceneByName(name) != null)
		{
			SceneManager.LoadScene(name);
		}
		else
		{
			Debug.LogError("Scene " + name + " doesn't exist!");
		}
	}
	/// <summary>
	/// Loads a loading screen before loading the next scene.
	/// </summary>
	/// <param name="name">Name of the scene</param>
	public void LoadSceneWithLoadingScreen(string name)
	{
		if (SceneManager.GetSceneByName(name) != null)
		{
			//set the name of the scene to load after the loading screen
			sceneToLoad = name;
			SceneManager.LoadScene(loadingSceneName);
			//because invoke only takes a string for the method name, we cache the next scene's name
			Invoke("LoadActualScene", secondsBeforeLoad);
		}
		else
		{
			Debug.LogError("Scene " + name + " doesn't exist!");
		}
	}

	/// <summary>
	/// Loads the actual scene after the loading screen
	/// </summary>
	private void LoadActualScene()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void ReloadActiveScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
