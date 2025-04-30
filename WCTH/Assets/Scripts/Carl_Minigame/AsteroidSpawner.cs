using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidPool asteroidPool;
    private float spawnInterval = 1f;
    private float minYSpawn = -3f;
    private float maxYSpawn = 3f;
    private float xSpawn = 12;

    private float moveSpeed = 5f;

    private float timer;

    private float deadZone = 12f;
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
    }
}
