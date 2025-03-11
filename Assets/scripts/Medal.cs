using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metalMedal,bronzMedal,silverMedal,goldMedal;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        int gameScore = GameManager.gameScore;


        if(gameScore > 0 && gameScore <= 10)
        {
            img.sprite = metalMedal;
        }

        else if(gameScore > 10 && gameScore <= 20)
        {
            img.sprite = bronzMedal;
        }

        else if(gameScore > 20 && gameScore <= 30)
        {
            img.sprite = silverMedal;
        }

        else if(gameScore > 30)
        {
            img.sprite = goldMedal;
        }
    }
}
