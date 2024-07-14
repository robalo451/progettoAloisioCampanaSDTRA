using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class brainEnabler : MonoBehaviour
{
    public GameObject brain;
    public GameObject imm;
    public void enabler()
    {
        if (brain.activeInHierarchy == true)
        {
            brain.SetActive(false);
            imm.GetComponent<FontIconSelector>().CurrentIconName = "Icon 9";
        }
        else
        {
            brain.SetActive(true);
            imm.GetComponent<FontIconSelector>().CurrentIconName = "Icon 10";
        }
    }
}
