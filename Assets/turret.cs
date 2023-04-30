using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public projectile projectilePrefab;
    public float fireRate = 1;
    private float fireTimer;
    public bool firing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Fire()
    {
        projectile bam = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        bam.Aim(movement.player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0)
            {
                Fire();
                fireTimer = fireRate;
            }
        }
    }
}
