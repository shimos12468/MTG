using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIDABASE : MonoBehaviour
{
    [SerializeField] protected float vidainicial;
    [SerializeField] protected float vidamaxima;
    private Animator anim;
    public int soul;
    public ParticleSystem particle = null;
    public GameObject characterSoul;
    public GameObject soulempty;
    public bool isRobot;

    public float vida { get; protected set; }
    // Start is called before the first frame update
 protected  virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        vida = vidainicial; 
    }

    // Update is called once per frame
    public void recibirDano(float cantidad)
    {
        if (cantidad <= 0f)
        {
            return;
        }

        if (vida > 0f)
        {
            vida -= cantidad;
            actualizarBarraVida(vida, vidamaxima);
            if (vida <= 0f)
            {
                actualizarBarraVida(vida, vidamaxima);
                playerDerrotado();
            }
        }


    }

   

    protected virtual void actualizarBarraVida(float vidaActual, float vidaMaxima)
    {
        
    }
    public void GenerateSoul()
    {
        if(isRobot == false) 
        {
            particle.Play();
            characterSoul.SetActive(false);
        }
        
        
    }

    public void SoulSpawn()
    { while(soul > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                characterSoul.SetActive(true);
                Instantiate(characterSoul, new Vector3(0, 0, 0), Quaternion.identity);
                soul = soul -1;
            }
        }
       
    }
 
        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "soul"&& Input.GetKeyDown(KeyCode.B))
        {
            particle.Stop();
            soulempty.SetActive(false);
            soul = soul + 1;


        }
    }
   

    protected virtual void playerDerrotado()
    {
        anim.SetBool("derrotado", true);
        GenerateSoul();
    }
    void Update()
    {
        PlayerPrefs.GetInt("Souls", soul);
    }
}
