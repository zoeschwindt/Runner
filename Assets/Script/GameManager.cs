using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool gameOver;
    public GameObject defeatScreen;
    [SerializeField] private GameObject pause_Panel;
    private bool isPaused = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gameOver = false;
        pause_Panel.SetActive(false);
        defeatScreen.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void DefeatScreen()
    {

        defeatScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }


    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            pause_Panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pause_Panel.SetActive(false);
        }
    }

}