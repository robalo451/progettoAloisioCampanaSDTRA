using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.IO;
using UnityEngine.WSA;

public class menuController : MonoBehaviour
{

    public TMP_InputField selectedPath;
    public TMP_Text errorMessage;
    public Image errImm;

    private void Start()
    {
        errImm.gameObject.SetActive(false);
    }

    public void ExitVisual()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void startVisual()
    {
        if (string.IsNullOrEmpty(selectedPath.text))
        {
            errImm.gameObject.SetActive(true);
            errorMessage.text = "Unspecified Folder Path";
        }
        else if (File.Exists(selectedPath.text + "\\lesione.obj"))
        {
            errorMessage.text = "";
            errImm.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
            PlayerPrefs.SetString("Percorso", selectedPath.text); // passiamo il path alla mainScene
        }
        else
        {
            errImm.gameObject.SetActive(true);
            errorMessage.text = "Folder Path Does Not Exist Or No .obj File Found";
        }
    }

    public void OpenFolderBrowser()
    {
        // Imposta il callback quando la selezione è completata
        FileBrowser.SetDefaultFilter("."); // Optional: Imposta il filtro per le cartelle
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Folders", "."));
        FileBrowser.SetExcludedExtensions(".exe", ".dll");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        // Mostra il dialogo del file browser
        FileBrowser.ShowLoadDialog((paths) =>
        {
            // Callback quando la selezione è completata
            selectedPath.text = paths[0];
        },
        () =>
        {
            // Callback quando la selezione è cancellata
            Debug.Log("Folder selection cancelled");
        },
        FileBrowser.PickMode.Folders, // Modalità di selezione cartelle
        false, // Non permette soluzioni multiple
        null, // Percorso iniziale di default
        "Select Folder", // Titolo del dialogo
        "Select"); // Testo del pulsante di conferma
    }
}