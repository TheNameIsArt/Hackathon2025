using UnityEngine;

public class Scr_WallSpriteColliders : MonoBehaviour
{
    private SpriteRenderer horizontalWallSpriteRenderer;
    private int playerCollisionCount = 0;

    private void Start()
    {
        // Cache the SpriteRenderer component for performance
        horizontalWallSpriteRenderer = GameObject.Find("Arcade_Interior_HorizontalWalls").GetComponent<SpriteRenderer>();
        if (horizontalWallSpriteRenderer != null)
        {
            horizontalWallSpriteRenderer.enabled = false; // Ensure it's initially disabled
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollisionCount++;
            UpdateSpriteRendererState();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollisionCount--;
            UpdateSpriteRendererState();
        }
    }

    private void UpdateSpriteRendererState()
    {
        if (horizontalWallSpriteRenderer != null)
        {
            // Enable the SpriteRenderer if the player is colliding with any of the colliders
            horizontalWallSpriteRenderer.enabled = playerCollisionCount > 0;
        }
    }
}
