using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PERSONAJE_ANIMACIONEES : MonoBehaviour
{

    [SerializeField] private string layeridle;
    [SerializeField] private string layercaminar;
    private Animator animator1;
    private PERSONAJE_MOVIMIENTO personajeenmovimiento;
    private readonly int derrotado = Animator.StringToHash("derrotado");
 
    
    
    private void Awake()
    {
        animator1 = GetComponent<Animator>();
        personajeenmovimiento = GetComponent<PERSONAJE_MOVIMIENTO>();
    }
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Actualizarlayer();

        if(personajeenmovimiento.enMovimiento == false)
        {
            return;
        }
        animator1.SetFloat(name:"X", personajeenmovimiento.Dirmov.x);
        animator1.SetFloat(name: "Y", personajeenmovimiento.Dirmov.y);

    }
    private void Activarlayer(string nombreLayer)
    {
        for (int i = 0; i < animator1.layerCount; i++)
        {
            animator1.SetLayerWeight(i, 0);
        }
        animator1.SetLayerWeight(animator1.GetLayerIndex(nombreLayer),1);
    }
    private void Actualizarlayer()
    {
        if (personajeenmovimiento.enMovimiento)
        {
            Activarlayer(layercaminar);
        }
        else
        {
            Activarlayer(layeridle);
        }
    }

    private void DerrotadoRespuesta()
    {
        if (animator1.GetLayerWeight(animator1.GetLayerIndex(layeridle)) ==1 )
        {
            animator1.SetBool(derrotado, true);
        }  
    }
    private void OnEnable()
    {
        PLAYERVIDA.EventoDerrotado += DerrotadoRespuesta;
    }
    private void OnDisable()
    {
        PLAYERVIDA.EventoDerrotado -= DerrotadoRespuesta;
    }
}
