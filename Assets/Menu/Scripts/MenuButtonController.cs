using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class MenuButtonController : MonoBehaviour
{
	public static MenuButtonController Instance;
	public GameObject MaineMenuObject;
	public GameObject PauseObject;
	public GameObject SettingsObject;
	public GameObject AudioObject;
	public GameObject GraphicsObject;
	public bool Pause, Settings = false;
	public bool SettingsTwo = false;
	public bool Menu;

	public GameObject CurntButton;

	private GameObject MaineMenuButton;
	private GameObject PauseButton;
	private GameObject SettingsButton;
	private GameObject AudioButton;
	private GameObject GraphicsButton;

	public string FunctionName;

	private void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("More than one MenuButtonController in scene");
		}
		else
		{
			Instance = this;
		}
	}
	private void Start()
	{
    
		MaineMenuButton = MaineMenuObject.transform.GetChild(0).gameObject;
		PauseButton = PauseObject.transform.GetChild(0).gameObject;
		SettingsButton = SettingsObject.transform.GetChild(0).gameObject;
		AudioButton = AudioObject.transform.GetChild(0).gameObject;
		GraphicsButton = GraphicsObject.transform.GetChild(0).gameObject;
		if (Menu)
		{
			EventSystem.current.SetSelectedGameObject(MaineMenuButton);

		}

	}
	// Update is called once per frame
	void Update()
	{



		if (EventSystem.current.currentSelectedGameObject == null)
		{
			EventSystem.current.SetSelectedGameObject(CurntButton);
		}

		if (Pause)
		{
			//GameManager.Instance.Pause = true;
		//	GameManager.Instance.StopMoveing = true;


		}
		else if (!Pause && !Menu)
		{
			//GameManager.Instance.Pause = false;
			//GameManager.Instance.StopMoveing = false;


		}


		if (Input.GetKeyDown(KeyCode.Escape))
		{


			back();


		}

	}


	public void Quit()
	{
		if (Menu == false)
		{

			SceneManager.LoadScene(0);

		}
		else
		{
			Application.Quit();

		}

	}


	public void Escape()
	{
		CurntButton = PauseButton;
		EventSystem.current.SetSelectedGameObject(CurntButton);
		MaineMenuObject.SetActive(false);
		Pause = true;
		PauseObject.SetActive(true);

	}

	public void Setting()
	{

		CurntButton = SettingsButton;
		EventSystem.current.SetSelectedGameObject(CurntButton);
		SettingsObject.SetActive(true);
		MaineMenuObject.SetActive(false);
		PauseObject.SetActive(false);
		Settings = true;

	}

	public void Audio()
	{
		CurntButton = AudioButton;
		EventSystem.current.SetSelectedGameObject(CurntButton);
		AudioObject.SetActive(true);
		SettingsObject.SetActive(false);
		SettingsTwo = true;

	}

	public void Graphics()
	{
		CurntButton = GraphicsButton;
		EventSystem.current.SetSelectedGameObject(CurntButton);
		GraphicsObject.SetActive(true);
		SettingsObject.SetActive(false);
		SettingsTwo = true;

	}


	public void back()
	{


		if (Settings && SettingsTwo && !Menu)
		{
			CurntButton = SettingsButton;
			EventSystem.current.SetSelectedGameObject(CurntButton);
			AudioObject.SetActive(false);
			GraphicsObject.SetActive(false);
			SettingsObject.SetActive(true);
			SettingsTwo = false;

		}
		else if (Settings && !SettingsTwo && !Menu)
		{
			CurntButton = PauseButton;
			EventSystem.current.SetSelectedGameObject(CurntButton);
			PauseObject.SetActive(true);
			SettingsObject.SetActive(false);
			Settings = false;

		}
		else if (!Settings && !SettingsTwo && Pause && !Menu)
		{
			//EventSystem.current.SetSelectedGameObject(null);
			Pause = false;
			PauseObject.SetActive(false);
			Settings = false;
			CurntButton = null;
			//	AbilitiesManager.Instance.StopMoveing = false;
			Time.timeScale = 1;

		}

		else if (!Settings && !SettingsTwo && !Pause && !Menu)
		{
			CurntButton = PauseButton;
			EventSystem.current.SetSelectedGameObject(CurntButton);
			Pause = true;
			PauseObject.SetActive(true);


		}/****************************************/
		else if (Settings && SettingsTwo && Menu)
		{

			CurntButton = SettingsButton;
			EventSystem.current.SetSelectedGameObject(CurntButton);
			AudioObject.SetActive(false);
			GraphicsObject.SetActive(false);
			SettingsObject.SetActive(true);
			SettingsTwo = false;

		}
		else if (Settings && !SettingsTwo && Menu)
		{
			CurntButton = MaineMenuButton;
			EventSystem.current.SetSelectedGameObject(CurntButton);
			MaineMenuObject.SetActive(true);
			SettingsObject.SetActive(false);
			Settings = false;

		}



	}
	public void NewGame()
	{

		SceneManager.LoadScene(1);

	}
	public void Practice()
	{

		SceneManager.LoadScene(3);

	}


}
