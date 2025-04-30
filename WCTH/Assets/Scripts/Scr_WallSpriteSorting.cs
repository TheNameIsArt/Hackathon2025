using UnityEngine;

public class Scr_WallSpriteSorting : MonoBehaviour
{
    private GameObject wallTriggers;
    private SpriteRenderer wallSprite;
    private Collider2D wallCollider;
    private bool underWall;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        wallSprite = GetComponent<SpriteRenderer>();
        wallSprite.enabled = !wallSprite.enabled;
        underWall = GameObject.Find("WallColliders").GetComponent<Scr_WallSpriteSorting>().underWall;
    }

    // Update is called once per frame
    void Update()
    {

        if ( underWall== true) 
        {
            wallSprite.enabled = wallSprite.enabled;
        }
        else if (underWall == false)
        {
            wallSprite.enabled = !wallSprite.enabled;
        }
    }


}
