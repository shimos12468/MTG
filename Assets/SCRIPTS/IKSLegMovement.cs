using System.Collections;
using UnityEngine;

public class IKSLegMovement : MonoBehaviour
{
    public LayerMask groundMask;
    public GameObject legsMesh;
    //Snap-timing/smoothness
    public float smoothness = 1;
    //Height of each step
    public float stepHeight = 0.1f;

    //Seperate positions that control the current position of the legs
    public Transform sLeg_01_pos;
    public Transform sLeg_02_pos;
    public Transform sLeg_03_pos;
    public Transform sLeg_04_pos;

    //Offset for each leg
    public Vector3 offset_1;
    public Vector3 offset_2;
    public Vector3 offset_3;
    public Vector3 offset_4;

    //Positions that are relative to the player object
    public Transform sLeg_01_newPos;
    public Transform sLeg_02_newPos;
    public Transform sLeg_03_newPos;
    public Transform sLeg_04_newPos;

    float distTo1;
    float distTo2;
    float distTo3;
    float distTo4;

    bool[] groundBools;

    // Start is called before the first frame update
    void Start()
    {
        sLeg_01_pos.position += offset_1;
        sLeg_02_pos.position += offset_2;
        sLeg_03_pos.position += offset_3;
        sLeg_04_pos.position += offset_4;

        groundBools = new bool[4];
        for (int i = 0; i < groundBools.Length; i++){
            groundBools[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(legsMesh.activeSelf){
            RaycastHit hit1;
            RaycastHit hit2;
            RaycastHit hit3;
            RaycastHit hit4;
            Physics.Raycast(sLeg_01_newPos.position + Vector3.up, Vector3.down, out hit1, 3f, groundMask);
            Physics.Raycast(sLeg_02_newPos.position + Vector3.up, Vector3.down, out hit2, 3f, groundMask);
            Physics.Raycast(sLeg_03_newPos.position + Vector3.up, Vector3.down, out hit3, 3f, groundMask);
            Physics.Raycast(sLeg_04_newPos.position + Vector3.up, Vector3.down, out hit4, 3f, groundMask);

            sLeg_01_newPos.position = hit1.point;
            sLeg_02_newPos.position = hit2.point;
            sLeg_03_newPos.position = hit3.point;
            sLeg_04_newPos.position = hit4.point;

            distTo1 = Vector3.Distance(sLeg_01_newPos.position, sLeg_01_pos.position);
            distTo2 = Vector3.Distance(sLeg_02_newPos.position, sLeg_02_pos.position);
            distTo3 = Vector3.Distance(sLeg_03_newPos.position, sLeg_03_pos.position);
            distTo4 = Vector3.Distance(sLeg_04_newPos.position, sLeg_04_pos.position);

            if(distTo1 >= 0.8f && groundBools[1] && groundBools[3]){
                StartCoroutine(PerformStep(sLeg_01_pos, sLeg_01_newPos.position + offset_1, 0));
            }
            if(distTo2 >= 0.8f && groundBools[0] && groundBools[2]){
                StartCoroutine(PerformStep(sLeg_02_pos, sLeg_02_newPos.position + offset_2, 1));
            }
            if(distTo3 >= 0.8f && groundBools[1] && groundBools[3]){
                StartCoroutine(PerformStep(sLeg_03_pos, sLeg_03_newPos.position + offset_3, 2));
            }
            if(distTo4 >= 0.8f && groundBools[0] && groundBools[2]){
                StartCoroutine(PerformStep(sLeg_04_pos, sLeg_04_newPos.position + offset_4, 3));
            }
        }
    }

    
    IEnumerator PerformStep(Transform currentPos, Vector3 targetPoint, int index)
    {
        Vector3 startPos = currentPos.position;
        groundBools[index] = false;

        for(int i = 1; i <= smoothness; ++i){
            currentPos.position = Vector3.Lerp(startPos, targetPoint, i / (float)(smoothness + 1f));
            currentPos.position += transform.up * Mathf.Sin(i / (float)(smoothness + 1f) * Mathf.PI) * stepHeight;
            yield return new WaitForFixedUpdate();
        }
        groundBools[index] = true;
        currentPos.position = targetPoint;
    }

    void OnDrawGizmos()
    {
        if(legsMesh.activeSelf){
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(sLeg_01_newPos.position, 0.05f);
            Gizmos.DrawSphere(sLeg_02_newPos.position, 0.05f);
            Gizmos.DrawSphere(sLeg_03_newPos.position, 0.05f);
            Gizmos.DrawSphere(sLeg_04_newPos.position, 0.05f);

            Gizmos.DrawLine(sLeg_01_newPos.position + Vector3.up, sLeg_01_newPos.position);
            Gizmos.DrawLine(sLeg_02_newPos.position + Vector3.up, sLeg_02_newPos.position);
            Gizmos.DrawLine(sLeg_03_newPos.position + Vector3.up, sLeg_03_newPos.position);
            Gizmos.DrawLine(sLeg_04_newPos.position + Vector3.up, sLeg_04_newPos.position);

            Gizmos.DrawLine(sLeg_01_newPos.position, sLeg_01_pos.position);
            Gizmos.DrawLine(sLeg_02_newPos.position, sLeg_02_pos.position);
            Gizmos.DrawLine(sLeg_03_newPos.position, sLeg_03_pos.position);
            Gizmos.DrawLine(sLeg_04_newPos.position, sLeg_04_pos.position);
        }
    }
}
