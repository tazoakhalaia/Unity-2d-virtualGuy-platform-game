using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if(animator != null)
            {
                animator.SetBool("isDeath", true);
            }
            Destroy(gameObject, 0.5f);
        }
    }
}
