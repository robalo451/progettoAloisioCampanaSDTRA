using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitVR : MonoBehaviour
{
    public void endVisual()
    {
        SceneManager.LoadScene("menu");
    }
}
