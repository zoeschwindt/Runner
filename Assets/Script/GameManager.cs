using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool gameOver;
    public GameObject defeatScreen;
    [SerializeField] private GameObject pause_Panel;
    private bool isPaused = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipGamePlay;
    [SerializeField] private AudioClip audioClipGameOver;


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

       
        audioSource.clip = audioClipGamePlay;

    }
    void Start()
    {
        gameOver = false;
        pause_Panel.SetActive(false);
        defeatScreen.SetActive(false);
        audioSource.Play();
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
        audioSource.clip = audioClipGameOver;
        audioSource.Play();

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
            audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pause_Panel.SetActive(false);
            audioSource.UnPause();
        }
    }

    public void ResetGame()
    {
        audioSource.clip = audioClipGamePlay;
        audioSource.Play();
    }
}
