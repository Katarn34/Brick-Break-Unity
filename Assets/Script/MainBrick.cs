using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBrick : MonoBehaviour
{
    public int points;
    public GameManager Gm;
    public Transform powerupLife;
    public Transform powerupSize;
    public Transform Explosion;
   private void OnCollisionEnter2D(Collision2D _collision)
    {
        //If the ball touch the bricks 50% chance of getting the extra life power up and 25% for the Extra size
        //Updating the score and setting it for each bricks and destroying the brick
        if (_collision.gameObject.tag == "Ball")
        {
            int randChance = Random.Range(1, 101);
            if(randChance < 50)
                Instantiate(powerupLife,transform.position,transform.rotation);
            {

            }
            if (randChance < 25)
                Instantiate(powerupSize, transform.position, transform.rotation);

            Gm.UpdateScore(points);
            Gm.UpdateNumberOfBricks();
            Instantiate (Explosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
