using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float lifetime = 3;
    public float speed = 7;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        lifetime -= Time.fixedDeltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Aim(Vector3 target)
    {
        transform.LookAt(target);
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
