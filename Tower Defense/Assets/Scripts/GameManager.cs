using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public static bool GameIsOver;
	public GameObject[] towerbutton;
	public GameObject gameOverUI;
	public GameObject completeLevelUI,tutorialui;


	public GameObject[] daylight, nightlight,mode;
	

    private void Awake()
    {

		instance = this;

		if (MainMenu.lightsetting == 0)
		{
			for (int i = 0; i < daylight.Length; i++)
			{
				daylight[i].SetActive(true);

			}
			for (int i = 0; i < nightlight.Length; i++)
			{
				nightlight[i].SetActive(false);

			}

		}
		else
		{


			for (int i = 0; i < daylight.Length; i++)
			{
				daylight[i].SetActive(false);

			}
			for (int i = 0; i < nightlight.Length; i++)
			{
				nightlight[i].SetActive(true);

			}
		}


		if (MainMenu.unlock1 == 1)
		{
			towerbutton[0].SetActive(true);
		
		
		
		}

		if (MainMenu.unlock2 == 1)
		{
			towerbutton[1].SetActive(true);



		}

		
		if (MainMenu.tutorial == 0)
		{

			tutorialui.SetActive(true);


		}
		else
		{


			for (int i = 0; i < mode.Length; i++)
			{
				if (i == MainMenu.levelmode)
				{

					mode[i].SetActive(true);

				}
				else
				{
					mode[i].SetActive(false);


				}


			}


		}
	}

    void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		GameIsOver = true;
		MainMenu.coin += PlayerStats.Money;
		PlayerPrefs.SetInt("coin",MainMenu.coin);
		PlayerPrefs.Save();
		gameOverUI.SetActive(true);
	}

	public void WinLevel()
	{
		if (!GameIsOver)
		{
			if (SceneManager.GetActiveScene().name == "Level02")
			{

				PlayerPrefs.SetInt("levelReached", 3);

			}
			if (PlayerPrefs.GetInt("levelReached", 0) < 3)
			{

				PlayerPrefs.SetInt("levelReached", 2);

			}
			GameIsOver = true;
			MainMenu.coin += PlayerStats.Money;
			PlayerPrefs.SetInt("coin", MainMenu.coin);
			PlayerPrefs.Save();
			completeLevelUI.SetActive(true);
		}
	}

}
