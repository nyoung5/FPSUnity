//Copyright Nathan Young & Alex Zaterka 2016
//@author azaterka
//@author nyoung
//Note: We did pairwise programming for the entire project


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


/*
 *This class controls the main logic behind the game
 */
public class ControllerScript : MonoBehaviour {

	private int scoreValue = 0;
	private int lifeValue = 10;
	[SerializeField] private Text scoreText;
	[SerializeField] private Text lifeText;
	[SerializeField] private Text enemiesText;
	[SerializeField] private GameObject deathScreen;
	[SerializeField] private GameObject winScreen;
	private GameObject[] targets;

	// Use this for initialization
	void Start () {
		UpdateLifeText();
		deathScreen.SetActive (false);
		winScreen.SetActive (false);
		UpdateEnemiesText ();
	}

	//Gives all targets to array
	int CountTargets(){
		targets = GameObject.FindGameObjectsWithTag ("Target");
		return targets.Length;
	}
		
	void UpdateScoreText(){
		scoreText.text = "Murder Points: " + scoreValue.ToString();
	}
	void UpdateLifeText(){
		lifeText.text = "Hits Left: " + lifeValue.ToString();
	}
	void UpdateEnemiesText(){
		enemiesText.text = "Targets Left: " + CountTargets();
	}

	//Logic for checking if we won happens in change score
	public void ChangeScore(int change){
		scoreValue += change;

    	UpdateScoreText();
		StartCoroutine (CheckWin ());

	}
	public void ChangeLife(int change){
		lifeValue += change;
		UpdateLifeText();

		if(lifeValue <= 0){
			//pause the game
			//http://answers.unity3d.com/questions/7544/how-do-i-pause-my-game.html
			Time.timeScale = 0;
			deathScreen.SetActive (true);
			Cursor.lockState = CursorLockMode.None;

		}
	}
	public void GameRestart(){
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene (currentScene.name);
		Time.timeScale = 1;
	}

	//brings up menu and gives mouse
	public void YouWin(){
		Time.timeScale = 0;
		winScreen.SetActive (true);
		Cursor.lockState = CursorLockMode.None;
	}

	//threaded to check if a win happens to account for the time we want the targets fly back
	//Checks to see if player has won
	private IEnumerator CheckWin(){
		yield return new WaitForSeconds (.5f);
		UpdateEnemiesText ();
		if (CountTargets () <= 0) {
			YouWin ();
		}
	}
}
