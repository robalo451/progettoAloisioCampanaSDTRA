using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Globalization;

public class ReadCSV : MonoBehaviour
{
    public GameObject id;
    public GameObject area;
    public GameObject volume;
    string csvPath;
    public GameObject sagittal;
    public GameObject coronal;
    public GameObject axial;
    public GameObject planeS;
    public GameObject planeC;
    public GameObject planeA;

    // Start is called before the first frame update
    void Start()
    {
        csvPath = PlayerPrefs.GetString("Percorso") + "\\Features 3D.csv";

        // Leggi tutte le righe del file
        string[] lines = File.ReadAllLines(csvPath);
        for (int i = 0; i < 2; i++)
        {
            string[] fields = lines[i].Split(";");
            id.GetComponent<TMP_Text>().text = id.GetComponent<TMP_Text>().text + fields[0] + " ";
            area.GetComponent<TMP_Text>().text = area.GetComponent<TMP_Text>().text + fields[1] + " ";
            volume.GetComponent<TMP_Text>().text = volume.GetComponent<TMP_Text>().text + fields[2] + " ";
        }
        area.GetComponent<TMP_Text>().text = area.GetComponent<TMP_Text>().text + "mm<sup>2";
        volume.GetComponent<TMP_Text>().text = volume.GetComponent<TMP_Text>().text + "mm<sup>3";

        string[] viste = lines[2].Split(";");
        string[] dimensioni = lines[3].Split(";");
        string[] slices = lines[4].Split(";");

        float dimX = float.Parse(dimensioni[0], CultureInfo.InvariantCulture);
        float dimY = float.Parse(dimensioni[1], CultureInfo.InvariantCulture);
        float dimZ = float.Parse(dimensioni[2], CultureInfo.InvariantCulture);

        for (int i = 0; i < viste.Length; i++)
        {
            Vector3 regionDim = new Vector3(dimX, dimY, dimZ);
            Vector3 regionPos = new Vector3(dimX / 2, dimY / 2, dimZ / 2);
            if (viste[i] == "sagittale")
            {
                sagittal.GetComponent<ScrollImage>().numSlices = int.Parse(slices[i]);
                sagittal.GetComponent<ScrollImage>().piano = planeS;
                sagittal.GetComponent<ScrollImage>().direzione = i;
                regionDim[i] = regionDim[i] / float.Parse(slices[i]);
                planeS.transform.localScale = regionDim;
                regionPos[i] = regionDim[i] / 2;
                planeS.transform.localPosition = regionPos;
            }
            else if (viste[i] == "coronale")
            {
                coronal.GetComponent<ScrollImage>().numSlices = int.Parse(slices[i]);
                coronal.GetComponent<ScrollImage>().piano = planeC;
                coronal.GetComponent<ScrollImage>().direzione = i;
                regionDim[i] = regionDim[i] / float.Parse(slices[i]);
                planeC.transform.localScale = regionDim;
                regionPos[i] = regionDim[i] / 2;
                planeC.transform.localPosition = regionPos;
            }
            else
            {
                axial.GetComponent<ScrollImage>().numSlices = int.Parse(slices[i]);
                axial.GetComponent<ScrollImage>().piano = planeA;
                axial.GetComponent<ScrollImage>().direzione = i;
                regionDim[i] = regionDim[i] / float.Parse(slices[i]);
                planeA.transform.localScale = regionDim;
                regionPos[i] = regionDim[i] / 2;
                planeA.transform.localPosition = regionPos;
            }
        }
    }
}
