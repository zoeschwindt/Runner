using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeControl : MonoBehaviour
{

    public float time;
    public TMP_Text timeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
         time -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        
        timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        //else
        //{
        //    timeUI.text = "00:00";
        //    SceneManager.LoadScene("GameOver");
        //}

    }
        
}
