using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchingManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject femaleperfab;
    [SerializeField]
    GameObject maleprefab;
    [SerializeField]
    GameObject Gamemenu;
    //GameObject playercam;
    int index = -1;
    public  List<GameObject> creatures = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("Type")==1)
        {
            player = Instantiate(femaleperfab);
            player.GetComponent<creatuers_spawn>().switchingManager = this.gameObject;
        }

        if (PlayerPrefs.GetInt("Type") == 0)
        {
            player = Instantiate(maleprefab);
            player.GetComponent<creatuers_spawn>().switchingManager = this.gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.GetComponent<character_controler>().isFoucsed = false;
            index += 1;
            creatures[index%creatures.Count].SetActive(true);
            for(int i = 0; i < creatures.Count; i++)
            {
                if (i == (index%creatures.Count))
                {
                    continue;
                }
                creatures[i].SetActive(false);

                //creatures[index % creatures.Count].GetComponent<queenflora>().setUI();
            }
           


        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //playercam.gameObject.SetActive(true);
            foreach (GameObject obj in creatures)
            {
                obj.gameObject.SetActive(false);
            }

           
            player.GetComponent<character_controler>().isFoucsed = true;
        }
        
    }

    public void Addcreature(GameObject creature)
    {
        creatures.Add(creature);

        Gamemenu.GetComponent<SWIP_creatures>().Addcreature(creature);
        
    }
}
