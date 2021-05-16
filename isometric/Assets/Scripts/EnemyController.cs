using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;

    int health;
    float speed;

    void Start()
    {
        Player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        
        health = 80 + Random.Range(0, 50);
        speed = 2.0f + Random.Range(0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Methods.lookAt2D(transform, Player.transform);

        rb.velocity = transform.forward * speed;
    }

    public void setDamage()
    {
        this.health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            
        }
    }

    private void OnDestroy()
    {
        UIController.addScore(10);
    }
}
