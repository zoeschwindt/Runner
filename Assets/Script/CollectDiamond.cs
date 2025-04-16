using UnityEngine;

public class CollectDiamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<Diamonds>().AddPoint();
            Destroy(gameObject);
        }
    }
}
