using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCreatureArea : MonoBehaviour
{
    GameObject selectedCreature;
    [SerializeField] int index = 0;
    public CharacterTeamScreen CharacterTeamScreen;


    

    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();  
    }
    public void didColideWithVreature(bool flag)
    {
        transform.GetChild(0).gameObject.SetActive(!flag);
        transform.GetChild(1).gameObject.SetActive(flag);
        transform.GetChild(2).gameObject.SetActive(flag);
    }

   
    public void areaSelected(GameObject creature)
    {

        if (selectedCreature != null)
        {

            selectedCreature.GetComponent<DragImage>().dragable = true;
            selectedCreature.transform.GetChild(1).gameObject.SetActive(false);
            selectedCreature = creature;
            transform.GetComponent<Image>().sprite = selectedCreature.GetComponent<Image>().sprite;
            selectedCreature.GetComponent<DragImage>().dragable = false;
            selectedCreature.transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);

        }
        else
        {
            selectedCreature= creature;
            transform.GetComponent<Image>().sprite = selectedCreature.GetComponent<Image>().sprite;
            selectedCreature.GetComponent<DragImage>().dragable = false;
            selectedCreature.transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        CharacterTeamScreen.selectedAcreature(selectedCreature, index);

       
    }
}
