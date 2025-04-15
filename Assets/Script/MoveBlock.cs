using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed;
    public float offsetCleaner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < offsetCleaner)
        {
            Destroy(gameObject);
        }
    }


    
}
