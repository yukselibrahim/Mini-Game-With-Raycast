using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootPoint;

    void Start()
    {
        Destroy(gameObject, 0.7f); //Dedi�imizde mermi belirtti�imiz s�re sonras� yok olur.     
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * 100 * Time.deltaTime);
    }
}
