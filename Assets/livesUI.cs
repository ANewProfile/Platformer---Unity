using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesUI : MonoBehaviour
{
    int lives
    {
        get
        {
            return gameManager.instance.lives;
        }
    }
    int score
    {
        get
        {
            return gameManager.instance.score;
        }
    }
    public TMPro.TextMeshProUGUI lifeLabel;
    public TMPro.TextMeshProUGUI scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeLabel.text = string.Format("Lives: {0}", lives);
        scoreLabel.text = string.Format("Score: {0}", score);
    }
}
