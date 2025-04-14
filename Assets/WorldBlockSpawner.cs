using UnityEngine;

public class WorldBlockSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    GameObject[] blocks;

    public Transform spawnPoint;
    void Start()
    {
        SpawnBlock();

        InvokeRepeating("SpawnBlock", 0, 1.8f);
    }

    // Update is called once per frame
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
