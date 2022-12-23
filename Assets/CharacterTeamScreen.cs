using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterTeamScreen : MonoBehaviour
{
    [SerializeField] GameObject creatureList, Team, creatureIconPrefab, player;
    private List<GameObject> IconsList = new List<GameObject>();
    private GameObject [] SelectedTeam = new GameObject[4];
    public int creaturesCount = 0;
    public int selected = 0;
    void Awake()
    {
        creatuers_spawn.creatureSpawned += AddCreatureToList;
    }

    private void AddCreatureToList(Stats obj)
    {
        GameObject prefab = Instantiate(creatureIconPrefab, creatureList.transform);
        prefab.GetComponent<Image>().sprite = obj.creature.Icon;
        prefab.GetComponent<CreatureIconIdentity>().parent = gameObject;
        prefab.GetComponent<CreatureIconIdentity>().index = creaturesCount;
        prefab.GetComponent<DragImage>().selectableObject = true;
        prefab.GetComponent<DragImage>().dragable = true;
        prefab.transform.GetChild(0).GetComponent<TMP_Text>().text = obj.creature.level.ToString();
        IconsList.Add(prefab);
        creaturesCount++;

    }

    public void setScreenActvity(bool flag)
    {
        foreach (Transform f in gameObject.transform)
            f.gameObject.SetActive(flag);
    }


    public void Onclick(int i)
    {

    }

    public void selectedAcreature(GameObject creature,int index)
    {

       int i =  creature.GetComponent<CreatureIconIdentity>().index;
       SelectedTeam[index] = IconsList[i];
    }


    public void GetPLayerGameObject(GameObject player)
    {
        this.player = player;
    }


}
