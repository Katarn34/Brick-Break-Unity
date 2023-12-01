using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;
    public float newScaleSize = 2f;
    void Start()
    {

    }
    //Stop the paddle movement if the game is over, move the paddle in the axis and setting the position of the walls
    void Update()
    {
        if(gm.gameOver)
        {
            return;
        }

        float horizontal = Input.GetAxis ("Horizontal");

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);

        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }

    }
    //If the paddle touch the power up Extra life the player gain 1 life
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Extra Life"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
    //if the paddle touch the power up Extra Size the player increase the size of the paddle 1 Time    
        if(other.CompareTag("Extra Size"))
        {
            Vector3 newSize = transform.localScale;
            newSize.x = newScaleSize;

            transform.localScale = newSize;
            Destroy(other.gameObject);
        }
    }
}