using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigoVector2 : MonoBehaviour
{
    public Animator ani;
    public Vector2Enemigo enemigoVector2;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Personaje")
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemigoVector2.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
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
