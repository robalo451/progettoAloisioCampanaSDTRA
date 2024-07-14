using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixModelOrientation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Inverte la scala sull'asse Z
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}