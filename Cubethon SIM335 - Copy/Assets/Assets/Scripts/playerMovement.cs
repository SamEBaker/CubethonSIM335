
using UnityEngine;



public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;

    GameManager manager;
    public float forwardForce = 2000;
    public float sidewaysForce = 500f;

    public void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if( Input.GetKey("d"))
        {
            //rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveRight = new MoveRight(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.Command(moveRight);
            invoker.ExecuteCommand();

        }

        if( Input.GetKey("a"))
        {
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveLeft = new MoveLeft(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.Command(moveLeft);
            invoker.ExecuteCommand();
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }
    }
}
