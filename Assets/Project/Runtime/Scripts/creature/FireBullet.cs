using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private Stats creature_stats;
    public float manacoast = 10;
    public float Hmanacoast = 10;

    [SerializeField] private Transform castPoint;
    public Transform rotationofspell;
    public Spell[] AllSpells;
    public Spell[] PlayerSpells;

    // Start is called before the first frame update
    void Start()
    {
        creature_stats = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown("5") && creature_stats.creatureStats[3].Stat >= manacoast)
        {

            UsedSpell(PlayerSpells[0]);
           
            stat stat = new stat();
            stat = creature_stats.creatureStats[3];
            stat.Stat -= manacoast;
            creature_stats.creatureStats[3] = stat;
            creature_stats.setUI();

        }

        if (Input.GetKeyDown("4") && creature_stats.creatureStats[3].Stat >= Hmanacoast)
        {

            UsedSpell(PlayerSpells[1]);
           
            stat stat = new stat();
            stat = creature_stats.creatureStats[3];
            stat.Stat -= Hmanacoast;
            creature_stats.creatureStats[3] = stat;


            creature_stats.setUI();

        }
        
    }

    void UsedSpell(Spell spellToUse)
    {

        Spell spell = Instantiate(spellToUse, rotationofspell.transform.position, rotationofspell.rotation);
        spell.gameObject.GetComponent<Spell>().SendInfo(creature_stats, creature_stats.creatureStats[6].Stat);
    }

    public void TakeDamage(float Damage)
    {

        stat stat2 = new stat();
        stat2 = creature_stats.creatureStats[0];
        stat2.Stat -= Damage;
        creature_stats.creatureStats[0] = stat2;
        if (stat2.Stat <= 0)
        {
            character_controler.Instance.isFoucsed = true;
            Destroy(this.gameObject);
        }
    }
}
