    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using static utilities;
public class runes_displaystats : MonoBehaviour
{
    public TMP_Text health;
    public TMP_Text mana;
    public TMP_Text damage;
    public TMP_Text defence;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayStats(List<stat> q)
    {

        for(int i = 0; i < q.Count; i++)
        {
            transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = q[i].Stat.ToString();
            transform.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = q[i].name.ToString();
        }

    }
}
