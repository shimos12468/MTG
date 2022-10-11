using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void evolve_creature(GameObject parant ,GameObject newcreature,int level , float health , float Expactual, float Exprequerida , float Magic , int baseHealth , float Damage)
    {
        Debug.Log("evolving");
        Vector3 position = parant.transform.position;
        GameObject creature= Instantiate(newcreature);
        Destroy(parant);
        creature.GetComponent<queenflora>().level = level;
        creature.GetComponent<queenflora>().baselavel = level;
        creature.GetComponent<queenflora>().evolutionlevel = level+2;
        creature.GetComponent<queenflora>().Health = health;
        creature.GetComponent<queenflora>().Expactual = Expactual;
        creature.GetComponent<queenflora>().Exprequerida = Exprequerida;
        creature.GetComponent<queenflora>().Magic = Magic;
        creature.GetComponent<queenflora>().baseHealth = baseHealth;
        creature.GetComponent<queenflora>().Damage = Damage;
        creature.transform.parent = null;
        creature.transform.position = position;
        creature.GetComponent<queenflora>().setUI();




    }
}
