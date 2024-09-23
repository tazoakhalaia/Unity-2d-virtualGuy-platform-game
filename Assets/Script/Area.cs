using UnityEngine;

public class Area : MonoBehaviour
{
    public bool touch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            touch = true;
        }
    }
}
