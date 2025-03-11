using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipespawner : MonoBehaviour
{
    public GameObject Pipe;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;
    // Start is called before the first frame update
    void Start()
    {
        //InstantiatePipe();

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false && GameManager.gameStarted == true) 
        {
            timer += Time.deltaTime;
            if(timer >= maxTime)
            {
                randomY = Random.Range(minY,maxY);
                InstantiatePipe();
                timer = 0;
            } 
        }
    
    }

    public void InstantiatePipe()
    {
        GameObject newPipe = Instantiate(Pipe);
        newPipe.transform.position = new Vector2(transform.position.x,randomY);
    }



}
