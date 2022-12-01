using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
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
        Vector2 posicio = transform.position;

        posicio = new Vector2(posicio.x, posicio.y - _vel * Time.deltaTime);

        transform.position = posicio;

        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < maxPantalla.y)
        {
            //Si el projectil sale de la pantalla, se destruye.
            Destroy(gameObject);
            

        }
        
    }
}
