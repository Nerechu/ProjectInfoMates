using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float _vel;
    private float _velocidadCaminar;

    public GameObject _prefabProjectil;
    public GameObject _posCano;

    private AmimacionesPersonaje _animacionesPersonaje;
    private SpriteRenderer _spriteRendererPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        _velocidadCaminar = 5f;

        _animacionesPersonaje = GetComponent<AmimacionesPersonaje>();
        _spriteRendererPersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectil = Instantiate(_prefabProjectil);
            projectil.transform.position = _posCano.transform.position;
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

        //Trobem posici� actual del personatge:
        Vector2 posNova = transform.position;
        posNova += dirrecioIndicada * _vel * Time.deltaTime;
        posNova.x = Mathf.Clamp (posNova.x, minPantalla.x, maxPantalla.x);
        posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

        transform.position = posNova;

        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _velocidadCaminar;
        OrientacionSprite(inputHorizontal);
        _animacionesPersonaje.MovimientoHorizontal(inputHorizontal);
    }

    void OrientacionSprite(float inputHorizontal){
        if (inputHorizontal > 0){

            _spriteRendererPersonaje.flipX = false;

        } else if(inputHorizontal < 0) {

            _spriteRendererPersonaje.flipX = true;
            
        }
    }
}
