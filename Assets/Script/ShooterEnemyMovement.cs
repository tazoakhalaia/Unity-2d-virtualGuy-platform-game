using UnityEngine;

public class ShooterEnemyMovement : MonoBehaviour
{
    public float minX = 79;
    public float maxX = 100;
    public float speed = 0.35f;

    void Update()
    {
        ShooterEnemyMovements();
    }

    void ShooterEnemyMovements()
    {
        float pingPongValue = Mathf.PingPong(Time.time * speed, 1);
        float newX = Mathf.Lerp(minX, maxX, pingPongValue);
        transform.position = new Vector3(newX,transform.position.y, transform.position.z);
    }
}
