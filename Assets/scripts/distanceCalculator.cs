using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class distanceCalculator : MonoBehaviour
{
    LineRenderer line;
    public Transform origin;
    public Transform destin;
    public float distance;
    public GameObject distText_GO;
    TMP_Text distText;

    GameObject tumor_volume;

    // Start is called before the first frame update
    void Start()
    {
        tumor_volume = GameObject.Find("tumor");
        line = gameObject.GetComponent<LineRenderer>();
        line.startWidth = 0.001f;
        line.endWidth = 0.001f;
        distText = distText_GO.GetComponent<TMP_Text>();
    }

    public float scale;

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Sqrt(Mathf.Pow(origin.position.x - destin.position.x, 2) + Mathf.Pow(origin.position.y - destin.position.y, 2) + Mathf.Pow(origin.position.z - destin.position.z, 2));
        scale = tumor_volume.transform.lossyScale.y;
        distance = distance/scale;
        line.SetPosition(0, origin.position);
        line.SetPosition(1, destin.position);
        distText.text = "Length: " + String.Format("{0:0.##}", distance)  + " mm";
    }
}
