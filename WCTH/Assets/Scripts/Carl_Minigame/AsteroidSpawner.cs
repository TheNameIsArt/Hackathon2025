using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidPool asteroidPool;
    private float spawnInterval = 0.1f; //Normal spawnInterval 1
    private float moveSpeed = 15f; //Normal speed 5
    private float minYSpawn = -4f;
    private float maxYSpawn = 4;
    private float xSpawn = 12;
    private float timer;
    public bool cheatCode = false;
    private float spawnIntervalCheatCode = 1f;
    private float moveSpeedCheatCode = 7f;

    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            GameObject asteroid = AsteroidPool.sharedInstance.GetPooledObject(); 

            if (asteroid != null)
            {
            asteroid.SetActive(true);  // This makes it visible
            float randomY = Random.Range(minYSpawn, maxYSpawn);
            asteroid.transform.position = new Vector2(xSpawn, randomY);

            Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.left * moveSpeed;
            }
        }

        if (cheatCode == !false)
        {
            moveSpeed = moveSpeedCheatCode;
            spawnInterval = spawnIntervalCheatCode;
        }
    }
}
