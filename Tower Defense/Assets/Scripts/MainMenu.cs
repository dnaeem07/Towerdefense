using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}



	public GameObject[] shophighlight;
	public GameObject[] shoptext;


	public void selectshopitem(int count)
	{
	
	
	
	for(int i=0;i<shophighlight.Length;i++)
	{
	
	if(i==count)
	{
	shophighlight[i].SetActive(true);
	
	shoptext[i].SetActive(true);
	}
	else
	{
	shophighlight[i].SetActive(false);
	
	shoptext[i].SetActive(false);
	
	
	
	}



	}
	
	
	
	}


	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

}
