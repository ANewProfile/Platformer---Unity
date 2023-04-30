using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGen : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public int numPlatfoms = 5;
    public GameObject platformPrefab;
    public goalZone goalPrefab;
    public Vector2 randomHeight;
    public float maxHeight;
    public Vector2 randomGap;
    public float maxGap;
    public float randomAngle;
    public float maxAngle;
    public turretController turretControl;
    // Start is called before the first frame update
    void Start()
    {
        randomHeight.x = Mathf.Min(randomHeight.x + gameManager.instance.numLevels, maxHeight);
        randomGap.x = Mathf.Min(randomGap.x + gameManager.instance.numLevels, maxGap);
        randomAngle = Mathf.Min(randomAngle + (gameManager.instance.numLevels * 2), maxAngle);
        turretControl.direction = direction;
        generatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void generatePlatforms()
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < numPlatfoms; i++)
        {
            float height = Random.Range(randomHeight.x, randomHeight.y);
            float gap = Random.Range(randomGap.x, randomGap.y);
            float angle = Random.Range(-randomAngle, randomAngle);
            Vector3 dir = Quaternion.Euler(0, angle, 0) * direction;
            pos += dir * gap + Vector3.up * height;
            Instantiate(platformPrefab, pos, Quaternion.identity);
            if(i%2 == 1)
            {
                Vector3 turretPos = pos + Vector3.right * 3 + Vector3.up * 5;
                turretControl.spawnTurret(turretPos);
            }
        }
        Instantiate(goalPrefab, pos, Quaternion.identity);
    }
}