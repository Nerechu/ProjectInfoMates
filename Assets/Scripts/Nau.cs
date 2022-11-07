using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nau : MonoBehaviour
{
    public float _vel;

    public GameObject _prefabProjectil;
    public GameObject _prefabProjectil2;
    public GameObject _posCano;
    public GameObject _posCano2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectil = Instantiate(_prefabProjectil);
            GameObject projectil2 = Instantiate(_prefabProjectil2);
            projectil.transform.position = _posCano.transform.position;
            projectil2.transform.position = _posCano2.transform.position;
        }

        //Trobar costats pantalla
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(x:0, y:0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(x: 1, y: 1));

        minPantalla.x += 0.6f;
        maxPantalla.x -= 0.6f;
        minPantalla.y += 0.6f;
        maxPantalla.y -= 0.6f;

        float direccioX = Input.GetAxisRaw("Horizontal");
        float direccioY = Input.GetAxisRaw("Vertical");
        //Debug.Log(message: "direccioX: " + direccioX + " - direccioY: " + direccioY);

        Vector2 dirrecioIndicada = new Vector2(direccioX, direccioY).normalized;

        //Trobem posició actual de la nau:
        Vector2 posNova = transform.position;
        posNova += dirrecioIndicada * _vel * Time.deltaTime;
        posNova.x = Mathf.Clamp (posNova.x, minPantalla.x, maxPantalla.x);
        posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

        transform.position = posNova;
    }
}
