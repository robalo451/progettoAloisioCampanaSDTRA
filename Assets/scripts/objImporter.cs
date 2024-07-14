using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Dummiesman;
using UnityEngine.UI;
using MixedReality.Toolkit.SpatialManipulation;
using UnityEditor;
using MixedReality.Toolkit.UX;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using MixedReality.Toolkit;

public class objImporter : MonoBehaviour
{
    public GameObject itself;
    public GameObject emptyObject;
    string tumorPath;
    string brainPath;
    string regionPath;
    public Material tumorMaterial;
    public Material brainMaterial;
    public Material regionMaterial;
    GameObject objToDestroy;
    public GameObject planeS;
    public GameObject planeC;
    public GameObject planeA;

    Vector3 scale = new Vector3(0.005f, 0.005f, 0.005f);

    // Start is called before the first frame update
    void Start()
    {
        tumorPath = PlayerPrefs.GetString("Percorso") + "\\lesione.obj";
        brainPath = PlayerPrefs.GetString("Percorso") + "\\cervello.obj";
        regionPath = PlayerPrefs.GetString("Percorso") + "\\regione.obj";

        LoadOBJ(tumorPath);
        LoadOBJ(brainPath);
        LoadOBJ(regionPath);

        GameObject t = GameObject.Find("tumor");
        GameObject b = GameObject.Find("brain");
        GameObject r = GameObject.Find("region"); 

        t.transform.parent = emptyObject.transform;
        b.transform.parent = t.transform;
        r.transform.parent = t.transform;
        planeS.transform.parent = r.transform;
        planeC.transform.parent = r.transform;
        planeA.transform.parent = r.transform;

        objToDestroy = GameObject.Find("lesione");
        Destroy(objToDestroy);
        objToDestroy = GameObject.Find("cervello");
        Destroy(objToDestroy);
        objToDestroy = GameObject.Find("regione");
        Destroy(objToDestroy);

        objSetComponent set = itself.GetComponent<objSetComponent>();
        set.tumor = t;
        set.brain = b;
        set.region = r;
    }
    void LoadOBJ(string path)
    {
        Material material;
        if (path == tumorPath)
        {
            material = tumorMaterial;
        }
        else if (path == brainPath) 
        {
            material = brainMaterial;
        }
        else
        {
            material = regionMaterial;
        }

        GameObject objModel = new OBJLoader().Load(path);

        Renderer[] renderers = objModel.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.transform.localPosition = Vector3.zero;
            renderer.transform.localScale = scale;
            renderer.material = material;
        }
        objModel.transform.localScale = Vector3.one;
        objModel.transform.position = Vector3.zero;
    }

}