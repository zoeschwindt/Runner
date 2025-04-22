using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool gameOver;
    public GameObject defeatScreen;
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
    }

    // Update is called once per frame


    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;

        }

    }
    public void DefeatScreen()
    {

        defeatScreen.SetActive(true);

    }

}