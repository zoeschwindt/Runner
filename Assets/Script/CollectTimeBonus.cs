using UnityEngine;

public class CollectTimeBonus : MonoBehaviour
{
    public float tiempoExtra = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            TimeControl timeControl = Object.FindFirstObjectByType<TimeControl>();
            if (timeControl != null)
            {
                timeControl.AddTime(tiempoExtra);
            }

            Destroy(gameObject);
        }
    }
}
