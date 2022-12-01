using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVector2 : MonoBehaviour
{
    // Start is called before the first frame update

    //Variables necesarias
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;

    private Vector2 dirrecioIndicada;

    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Personaje");
        


    }

    // Update is called once per frame
    public void Comportamientos()
    {

        //Trobar costats pantalla
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minPantalla.x += 0.6f;
        maxPantalla.x -= 0.6f;
        minPantalla.y += 0.6f;
        maxPantalla.y -= 0.6f;

        /*Empieza*/
        Vector2 posNova = transform.position;

        //Estado caminando
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            //Cronometro que hace una accion o tra de forma infinita
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            //Rutina que realizara el random dependiendo del resultado de cronometro
            switch (rutina)
            {
                case 0:
                    //No camina se queda en estado de idle
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    //Se mueve en una direccion dependiendo del Random.Range(min, max) y sumamos un numero en rutina
                    direccion = Random.Range(0, 3);
                    rutina++;
                    break;

                case 2:
                    //Indicador de movimiento
                    switch (direccion)
                    {
                        case 0:
                            //Derecha
                            dirrecioIndicada = new Vector2(1, 0); 
                            posNova += dirrecioIndicada * speed_walk * Time.deltaTime;
                            posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                            posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                            transform.position = posNova;
                            break;
                        case 1:
                            //Izquierda
                            dirrecioIndicada = new Vector2(-1, 0); 
                            posNova += dirrecioIndicada * speed_walk * Time.deltaTime;
                            posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                            posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                            transform.position = posNova; 
                            break;
                        case 2:
                            //Arriba
                            dirrecioIndicada = new Vector2(0, 1);
                            posNova += dirrecioIndicada * speed_walk * Time.deltaTime;
                            posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                            posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                            transform.position = posNova; 
                            break;
                        case 3:
                            //Abajo
                            dirrecioIndicada = new Vector2(0, -1);
                            posNova += dirrecioIndicada * speed_walk * Time.deltaTime;
                            posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                            posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                            transform.position = posNova; 
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {   //Emmpieza a Correr
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    //CORRE A LA DERECHA
                    dirrecioIndicada = new Vector2(1, 0);
                    posNova += dirrecioIndicada * speed_run * Time.deltaTime;
                    posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                    posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                    transform.position = posNova;
                    ani.SetBool("attack", false);
                }
                else if (transform.position.x > target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    //CORRE A LA IZQUIERDA
                    dirrecioIndicada = new Vector2(-1, 0);
                    posNova += dirrecioIndicada * speed_run * Time.deltaTime;
                    posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                    posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                    transform.position = posNova;
                    ani.SetBool("attack", false);
                }
                else if (transform.position.y < target.transform.position.y)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    // CORRE A Arriba
                    dirrecioIndicada = new Vector2(0, 1);
                    posNova += dirrecioIndicada * speed_run * Time.deltaTime;
                    posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                    posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                    transform.position = posNova;
                    ani.SetBool("attack", false);
                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    //CORRE A Abajo
                    dirrecioIndicada = new Vector2(0, -1);
                    posNova += dirrecioIndicada * speed_run * Time.deltaTime;
                    posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                    posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                    transform.position = posNova;
                    ani.SetBool("attack", false);
                }
            }
            //Empieza a atacar
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        //ATACAR A LA DERECHA
                        dirrecioIndicada = new Vector2(1, 0);
                        posNova += dirrecioIndicada * speed_run * Time.deltaTime;
                        posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                        posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                        transform.position = posNova;
                    }
                    else
                    {
                        //ATACAR A LA IZQUIERDA
                        dirrecioIndicada = new Vector2(-1, 0);
                        posNova += dirrecioIndicada * speed_run * Time.deltaTime;
                        posNova.x = Mathf.Clamp(posNova.x, minPantalla.x, maxPantalla.x);
                        posNova.y = Mathf.Clamp(posNova.y, minPantalla.y, maxPantalla.y);

                        transform.position = posNova;
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }
            }
        }
    }
    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Comportamientos();
    }
}
