using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class creatuers_spawn : MonoBehaviour
{
   
    public static creatuers_spawn instance;
    public List <GameObject>creatures = new List<GameObject>();
    public List<GameObject> storedCreature = new List<GameObject>();
    public List<GameObject> spawnedCreatures = new List<GameObject>();


    [SerializeField]
    Transform spawner;
   
    public int index ,creatureIndex =-1;
    public TMP_Text text;


    private EnviromentSceneInput inputActions;
    private InputAction swapBetweenCreatures;
    private InputAction foucasPlayer;



    
    public List<GameObject> GetSpawnedCreatures()
    {

        return spawnedCreatures;
    }

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
    private void Start()
    {
       
        if (instance == null) instance = this;
        else Destroy(this);


        GameObject right = GameObject.FindGameObjectWithTag("swipeRight");
        GameObject left = GameObject.FindGameObjectWithTag("swipeLeft");
        GameObject Text = GameObject.FindGameObjectWithTag("CreatureName");
        text = Text.GetComponent<TMP_Text>();
        right.GetComponent<Button>().onClick.AddListener(() => swipe_right());
        left.GetComponent<Button>().onClick.AddListener(() => swipe_left());

        text.text = storedCreature[index].GetComponent<Stats>().creature.name;
    }



    private void FoucsPlayer(InputAction.CallbackContext obj)
    {

        foreach (GameObject creature in spawnedCreatures)
        {
            creature.gameObject.SetActive(false);
        }


        transform.GetComponent<character_controler>().isFoucsed = true;

    }

    private void SwapBetweenCreature(InputAction.CallbackContext obj)
    {
        if (spawnedCreatures.Count < 1) return;

        transform.GetComponent<character_controler>().isFoucsed = false;
        creatureIndex += 1;
        creatureIndex = creatureIndex == spawnedCreatures.Count ? 0 : creatureIndex;
        spawnedCreatures[creatureIndex].SetActive(true);
        for (int i = 0; i < spawnedCreatures.Count; i++)
        {
            if (i == (creatureIndex))
            {
                continue;
            }
            spawnedCreatures[i].SetActive(false);

            spawnedCreatures[creatureIndex].GetComponent<Stats>().setUI();
        }
    }

    public void spawncreature()
    {
        GameObject creature = Instantiate(storedCreature[index], spawner);
        creature.transform.parent = null;
        creature.gameObject.transform.position = spawner.transform.position;
        gameObject.GetComponent<character_controler>().isFoucsed = false;

        storedCreature.RemoveAt(index);
        if (storedCreature.Count == 0)
        {
            Debug.Log("no stored creatures");
        }
        index = index>=storedCreature.Count ? storedCreature.Count-1 : index; 
        spawnedCreatures.Add(creature);
        
        if(index<storedCreature.Count&&storedCreature.Count!=0)
        text.text = storedCreature[index].GetComponent<Stats>().creature.name;
        if (index == -1) text.text = "EMPTY";
    }


    



    public void swipe_right()
    {
        int m = index + 1;
        if (m < storedCreature.Count)
        {
            index++;
            Debug.Log(storedCreature[index].name);
            text.text = storedCreature[index].GetComponent<Stats>().creature.name;
        }
    }

    public void swipe_left()
    {
        int m = index - 1;
        if (m >= 0)
        {
            index--;
            text.text = storedCreature[index].GetComponent<Stats>().creature.name;
        }
    }


    public void AddPrefab(GameObject CreaturePrefab)
    {
        Debug.Log("Added");
        creatures.Add(CreaturePrefab);
        storedCreature.Add(CreaturePrefab);


    }
}
