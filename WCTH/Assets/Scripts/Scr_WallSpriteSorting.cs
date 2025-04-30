using UnityEngine;

public class Scr_WallSpriteSorting : MonoBehaviour
{
    private GameObject wallTriggers;
    private SpriteRenderer wallSprite;
    private Collider2D wallCollider;

    public bool underWall;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        underWall = false;
        wallSprite = GetComponent<SpriteRenderer>();
        wallSprite.enabled = !wallSprite.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if ( underWall == true) 
        {
            wallSprite.enabled = wallSprite.enabled;
        }
        else if (underWall == false)
        {
            wallSprite.enabled = !wallSprite.enabled;
        }
    }


}
