using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class switchingManager : MonoBehaviour
{

    public static switchingManager Instance;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    GameObject femaleperfab;
    [SerializeField]
    GameObject maleprefab;
    [SerializeField]
    GameObject Gamemenu;
    //GameObject playercam;
    int index = -1;
    public  List<GameObject> creatures = new List<GameObject>();
    private EnviromentSceneInput inputActions;
    private InputAction swapBetweenCreatures;
    private InputAction foucasPlayer;

    private void Awake()
    {
        inputActions = new EnviromentSceneInput();
        swapBetweenCreatures = inputActions.GeneralInputs.SwapBetweenCreatures;
        swapBetweenCreatures.performed += SwapBetweenCreature;
        swapBetweenCreatures.Enable();
        foucasPlayer = inputActions.GeneralInputs.FoucsPlayer;
        foucasPlayer.performed += FoucsPlayer;
        foucasPlayer.Enable();


    }

  

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(this);
        }

        float musicvolume = PlayerPrefs.HasKey("musicVolume") == true ? PlayerPrefs.GetFloat("musicVolume") : -1f;
        Camera.main.GetComponent<AudioSource>().volume = musicvolume!=-1?musicvolume:1;

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

    private void FoucsPlayer(InputAction.CallbackContext obj)
    {

        foreach (GameObject creature in creatures)
        {
            creature.gameObject.SetActive(false);
        }


        player.GetComponent<character_controler>().isFoucsed = true;

    }

    private void SwapBetweenCreature(InputAction.CallbackContext obj)
    {
        player.GetComponent<character_controler>().isFoucsed = false;


        index += 1;
        index = index == creatures.Count ? 0 : index;
        creatures[index].SetActive(true);
        for (int i = 0; i < creatures.Count; i++)
        {
            if (i == (index))
            {
                continue;
            }
            creatures[i].SetActive(false);

            creatures[index].GetComponent<Stats>().setUI();
        }
    }

    public void Addcreature(GameObject creature)
    {
        creatures.Add(creature);

        Gamemenu.GetComponent<SWIP_creatures>().Addcreature(creature);
        
    }

   
}
