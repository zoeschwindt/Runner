using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeControl : MonoBehaviour
{

    [SerializeField] private float time;
    [SerializeField] private TMP_Text timeUI;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Diamonds diamonds;
    [SerializeField] private PlayerMovement playerMovement;
    private bool gameStarted = true;

    void Start()
    {
        gameOverPanel.SetActive(false);


        time = 60f;
        Debug.Log("Juego Iniciado: Tiempo inicial 60 segundos");
    }

    void Update()
    {

        if (gameStarted && !GameManager.gameOver)
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
        GameManager.gameOver = true;
        GameManager.Instance.DefeatScreen();
        Debug.Log("Fin del juego, tiempo agotado");
    }





    public void RestartGame()
    {
        GameManager.gameOver = false;
        Time.timeScale = 1f;
        Diamonds.score = 0;


        diamonds.UpdateScoreExternally();


        diamonds.ResetMultiplier();


        time = 60f;
        gameOverPanel.SetActive(false);
        gameStarted = true;


        Debug.Log("Juego reiniciado");

        if (playerMovement != null)
        {
            playerMovement.ResetPlayer();
        }
    }
    public void Salir()
    {
        Application.Quit();
    }



}