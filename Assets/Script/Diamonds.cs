using TMPro;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    private int multiplier = 1;
    public GameObject scoreMultiplierText;
    void Start()
    {
        score = 0; 
        UpdateScoreText();
        scoreMultiplierText.SetActive(false);
    }
    public void UpdateScoreExternally()
    {
        UpdateScoreText();
    }
    public void AddPoint()
    {
        score += 1 * multiplier;
        UpdateScoreText();
    }

    public void ActivateMultiplier(int newMultiplier, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(MultiplierCoroutine(newMultiplier, duration));
    }

    private System.Collections.IEnumerator MultiplierCoroutine(int newMultiplier, float duration)
    {
        multiplier = newMultiplier;
        Debug.Log("¡Multiplicador x" + multiplier + " activado!");
        scoreMultiplierText.SetActive(true);
        yield return new WaitForSeconds(duration);
        multiplier = 1;
        scoreMultiplierText.SetActive(false);

        Debug.Log("Multiplicador terminado");
    }
    public void ResetMultiplier()
    {
        multiplier = 1;
    }
    void UpdateScoreText()
    {
        scoreText.text = " " + score;
    }
}
