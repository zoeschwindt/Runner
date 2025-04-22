using UnityEngine;

public class CollectTimePenalty : MonoBehaviour
{
    public float tiempoAPerder = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeControl timeControl = Object.FindFirstObjectByType<TimeControl>();
            if (timeControl != null)
            {
                timeControl.AddTime(-tiempoAPerder); 
            }

            Destroy(gameObject); 
        }
    }
}
