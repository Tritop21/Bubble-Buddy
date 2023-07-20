using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGo : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;
    void Start()
    {
        
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;


        if(distance < distanceBetween)
        {
            Vector2 newPos = this.transform.position;
            newPos.x = Mathf.MoveTowards(newPos.x, player.transform.position.x, Time.deltaTime * speed * -1);
            transform.position = newPos;
        }
    }
} 

