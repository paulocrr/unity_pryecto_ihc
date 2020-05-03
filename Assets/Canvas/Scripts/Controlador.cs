using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using UnityEngine.Windows.Speech;
using System;
using Vuforia;
using UnityEngine.EventSystems;
public class Controlador : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    public GameObject PanelMenu;
    public GameObject PanelJugar;
    public GameObject PanelManual;


    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Jugar", BotonJugar);
        actions.Add("Manual", BotonManual);
        actions.Add("Salir", BotonSalir);
        actions.Add("Menu", BotonMenu);



        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    public void BotonManual()
    {
        PanelManual.SetActive(true);
        PanelJugar.SetActive(false);
        PanelMenu.SetActive(false);
    }
    public void BotonJugar()
    {
        PanelManual.SetActive(false);
        PanelJugar.SetActive(true);
        PanelMenu.SetActive(false);
    }
    public void BotonMenu()
    {
        PanelManual.SetActive(false);
        PanelJugar.SetActive(false);
        PanelMenu.SetActive(true);
    }
    public void BotonSalir()
    {
        print("salir");
        Application.Quit();
    }

}
