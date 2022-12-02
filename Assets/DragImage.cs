using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragImage : MonoBehaviour ,IDragHandler
{


    private Vector2 mousePosition;
    private Vector2 startPositon;
    private Vector2 diffrance;
    RectTransform rect;
[SerializeField]RectTransform backGround;
    // Start is called before the first frame update
    void Start()
    {
       rect = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) GetMousePosiotion();
        if (Input.GetMouseButtonDown(0))
        {
            updateStartPosiotion();
            CalculateDiffrance();
            
        }

       

      
      
        
    }

   
    void updateStartPosiotion()
    {
        startPositon.x = transform.position.x;
        startPositon.y = transform.position.y;

    }

    void CalculateDiffrance()
    {
        diffrance = mousePosition - startPositon;
    }

    void GetMousePosiotion()
    {
        mousePosition.y = Input.mousePosition.y;
        mousePosition.x = Input.mousePosition.x;
    }

    public void OnDrag(PointerEventData eventData)
    {

        float width = backGround.rect.width ,height = backGround.rect.height;



        transform.position = mousePosition - diffrance;

        if (rect.localPosition.y > height) rect.localPosition = new Vector3(rect.localPosition.x, height, 0);

        if (rect.localPosition.y < -height) rect.localPosition = new Vector3(rect.localPosition.x, -height, 0);


        if (rect.localPosition.x < -width) rect.localPosition = new Vector3(-width, rect.localPosition.y, 0);
        if (rect.localPosition.x > width) rect.localPosition = new Vector3(width, rect.localPosition.y, 0);




    }
}
