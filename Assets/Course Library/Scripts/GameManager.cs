using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class GameManager : MonoBehaviour
{       
    public List<GameObject> targets;
   private float spawnRate = 1.0f;
   public TextMeshProUGUI scoreText;
   public TextMeshProUGUI gameOverText;
   public Button restartButton; 
   private int score;
   public GameObject titleScreen; 


   public bool isGameActive; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

IEnumerator SpawnTarget()
{
    while(isGameActive)
    {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0,targets.Count);
        Instantiate(targets[index]);
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true; 
         UpdateScore(0);
        StartCoroutine(SpawnTarget());

        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty; 
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true); 
        isGameActive = false; 
        gameOverText.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
