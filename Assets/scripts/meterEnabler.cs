using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class meterEnabler : MonoBehaviour
{
    public GameObject meter;
    public TMP_Text meterText;
    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        meter.SetActive(false);
    }

    public void enabler()
    {
        if (meter.activeInHierarchy == true)
        {
            meter.SetActive(false);
            meterText.text = "Meter Disabled";
        }
        else 
        {
            foreach (Transform child in meter.transform)
            {
                if (child.name == "Start_measure")
                {
                    child.gameObject.transform.localPosition = new Vector3(-0.1f, 0, 0);
                }
                else
                {
                    child.gameObject.transform.localPosition = new Vector3(0.1f, 0, 0);
                }
            }
            Vector3 positionInFront = cameraTransform.position + cameraTransform.forward * 0.5f;
            meter.transform.position = positionInFront;
            meter.transform.LookAt(cameraTransform);
            meter.SetActive(true);
        }
    }
}
