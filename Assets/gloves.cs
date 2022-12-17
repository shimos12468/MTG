using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gloves : BaseItem
{
    public override void AssignItem(GameObject character, List<GameObject> parts)
    {
        GameObject o = Instantiate(gameObject, character.transform);
        o.transform.position = Vector3.zero;
        o.SetActive(false);
    }

    public override void Buy(GameObject character, List<GameObject> parts)
    {
        GameObject o = Instantiate(gameObject, character.transform);
        o.transform.position = Vector3.zero;
        o.SetActive(false);
    }
}