using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragImage : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector2 mousePosition;
    private Vector2 startPositon;
    private Vector2 diffrance;
    public bool dragable = true;
    private Collider2D[]hitColliders;
    private Collider2D hitCollider;
    private int index = 0;
    RectTransform rect;
    [SerializeField] RectTransform backGround;
    public bool selectableObject = true;

    public DragAndDropVisualMode dragAndDropVisualMode => throw new System.NotImplementedException();
    void Start()
    {
        rect = transform.GetComponent<RectTransform>();
        hitColliders = new Collider2D[4];
    }

    private void Update()
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
        if (dragable)
        {
            

            if (selectableObject)
            {
                transform.position = mousePosition - diffrance;
                hitCollider = Physics2D.OverlapBox(new Vector2(Input.mousePosition.x, Input.mousePosition.y), new Vector2(200, 200), 90f);
                Debug.DrawLine(transform.position, transform.position * 1.5f);

                if (hitCollider != null && !hitColliders.Contains(hitCollider) && hitCollider.gameObject.GetComponent<SelectedCreatureArea>())
                {
                    hitColliders[index] = hitCollider;
                    index++;

                }

                Debug.Log(hitCollider != null ? hitCollider.name : "nothing"); ;
                if (hitCollider)
                {
                    hitCollider.GetComponent<SelectedCreatureArea>().didColideWithVreature(true);

                    for (int i = 0; i < index; i++)
                    {
                        if (hitCollider.GetInstanceID() != hitColliders[i].GetInstanceID()) hitColliders[i].GetComponent<SelectedCreatureArea>().didColideWithVreature(false);
                    }
                }
            }
            else
            {

                transform.position = mousePosition - diffrance;
                if (backGround != null)
                {
                    Debug.Log("background");
                    float width = backGround.rect.width, height = backGround.rect.height;
                    if (rect.localPosition.y > height) rect.localPosition = new Vector3(rect.localPosition.x, height, 0);

                    if (rect.localPosition.y < -height) rect.localPosition = new Vector3(rect.localPosition.x, -height, 0);


                    if (rect.localPosition.x < -width) rect.localPosition = new Vector3(-width, rect.localPosition.y, 0);
                    if (rect.localPosition.x > width) rect.localPosition = new Vector3(width, rect.localPosition.y, 0);

                }
            }

        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (selectableObject)
        {

            if (hitCollider)
            {
                hitCollider.GetComponent<SelectedCreatureArea>().areaSelected(gameObject);
            }

            if (transform.parent.GetComponent<GridLayoutGroup>())
            {
                Transform t = transform.parent;
                t.GetComponent<GridLayoutGroup>().enabled = false;
                t.GetComponent<GridLayoutGroup>().enabled = true;

                
            }
            
            for(int i = 0; i < index; i++)
            {
                hitColliders[i].GetComponent<SelectedCreatureArea>().didColideWithVreature(false);
            }

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
}
