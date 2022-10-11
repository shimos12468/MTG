using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof  (PERSONAJESTATS))]

public class personajestatseditor : Editor
{
    public PERSONAJESTATS statstarget => target as PERSONAJESTATS;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Resetear"))
        {
            statstarget.ResetearValores();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
