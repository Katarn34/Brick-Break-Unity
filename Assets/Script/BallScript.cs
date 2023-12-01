using UnityEngine;


public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float ballForce;
    private bool gameStarted = false;
    public GameManager Gm;
    public Transform paddle;

    //Setting the ForceSpeed Of the Ball
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * 500);
    }
    //Stop the ball if the game is over
    private void Update()
    {
        if (Gm.gameOver)
        {
            return;
        }
        
        {
            
        }
        if (Input.GetKeyUp(KeyCode.Space) && gameStarted == false)
        {
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.AddForce(new Vector2(ballForce, ballForce));
            gameStarted = true;
        }
        //Setting the position of the ball on the paddle
        if (!gameStarted)
        {
            transform.position = paddle.position;
        }
    }
    //If the ball touch the WallDown, the velocity stop, the ball go on top of the paddle and the player lose 1 life
         void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WallDown"))
            {
                rb.velocity = Vector2.zero;
                gameStarted = false;
                Gm.UpdateLives(-1);
        }
        }


    
    
}
