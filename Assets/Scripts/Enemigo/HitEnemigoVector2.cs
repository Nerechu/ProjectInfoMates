using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigoVector2 : MonoBehaviour
{
    public int Da�o;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Personaje")
        {

            Debug.Log("Da�o");

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
