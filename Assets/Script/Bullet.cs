using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 20;
    private Vector2 shootDirection;

    void Start()
    {
       
    }

    void Update()
    {
        ShootBullet();
    }


    public void BulletDirection(Vector2 direction)
    {
        shootDirection = direction.normalized;
    }

    public void ShootBullet()
    {
        transform.Translate(shootDirection * bulletSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
