using UnityEngine;
using UnityEditor;
using System.Collections;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

public class ReplaceGameObjects : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject prefabObject;
    public GameObject objectToBeReplaced;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        Transform[] Replaces;
        Replaces = objectToBeReplaced.GetComponentsInChildren<Transform>();

        foreach (Transform t in Replaces)
        {
            GameObject newObject = PrefabUtility.InstantiatePrefab(prefabObject) as GameObject;
            newObject.transform.position = t.position;
            newObject.transform.rotation = t.rotation;

            Destroy(t.gameObject);
        }
    }
}