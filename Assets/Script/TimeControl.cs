using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeControl : MonoBehaviour
{

    public float time;
    public TMP_Text timeUI;
    public GameObject gameOverPanel;

    private bool isGameOver = false; 
    private bool gameStarted = true; 

    void Start()
    {
        gameOverPanel.SetActive(false); 
         
      
        time = 60f; 
        Debug.Log("Juego Iniciado: Tiempo inicial 60 segundos");
    }

    void Update()
    {
        
        if (gameStarted && !isGameOver)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;

                float minutes = Mathf.FloorToInt(time / 60);
                float seconds = Mathf.FloorToInt(time % 60);

                timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                Debug.Log("Tiempo restante: " + time);
            }
            else
            {
                GameOver();
            }
        }
    }
    public void AddTime(float extraTime)
    {
        time += extraTime;
        if (time < 0) time = 0;

        Debug.Log("Tiempo actualizado: " + time);
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0; 
        Debug.Log("Fin del juego, tiempo agotado");
    }





    public void RestartGame()
    {
        GameManager.gameOver = false;
        Time.timeScale = 1f;
        Diamonds.score = 0;


        Object.FindFirstObjectByType<Diamonds>().UpdateScoreExternally();

 
        Object.FindFirstObjectByType<Diamonds>().ResetMultiplier();

        
        time = 60f;
        isGameOver = false;
        gameOverPanel.SetActive(false);
        gameStarted = true;
       

        Debug.Log("Juego reiniciado");

        PlayerMovement player = Object.FindFirstObjectByType<PlayerMovement>();
        if (player != null)
        {
            player.ResetPlayer();
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
    


}
