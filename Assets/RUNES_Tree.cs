using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class RUNES_Tree : MonoBehaviour
{


    public GameObject runesUI;
    public int points; 
    public class runee : MonoBehaviour
    {
        public string Name { get; set; }
        public int level;
        public float stat;

        public runee(string name, int level, float stat)
        {
            Name = name;
            this.level = level;
            this.stat = stat;
        }




        public runee()
        {
        }
    }

    public List<runee> tree = new List<runee>();


    // Start is called before the first frame update
    void Start()
    {
        runee rune8 = new runee("Damage" ,0,0.0f);
       
        runee rune1 = new runee("Mana", 0, 0.0f);
        runee rune2 = new runee("Health", 0, 0.0f);
        runee rune3 = new runee("Crit", 0, 0.0f);
        runee rune4 = new runee("Regen", 0, 0.0f);
        runee rune5 = new runee("Speed", 0, 0.0f);
        runee rune6 = new runee("Defense", 0, 0.0f);
        runee rune7 = new runee("Stamina", 0, 0.0f);

        tree.Add(rune1);
        tree.Add(rune2);
        tree.Add(rune3);
        tree.Add(rune4);
        tree.Add(rune5);
        tree.Add(rune6);
        tree.Add(rune7);
        tree.Add(rune8);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tree[0].level);

    }

    public void addRune(runee obj)
    {

    }

    public void sendRunes()
    {
        

    }
}
