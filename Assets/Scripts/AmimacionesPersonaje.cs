using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmimacionesPersonaje : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MovimientoHorizontal(float movimientoHorizontal){
          
        _animator.SetFloat("Velocidad", Mathf.Abs(movimientoHorizontal));
    }

}
