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
    public Vector2 randomGap;
    public float randomAngle;
    // Start is called before the first frame update
    void Start()
    {
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
        }
        Instantiate(goalPrefab, pos, Quaternion.identity);
    }
}