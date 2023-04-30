using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<turret> turrets;
    public Vector3 direction;
    public turret turretPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTurret(Vector3 pos)
    {
        turret newTurret = Instantiate(turretPrefab, pos, Quaternion.identity);
        turrets.Add(newTurret);
    }
}