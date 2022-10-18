using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class RUNES_Tree : MonoBehaviour
{


    public GameObject runesUI;
    public int points;
    
    [System.Serializable]
    public struct runes
    {
        public string name;
        public int level;
        public float stat;
        

    }
    public List<runes> runesTree = new List<runes>();

    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addRune(Rune rune)
    {

    }

    public void sendRunes()
    {
        

    }

    public void updateScript(runes rune)
    {
       for(int i = 0; i < runesTree.Count; i++)
        {
            if (runesTree[i].name == rune.name)
            {
                runesTree[i] = rune;
                Debug.Log("hello");
            }

        }
    }
}
