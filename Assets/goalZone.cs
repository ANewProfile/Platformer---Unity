using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        movement p = other.GetComponent<movement>();
        if (p != null && p == movement.player)
        {
            if (movement.player.groundDetected)
            {
                gameManager.instance.EndLevel();
            }
        }
    }
}
