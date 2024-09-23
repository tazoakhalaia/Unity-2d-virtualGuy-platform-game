using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 3;

    void Update()
    {
        BulletMovement();
    }

    void BulletMovement()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
