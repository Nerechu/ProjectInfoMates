using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour

{
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posProjectilAr = transform.position;
        Vector2 posProjectilAb = transform.position;

        posProjectilAr = new Vector2(posProjectil.x, y:posProjectil.y + _vel * Time.deltaTime);
        posProjectilAb = new Vector2(posProjectil.y, x:posProjectil.x + _vel * Time.deltaTime);

        transform.position = posProjectilAr;
        transform.position = posProjectilAb;
        //Ayuda arnau Posicion del personaje disparo
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(x: 1, y: 1));

        if (transform.position.y > maxPantalla.y)
        {
            //Si el projectil sale de la pantalla, se destruye.
            Destroy(gameObject);
            

        }

    }
}
