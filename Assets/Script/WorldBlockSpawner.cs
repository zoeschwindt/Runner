using UnityEngine;

public class WorldBlockSpawner : MonoBehaviour
{
    
    [SerializeField]
    GameObject[] blocks;

    public Transform spawnPoint;
    void Start()
    {
        SpawnBlock();

        InvokeRepeating("SpawnBlock", 0, 1.8f);
    }

  
    void Update()
    {
       
    }
    public void SpawnBlock()
    {
        int randomIndex = Random.Range(0, blocks.Length);
        GameObject block = Instantiate(blocks[randomIndex], spawnPoint.position, Quaternion.identity);
        block.transform.SetParent(transform);

    }
}
