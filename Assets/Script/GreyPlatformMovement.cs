using UnityEngine;

public class GreyPlatformMovement : MonoBehaviour
{
    public float minX = 72; 
    public float maxX = 100;  
    public float speed = 0.1f;
    void Start()
    {
        
    }

    void Update()
    {
        float pingPongValue = Mathf.PingPong(Time.time * speed, 1);
        float newX = Mathf.Lerp(minX, maxX, pingPongValue); 

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }

}
