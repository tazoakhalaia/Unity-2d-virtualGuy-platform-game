using UnityEngine;

public class GiftManager : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isCollected", true);
            Destroy(gameObject, 0.6f);
        }
    }
}
