using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SWIP_creatures : MonoBehaviour
{
    public List<GameObject> deactivate = new List<GameObject>();
    public GameObject menu;
    public bool state = false;

   public  GameObject runes_obj;
   public GameObject items_obj;

    public List<GameObject> creatures = new List<GameObject>();
    public Image img;
    public List<Sprite> creaturesIMG = new List<Sprite>();
    public GameObject characterOptions;
    public GameObject creatureOptions;
    public GameObject objectContaincreatures;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        //Debug.Log(gamemenu.instance.dd);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

           
            foreach (GameObject obj in deactivate)
            {
                obj.SetActive(state);
            }

            menu.SetActive(!state);
            state = !state;
        }


        if (creatures.Count > 0)
        {


            if (creaturesIMG[index % creaturesIMG.Count].name.Contains("creature"))
            {
                characterOptions.SetActive(false);
                creatureOptions.SetActive(true);
            }
            else
            {
                characterOptions.SetActive(true);
                creatureOptions.SetActive(false);
            }
        }
    }


    
    public void swipe_right()
    {

        if (creatures.Count > 0)
        { 
            index++;
            img.sprite = creaturesIMG[index % creaturesIMG.Count];
        }
    }

    public void swipe_left()
    {

        if (creatures.Count > 0)
        {
            index--;
            if (index < 0)
                index = creaturesIMG.Count - 1;
            img.sprite = creaturesIMG[index % creaturesIMG.Count];
        }
    }
    public void Addcreature(GameObject creature)
    {
        creatures.Add(creature);

        creaturesIMG.Add(creature.GetComponent<queenflora>().heroIcon);
    }

    public void getcreatureStats()
    {
       GameObject creature =  creatures[index % creatures.Count];
        queenflora q =  creature.gameObject.GetComponent<queenflora>();
        Debug.Log(q.name);
        Debug.Log(q.Damage);

    }

    public void sendcreature(bool r)
    {
        if(r)
        runes_obj.GetComponent<CreatureStatsManager>().getcreatureforrunes(creatures[index%creatures.Count]);
        else
            items_obj.GetComponent<CreatureStatsManager>().getcreatureforitems(creatures[index % creatures.Count]);
    }
}
