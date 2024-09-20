using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float playerSpeed = 5;
    public float jumpHeight = 8;
    public bool isGrounded = false;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public Vector3 rotation;
    public GameObject camera;
    public GameObject spikes;
    public GameObject bulletPrefabs;
    public GameObject BlockGoBackWay;
    public Transform bulletSpawPoint;
    private Collider2D playerCollider;
    private CoinManager coinManager;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        rigidBody.freezeRotation = true;
        transform.eulerAngles = rotation;
        coinManager = FindFirstObjectByType<CoinManager>(); 
    }

    void Update()
    {
        PlayerMovement();
        Shoot();
    }

    public void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.W) && isGrounded ) 
        {
            animator.SetBool("isJump", true);
            rigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(moveX > 0)
        {
            transform.Translate(Vector2.left * -moveX * playerSpeed * Time.deltaTime);
            transform.eulerAngles = rotation;

        }

        if(moveX < 0)
        {
            transform.Translate(Vector2.left * moveX * playerSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0,180,0);
        }

        camera.transform.position = new Vector3(transform.position.x, 0, -10);

        if(transform.position.x < 0)
        {
            camera.transform.position = new Vector3(0, 0, -10);
        }

        if(moveX != 0)
        {
            animator.SetBool("isRunning", true);
        }else
        {
            animator.SetBool("isRunning", false);  
        }

        if(moveX  != 0 && isGrounded == false)
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefabs,bulletSpawPoint.position,bulletSpawPoint.rotation);
            bullet.transform.localScale = new Vector3(1,1,1);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            Vector2 shootDirection = transform.eulerAngles.y == 0 ? Vector2.right : Vector2.left;
            bulletScript.BulletDirection(shootDirection);

            Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
            if (bulletCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, bulletCollider);
            }
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }

        if(collision.gameObject.tag == "BloackBackWayPlatform")
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
            BlockGoBackWay.SetActive(true); 
        }

        if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy") 
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gift")
        {
            Destroy(collision.gameObject);
            coinManager.GiftCount();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            isGrounded = false;
    }
}
