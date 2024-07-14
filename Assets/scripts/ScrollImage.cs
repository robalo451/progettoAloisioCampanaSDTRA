using UnityEngine;
using UnityEngine.UI;
using System.IO;
using MixedReality.Toolkit.UX;
using TMPro;
public class ScrollImage : MonoBehaviour
{
    public int numSlices;
    public string vista;
    public Image targetImage; // Il componente UI Image a cui assegnare l'immagine
    public TMP_Text DisplayNumber;
    public GameObject piano;
    public int direzione;
    float spessore;

    private void Start()
    {
        Vector3 spessori = piano.transform.localScale;
        spessore = spessori[direzione];
        LoadImage();
    }
    public void LoadImage()
    {
        string basePath = PlayerPrefs.GetString("Percorso") + "\\" + vista + "\\slice_";
        int sliceNumber = (int)(GetComponent<MixedReality.Toolkit.UX.Slider>().Value * (numSlices - 1) );
        basePath = basePath + sliceNumber + ".jpg";
        DisplayNumber.text = (sliceNumber + 1).ToString();
        Debug.Log(sliceNumber);
        if (File.Exists(basePath))
        {
            byte[] imageBytes = File.ReadAllBytes(basePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);

            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            targetImage.GetComponent<Image>().sprite = sprite;
        }
        else
        {
            Debug.LogError("Immagine non trovata al percorso specificato: " + basePath);
        }

        if (vista == "coronale" && direzione != 2)
        {
            Vector3 position = piano.transform.localPosition;
            position[direzione] = spessore / 2 + spessore * (numSlices - 1 - sliceNumber);
            piano.transform.localPosition = position;
        }
        else
        {
            Vector3 position = piano.transform.localPosition;
            position[direzione] = spessore / 2 + spessore * sliceNumber;
            piano.transform.localPosition = position;
        }
    }
}
