using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;


public class SaveWorld : MonoBehaviour
{

    string savePath = "Assets/Saved Worlds/MyWorld.prefab";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            string uniquePath = AssetDatabase.GenerateUniqueAssetPath(savePath);
            PrefabUtility.SaveAsPrefabAsset(GameObject.Find("World"), uniquePath);
        }
    }
}