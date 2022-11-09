using UnityEngine;
using UnityEngine.UI;

public class RobotPartPicker : MonoBehaviour
{
    public GameObject robotPrefab;
    public Text headText;
    public Text chestText;
    public Text armsText;
    public Text hipsText;
    public Text legsText;
    Transform headHolder;
    Transform chestsHolder;
    Transform armsHolder;
    Transform hipsHolder;
    Transform legsHolder;

    int currentHead = 0;
    int currentChest = 0;
    int currentArm = 0;
    int currentHips = 0;
    int currentLegs = 0;

    void Start()
    {
        headHolder = robotPrefab.transform.Find("Heads");
        chestsHolder = robotPrefab.transform.Find("Chests");
        armsHolder = robotPrefab.transform.Find("Arms");
        hipsHolder = robotPrefab.transform.Find("Hips");
        legsHolder = robotPrefab.transform.Find("Legs");

        for(int i = 1; i < headHolder.childCount; i++){
            headHolder.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 1; i < chestsHolder.childCount; i++){
            chestsHolder.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 1; i < armsHolder.childCount; i++){
            armsHolder.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 1; i < hipsHolder.childCount; i++){
            hipsHolder.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 1; i < legsHolder.childCount; i++){
            legsHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void NextHead()
    {
        headHolder.GetChild(currentHead).gameObject.SetActive(false);
        if(headHolder.childCount > currentHead + 1){
            currentHead ++;
        }
        else{
            currentHead = 0;
        }
        headText.text = "Head " + (currentHead + 1); 
        headHolder.GetChild(currentHead).gameObject.SetActive(true);
    }

    public void NextChest()
    {
        chestsHolder.GetChild(currentChest).gameObject.SetActive(false);
        if(chestsHolder.childCount > currentChest + 1){
            currentChest ++;
        }
        else{
            currentChest = 0;
        }
        chestText.text = "Chest " + (currentChest + 1); 
        chestsHolder.GetChild(currentChest).gameObject.SetActive(true);
    }

    public void NextArms()
    {
        armsHolder.GetChild(currentArm).gameObject.SetActive(false);
        if(armsHolder.childCount > currentArm + 1){
            currentArm ++;
        }
        else{
            currentArm = 0;
        }
        chestText.text = "Arm " + (currentArm + 1); 
        armsHolder.GetChild(currentArm).gameObject.SetActive(true);
    }

    public void NextHips()
    {
        hipsHolder.GetChild(currentHips).gameObject.SetActive(false);
        if(hipsHolder.childCount > currentHips + 1){
            currentHips ++;
        }
        else{
            currentHips = 0;
        }
        hipsText.text = "Hips " + (currentHips + 1); 
        hipsHolder.GetChild(currentHips).gameObject.SetActive(true);
    }

    public void NextLegs()
    {
        legsHolder.GetChild(currentLegs).gameObject.SetActive(false);
        if(legsHolder.childCount > currentLegs + 1){
            currentLegs ++;
        }
        else{
            currentLegs = 0;
        }
        legsText.text = "Legs " + (currentLegs + 1); 
        legsHolder.GetChild(currentLegs).gameObject.SetActive(true);
    }
}
