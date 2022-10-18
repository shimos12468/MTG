using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    [SerializeField] private Transform castPoint;
    public Spell[] AllSpells;
    public Spell[] PlayerSpells;
    public float fullMagic;
    public float Damage;
    public Transform rotationofspell;
    public float Manacoast = 1;
    public float HealthManacoast = 20;


    // Start is called before the first frame update
    //void Start()
    //{
    //    fullMagic = transform.gameObject.GetComponent<queenflora>().Magic;
       
    //    Damage = transform.gameObject.GetComponent<queenflora>().Damage;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown("5")&&fullMagic>=Manacoast)
    //    {
           
    //        UsedSpell(PlayerSpells[0]);

    //        transform.gameObject.GetComponent<queenflora>().Magic -= Manacoast;
    //        fullMagic -= Manacoast;
    //        Debug.Log("wfefwefw");
    //        //transform.gameObject.GetComponent<queenflora>().setUI();
           
    //    }
    //    if (Input.GetKeyDown("4") && fullMagic >= HealthManacoast)
    //    {

    //        UsedSpell(PlayerSpells[1]);

    //        transform.gameObject.GetComponent<queenflora>().Magic -= HealthManacoast;
    //        fullMagic -= HealthManacoast;
    //        transform.gameObject.GetComponent<queenflora>().setUI();

    //    }
    //}

    //void UsedSpell(Spell spellToUse)
    //{
    //    int id = spellToUse.id;


    //    Spell spell =Instantiate(spellToUse, rotationofspell.transform.position, rotationofspell.rotation);
    //    spell.gameObject.GetComponent<Spell>().setparent(gameObject);
    //    spell.gameObject.GetComponent<Spell>().damage = Damage;
    //}
}
