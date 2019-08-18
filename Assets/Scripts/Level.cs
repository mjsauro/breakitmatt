using UnityEngine;

public class Level : MonoBehaviour
{
	//parameters
	[SerializeField] private int breakableBlocks; //Serialized for debugging purposes

	//cached reference
	private SceneLoader _sceneloader;

	public void CountBreakableBlocks()
	{
		breakableBlocks++;
		_sceneloader = FindObjectOfType<SceneLoader>();
	}

	public void BlockDestroyed()
	{
		breakableBlocks--;
		if (breakableBlocks <= 0)
		{
			_sceneloader.LoadNextScene();
		}
	}

}
