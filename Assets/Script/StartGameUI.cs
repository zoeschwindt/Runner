//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class StartGameUI : MonoBehaviour
//{
//    public static bool reinicioDesdeDerrota = false; 

//    public GameObject panelInicio;      
//    public GameObject gameOverPanel;    

//    void Start()
//    {
//        if (reinicioDesdeDerrota)
//        {
           
//            panelInicio.SetActive(false);
//            gameOverPanel.SetActive(false); 
//            Time.timeScale = 1f;
//            reinicioDesdeDerrota = false; 
//        }
//        else
//        {
            
//            Time.timeScale = 0f; 
//            panelInicio.SetActive(true); 
//            gameOverPanel.SetActive(false); 
//        }
//    }

//    public void IniciarJuego()
//    {
//        panelInicio.SetActive(false); 
//        Time.timeScale = 1f; 
//    }

//    public void ReiniciarJuego()
//    {
//        reinicioDesdeDerrota = true; 
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
//    }
//}

