using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameOver;
    public GameObject defeatScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

            if (defeatScreen != null && !defeatScreen.activeSelf)
            {
                defeatScreen.SetActive(true);
            }
        }

    }
    
}
