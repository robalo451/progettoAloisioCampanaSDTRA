using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class viewEnabler : MonoBehaviour
{
    public GameObject view;
    public GameObject window;
    public Transform cameraTransform;
    Vector3 positionUnderPlane = new Vector3(0, -3, 0);

    private void Start()
    {
        window.transform.localPosition = positionUnderPlane;
    }
    public void enabler()
    {
        if (view.activeInHierarchy == true)
        {
            view.SetActive(false);
            GameObject parent = view.transform.parent.gameObject;
            bool activeChild = false;
            foreach (Transform child in parent.transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    activeChild = true;
                }
            }
            if (!activeChild)
            {
                parent.SetActive(false);
            }
            window.transform.localPosition = positionUnderPlane;
        }
        else
        {
            GameObject parent = view.transform.parent.gameObject;
            if (!parent.activeInHierarchy)
            {
                parent.SetActive(true);
                foreach (Transform child in parent.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            view.SetActive(true);
            Vector3 positionInFront = cameraTransform.position + cameraTransform.forward * 0.5f;
            window.transform.position = positionInFront;
            window.transform.LookAt(cameraTransform);
        }
    }
}
