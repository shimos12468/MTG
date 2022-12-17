using System.Collections.Generic;
using UnityEngine;
using static utilities;


public interface IBought
{
    public void AssignItem(GameObject character ,List<GameObject> parts);
}



[System.Serializable]
public class BaseItem  : MonoBehaviour 
{
    public int indexe = -1;
    public string name;
    public Effect effect;
    public string discription;
    public int price;
    public Sprite Icon;
    public bool owned = false;
    public bool assigned = false;
    public bool enabled = false;

    private void Update()
    {
        
    }
    public virtual void MoveToPlayer( Transform character)
    {
       
    }

    public virtual void AddProprities(BaseItem item)
    {

    }
    public virtual void AssignItem(GameObject character, List<GameObject> parts)
    {
        Debug.Log("nothing");
    }
    public virtual void Buy(GameObject character, List<GameObject> parts)
    {
        Debug.Log("nothing");
    }

}
