using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam; // Reference to your first-person camera

    void Update()
    {
        // Shoot when left mouse button is clicked
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        // Shoot a ray out from the center of the camera view
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // Check if the hit object has the EnemyAtack script
            EnemyAtack enemy = hit.transform.GetComponent<EnemyAtack>();

            // If an enemy script was found, deal damage
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
