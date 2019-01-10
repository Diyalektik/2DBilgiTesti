using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SezonArasiKontrol : MonoBehaviour {

    GameObject kayitDepo;
    GameObject image;
    Button soruButton;
    Button buttonA;
    Button buttonB;
    Button buttonC;
    Button buttonD;
    Button jokerButton;

    Text cevapA;
    Text cevapB;
    Text cevapC;
    Text cevapD;
    Text jokerText;
    Text soruText;

    public Color ImageColor;
    ColorBlock cb;
    public Text sezonArasiText;
    public Color yeniRenkNormal;
    public Color yeniRenkPressed;
    public Color yeniRenkHighlighted;
    public Color yeniRenkDisabled;

    // Use this for initialization
    void Start () {
        
        kayitDepo = GameObject.FindGameObjectWithTag("KayitDepo");
        //her sezon kayit,buttonkontrol +1 olacak


        image = GameObject.FindGameObjectWithTag("ImageTag");
        soruButton = GameObject.FindGameObjectWithTag("SoruButton").GetComponent<Button>();
        buttonA = GameObject.FindGameObjectWithTag("ButtonA").GetComponent<Button>();
        buttonB = GameObject.FindGameObjectWithTag("ButtonB").GetComponent<Button>();
        buttonC = GameObject.FindGameObjectWithTag("ButtonC").GetComponent<Button>();
        buttonD = GameObject.FindGameObjectWithTag("ButtonD").GetComponent<Button>();
        if (kayitDepo.GetComponent<Kayit>().jokerUsed==false)
        {
            jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
            jokerText = GameObject.FindGameObjectWithTag("JokerText").GetComponent<Text>();
        }
        
        cevapA = GameObject.FindGameObjectWithTag("CevapAText").GetComponent<Text>();
        cevapB = GameObject.FindGameObjectWithTag("CevapBText").GetComponent<Text>();
        cevapC = GameObject.FindGameObjectWithTag("CevapCText").GetComponent<Text>();
        cevapD = GameObject.FindGameObjectWithTag("CevapDText").GetComponent<Text>();
       
        soruText = GameObject.FindGameObjectWithTag("SoruText").GetComponent<Text>();

        TemaRengiDegistir();



        sezonArasiText.text=kayitDepo.GetComponent<Kayit>().RaporVer();
	}
    public void SceneGec()
    {

        if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    void TemaRengiDegistir()
    {
        cb = buttonA.colors;
        cb.normalColor = yeniRenkNormal;
        cb.pressedColor = yeniRenkPressed;
        cb.highlightedColor = yeniRenkHighlighted;
        cb.disabledColor = yeniRenkDisabled;

        soruButton.colors = cb;
        buttonA.colors = cb;
        buttonB.colors = cb;
        buttonC.colors = cb;
        buttonD.colors = cb;

        //kayitdepo1i silmeden önce yaz startta!
        if (kayitDepo.GetComponent<Kayit>().jokerUsed==false)
        {
            
            jokerButton.colors = cb;
            jokerText.color = Color.cyan;
        }

        image.GetComponent<Image>().color = Color.cyan;
        soruText.color = Color.cyan;
        cevapA.color = Color.cyan;
        cevapB.color = Color.cyan;
        cevapC.color = Color.cyan;
        cevapD.color = Color.cyan;
        

    }
       

}
