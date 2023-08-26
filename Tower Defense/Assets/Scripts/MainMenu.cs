using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public Text cointext;
	public string levelToLoad = "MainLevel";
	public GameObject[] coinholder1, coinholder2,lighthighlight,tutorialdata;
	public SceneFader sceneFader;
	public static int unlock1,unlock2;
	public static int coin,lightsetting,levelmode,tutorial,shoptutorial;
	public GameObject notenoughcoinpopup,shoptutorialpanel;
	public Animator anim;


	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}


   
    public GameObject[] shophighlight;
	public GameObject[] shoptext;
	private void Awake()
	{

		shoptutorial = PlayerPrefs.GetInt("shoptutorial", 0);
		tutorial = PlayerPrefs.GetInt("tutorial", 0);
		unlock1 = PlayerPrefs.GetInt("unlock1",0);
		unlock2 = PlayerPrefs.GetInt("unlock2", 0);
		coin = PlayerPrefs.GetInt("coin",100);
		lightsetting = PlayerPrefs.GetInt("light", 0);
		Debug.Log("shopitem value: "+unlock1+unlock2);
		if (unlock1 == 1)
		{

			for (int i = 0; i < coinholder1.Length; i++)
			{

				if (i == 1)
				{
					coinholder1[i].GetComponent<Button>().interactable = false;
					coinholder1[i].GetComponentInChildren<Text>().text = "Owned";

				}
				else
				{
					coinholder1[i].SetActive(false);
				}
			}
		}

		if (unlock2 == 1)
		{

			for (int i = 0; i < coinholder1.Length; i++)
			{


				if (i == 1)
				{

					coinholder2[i].GetComponent<Button>().interactable = false;
					coinholder2[i].GetComponentInChildren<Text>().text = "Owned";

				}
				else
				{
					coinholder2[i].SetActive(false);
				}
			}
		}

	for(int i=0;i<lighthighlight.Length;i++)
        {

			if (i == lightsetting)
			{
				lighthighlight[i].SetActive(true);


			}
			else
			{
				lighthighlight[i].SetActive(false);
			}


		}

		if (shoptutorial == 0)
		{

			shoptutorialpanel.SetActive(true);
		}

		if (tutorial == 0)
		{
			Invoke("starttutorial", 1.5f);


		}
		else
		{
			anim.Play("menu");
		
		
		}


	}
	public void  starttutorial()
	{
		tutorialdata[0].SetActive(true);

		tutorialdata[1].SetActive(true);


	}


	public void shoptutroialdone()
	{

		PlayerPrefs.SetInt("shoptutorial",1);
		PlayerPrefs.Save();
	
	}
	public void levelselecio(int selection)
	{

		levelmode = selection;
	
	}


    private void Update()
    {
		cointext.text = ""+coin;
    }

	public void lightselect(int select)
	{
		lightsetting = select;
		PlayerPrefs.SetInt("light", lightsetting);
		PlayerPrefs.Save();

		for (int i = 0; i < lighthighlight.Length; i++)
		{

			if (i == lightsetting)
			{
				lighthighlight[i].SetActive(true);


			}
			else
			{
				lighthighlight[i].SetActive(false);
			}


		}


	}
    public void buyitem1()
	{ 
		
		if (coin > 200)
		{
			coin -= 200;
			unlock1 = 1;
			PlayerPrefs.SetInt("coin",coin);
			PlayerPrefs.SetInt("unlock1", 1);

			for (int i = 0; i < coinholder1.Length; i++)
			{


				if (i == 1)
				{

					coinholder1[i].GetComponent<Button>().interactable = false;
					coinholder1[i].GetComponentInChildren<Text>().text = "Owned";

				}
				else
				{
					coinholder1[i].SetActive(false);
				}
			}

		}else
		{

			notenoughcoinpopup.SetActive(true);


			}
			
	
	}
	public void buyitem2()
	{

		if (coin > 400)
		{

			coin -= 400;
			unlock2 = 1;
			PlayerPrefs.SetInt("coin", coin);
			PlayerPrefs.SetInt("unlock2", 1);

			for (int i = 0; i < coinholder1.Length; i++)
			{


				if (i == 1)
				{

					coinholder2[i].GetComponent<Button>().interactable = false;
					coinholder2[i].GetComponentInChildren<Text>().text = "Owned";

				}
				else
				{
					coinholder2[i].SetActive(false);
				}
			}
		}
		else
		{

			notenoughcoinpopup.SetActive(true);


		}

	}
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
