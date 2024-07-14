using Dummiesman;
using MixedReality.Toolkit.SpatialManipulation;
using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSetComponent : MonoBehaviour
{
    public GameObject tumor;
    public GameObject brain;
    public GameObject region;
    public GameObject boundingBox;
    public GameObject buttonBrain;
    public GameObject composition;

    // Start is called before the first frame update
    void Start()
    {
        composition.AddComponent<FixModelOrientation>();
        brain.SetActive(false);
        region.SetActive(false);
        tumor.AddComponent<BoxCollider>();
        tumor.AddComponent<MinMaxScaleConstraint>();
        tumor.AddComponent<ObjectManipulator>().selectMode = UnityEngine.XR.Interaction.Toolkit.InteractableSelectMode.Multiple;
        tumor.AddComponent<UGUIInputAdapterDraggable>();
        BoundsControl boundsControl = tumor.AddComponent<BoundsControl>();
        boundsControl.BoundsVisualsPrefab = boundingBox;
        buttonBrain.GetComponent<brainEnabler>().brain = brain;

        GameObject.Find("BoundingBoxWithHandles(Clone)").AddComponent<FixModelOrientation>();

        tumor.transform.localPosition = new Vector3(-0.29f, 1.03f, 1.21f);
    }
}