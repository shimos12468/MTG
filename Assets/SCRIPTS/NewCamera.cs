using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static Quaternion RotateTowards(this Quaternion current,Quaternion target ,float maxAngle)
    {
        Vector3 currentEuler = current.eulerAngles;
        Vector3 targetEuler = target.eulerAngles;
        float totalAngle = Vector3.Angle(currentEuler, targetEuler);
        Quaternion output = new Quaternion();
        output.eulerAngles = Vector3.Lerp(currentEuler, targetEuler, Mathf.Clamp(maxAngle / totalAngle, 0, 1));
        return output;
    }

    public static void NudgeTransform(this Transform current,Transform target,float maxAngle,float maxDistance)
    {
        current.rotation = current.rotation.RotateTowards(target.rotation, maxAngle);
        current.position = Vector3.MoveTowards(current.position, target.position, maxDistance);
    }
}







public class NewCamera : MonoBehaviour
{
    public Transform camerapivot;
 
    public float moveSpeed;
    public float turnSpeed;
    private static NewCamera instance;
    public static NewCamera SharedInstance() => instance;

    void Awake()
    {
        instance = this;
    }





   void Update()
    {
        transform.NudgeTransform(camerapivot, turnSpeed * Time.smoothDeltaTime, moveSpeed * Time.smoothDeltaTime);
    }
}
