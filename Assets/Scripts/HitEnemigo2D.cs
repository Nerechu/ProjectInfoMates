using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{

    public int Daño;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag=="Personaje")
        {

            Debug.Log("Daño");

        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
