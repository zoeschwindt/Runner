using UnityEngine;

public class CollectMultiplierDiamond : MonoBehaviour
{
    public int multiplier = 2;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<Diamonds>().ActivateMultiplier(multiplier, duration);
            Destroy(gameObject);
        }
    }

}
