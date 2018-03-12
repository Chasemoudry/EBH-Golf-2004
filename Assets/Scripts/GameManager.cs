using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager gm;

	[Header("Prefabs")]
	public GameObject PlayerBall;

	[Header("Player Attributes")]
	public float playerScore;
	private Transform playerSpawnPoint;

	[Header("Player Camera")]
	public Vector3 cameraOffset;
	public float cameraRotationSpeed;

	[Header("Score Options")]
	public float cherryWorth;
	public float levelWorth;

	[Header("Menu Objects")]
	//private GameObject menuParent;
	public GameObject MainMenu;
	public GameObject LevelVictoryMenu;
	public GameObject GameVictoryMenu;
	public GameObject DeathMenu;
	private string currentScene;

	void Awake()
	{
		//DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		if (!gm)
		{
			gm = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			QuitGame();
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void LoadMenu(string currentMenu)
	{
		SceneManager.MoveGameObjectToScene(AudioManager.am.gameObject, SceneManager.GetSceneByName("MainMenu"));
		SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName("MainMenu"));
		StartCoroutine(UnloadCurrentScene());

		switch (currentMenu)
		{
			case "MainMenu":
				this.MainMenu.gameObject.SetActive(true);
				break;
			case "DeathMenu":
				this.DeathMenu.gameObject.SetActive(true);
				break;
			case "LevelVictoryMenu":
				this.LevelVictoryMenu.gameObject.SetActive(true);
				break;
			case "GameVictoryMenu":
				this.GameVictoryMenu.gameObject.SetActive(true);
				break;
		}
	}

	public void LoadLevel(string sceneName)
	{
		this.cameraOffset = new Vector3(0, 4, 7);

		this.MainMenu.gameObject.SetActive(false);
		this.LevelVictoryMenu.gameObject.SetActive(false);

		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		SceneManager.MoveGameObjectToScene(AudioManager.am.gameObject, SceneManager.GetSceneByName(sceneName));
		SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName(sceneName));
		this.currentScene = sceneName; Debug.Log("Loading " + this.currentScene);

		Invoke("BeginLevel", 1f);
	}

	void BeginLevel()
	{
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(this.currentScene));
		Cursor.lockState = CursorLockMode.Locked;
		this.playerSpawnPoint = GameObject.Find("PlayerSpawnPoint").GetComponent<Transform>();
		Instantiate(this.PlayerBall, this.playerSpawnPoint.position, Quaternion.identity, this.playerSpawnPoint);
	}

	public void PlayerDeath()
	{
		DestroyPlayer();

		AudioManager.am.musicSource.Pause();
		AudioManager.am.sfxSource.PlayOneShot(AudioManager.am.deathSound);
		AudioManager.am.musicSource.PlayDelayed(AudioManager.am.deathSound.length);
		Cursor.lockState = CursorLockMode.None;

		LoadMenu("DeathMenu");
		this.playerScore = 0f;
	}

	public void LevelComplete()
	{
		this.playerScore += this.levelWorth;

		DestroyPlayer();

		AudioManager.am.musicSource.Pause();
		AudioManager.am.sfxSource.PlayOneShot(AudioManager.am.victorySound);
		AudioManager.am.musicSource.PlayDelayed(AudioManager.am.victorySound.length);
		Cursor.lockState = CursorLockMode.None;

		LoadMenu("LevelVictoryMenu");
	}

	public void GameComplete()
	{
		this.playerScore += this.levelWorth;

		AudioManager.am.musicSource.Pause();
		AudioManager.am.sfxSource.PlayOneShot(AudioManager.am.victorySound);
		AudioManager.am.musicSource.PlayDelayed(AudioManager.am.victorySound.length);
		Cursor.lockState = CursorLockMode.None;

		LoadMenu("GameVictoryMenu");
		this.playerScore = 0f;
	}

	void DestroyPlayer()
	{
		foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
		{
			Destroy(player);
		}
	}

	IEnumerator UnloadCurrentScene()
	{
		Debug.Log("Unloading " + SceneManager.GetSceneByName(this.currentScene).name);
		yield return new WaitForEndOfFrame();
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(this.currentScene));
		yield return new WaitForEndOfFrame();
		this.currentScene = "MainMenu";
	}
}
