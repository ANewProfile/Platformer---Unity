using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Awake is called before Start(or before and game managers is created)
    public static gameManager instance;
    public int lives = 3;
    public int score = 0;
    public int numLevels { get; private set; }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            lives = 3;
            score = 0;
            numLevels = 0;
            SceneManager.LoadScene(0);
        }
    }
    public void EndLevel()
    {
        SceneManager.LoadScene(0);
        score++;
        numLevels++;
    }
}
