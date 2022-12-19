using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class boots : BaseItem 
{

    public float speed;
    int index = -1;

    public override void AssignItem(GameObject character, List<GameObject> parts)
    {
        Debug.Log("boots");
    }

    


    public override void Buy(GameObject character, List<GameObject> parts)
    {
        Instantiate(gameObject, character.transform);
    }

    private void Update()
    {
        
    }

}
