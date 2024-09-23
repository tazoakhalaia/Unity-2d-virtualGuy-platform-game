using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Area area;
    public float shootInterval = 1.5f;
    void Start()
    {
        area = FindAnyObjectByType<Area>();   
        InvokeRepeating("Shoot", shootInterval,shootInterval);
    }

  void Shoot()
    {
        if(area.touch)
        {
            Instantiate(bullet, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.transform.localScale = new Vector3(2, 2, 2);
        }
    }
}
