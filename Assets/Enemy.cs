using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    void Start()
    {
        health = 100;
    }

   
    void Update()
    {
        
    }

    public void Damage(int damagePower)
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
        else
        {
            health = health - damagePower;
        }
    }
}
