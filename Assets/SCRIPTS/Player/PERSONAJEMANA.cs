using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PERSONAJEMANA : MonoBehaviour
{
    
    [SerializeField] private float manainicial;
    [SerializeField] private float manamaxima;
    [SerializeField] private float regeneraciondemana;
    
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;
    private bool castingMagic = false;
    
   

    public float manaactual  { get;private  set; }
    private PLAYERVIDA pLAYERVIDA;
    


    

    // Start is called before the first frame update
    void Start()
    {
        manaactual = manainicial;
        ActualizarBarramana();
        InvokeRepeating(nameof(regenerarmana),1,1);
    }

    public void Usarmana(float cantidad)
    {
if(manaactual >= cantidad)
        {
            manaactual = cantidad;
        }
    }
    private void regenerarmana()
    {
        if (pLAYERVIDA.vida > 0f && manaactual < manamaxima)
        {
            manaactual += regeneraciondemana;
            ActualizarBarramana();
        }
    }

    private void ActualizarBarramana()
    {
        UImanager.Instance.Actualizarmanaplayer(manaactual, manamaxima);
    }
    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.G)){
            Usarmana(10f);
        }
        
        if (Input.GetKeyDown("6"))
        {
            castingMagic = true;
            currentCastTimer = 0;
            //UsedSpell(PlayerSpells[1]);
            Usarmana(10f);
        }
        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            if (currentCastTimer > timeBetweenCasts) castingMagic = false;
        }

        


    }
    

  
}
