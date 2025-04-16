using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuStart()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
