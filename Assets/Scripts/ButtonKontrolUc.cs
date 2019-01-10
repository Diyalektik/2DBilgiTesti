using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class ButtonKontrolUc : MonoBehaviour {

    GameObject kayitDepo3;
    GameObject buttonKontrol;
    GameObject sceneDegisimi;

    string[] sorular;
    string[] cevaplar;

    //  List<string> sorularList;
    //  List<string> cevaplarList;

    Dictionary<string, bool> dogruCevapMap;
    Dictionary<string, List<string>> soruDuzeniMap;


    Button buttonA;
    Button buttonB;
    Button buttonC;
    Button buttonD;
    Button jokerButton;

    Text soru;
    Text cevapA;
    Text cevapB;
    Text cevapC;
    Text cevapD;



    //  bool dogruCevap;

    bool jokerUsed; //joker her scenede aktif mi diye sorarken startta sorun çıkıyor onu gidermek için
    string jokerNerdeKullanildi;

    int randomCevap;
    int randomSoru;


    ColorBlock cb;
    ColorBlock defaultColorBlock;


    void Start () {
        defaultColorBlock = GameObject.FindGameObjectWithTag("ButtonA").GetComponent<Button>().colors;
        // DontDestroyOnLoad(this);
        kayitDepo3 = GameObject.FindGameObjectWithTag("KayitDepo3");
        buttonKontrol = GameObject.FindGameObjectWithTag("ButtonKontrol3");
        // jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
        jokerUsed = GameObject.FindGameObjectWithTag("KayitDepo3").GetComponent<KayitUc>().jokerUsed;

        YeniSceneSerp();
    }

    IEnumerator CevapEkraniDogru(Button button)
    {

        buttonA.interactable = false;
        buttonB.interactable = false;
        buttonC.interactable = false;
        buttonD.interactable = false;
        if (kayitDepo3.GetComponent<KayitUc>().jokerUsed == false) //sonraki scenler için aktif olmayabildiginden nerde bu diyor. Yoksa yoktur amk
        {
            jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
            jokerButton.interactable = false;
        }
        //  soru.text = "HARİKA";
        cb = button.colors;
        cb.normalColor = Color.yellow;
        cb.pressedColor = Color.yellow;
        cb.highlightedColor = Color.yellow;
        cb.disabledColor = Color.yellow;
        button.colors = cb;
        yield return new WaitForSeconds(1);
        cb.normalColor = Color.green;
        cb.pressedColor = Color.green;
        cb.highlightedColor = Color.green;
        cb.disabledColor = Color.green;
        button.colors = cb;

        yield return new WaitForSeconds(1);

        button.colors = defaultColorBlock;

        buttonA.interactable = true;
        buttonB.interactable = true;
        buttonC.interactable = true;
        buttonD.interactable = true;

        if (kayitDepo3.GetComponent<KayitUc>().jokerUsed == false) //sonraki scenler için aktif olmayabildiginden nerde bu diyor. Yoksa yoktur amk
        {
            jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
            jokerButton.interactable = true;
        }

        StartCoroutine(YeniSceneStart());




        yield return null;

    }
    IEnumerator CevapEkraniYanlis(Button button)
    {
        buttonA.interactable = false;
        buttonB.interactable = false;
        buttonC.interactable = false;
        buttonD.interactable = false;
        if (kayitDepo3.GetComponent<KayitUc>().jokerUsed == false) //sonraki scenler için aktif olmayabildiginden nerde bu diyor. Yoksa yoktur amk
        {
            jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
            jokerButton.interactable = false;
        }
        cb = button.colors;
        cb.normalColor = Color.yellow;
        cb.pressedColor = Color.yellow;
        cb.highlightedColor = Color.yellow;
        cb.disabledColor = Color.yellow;

        button.colors = cb;
        //button animasyonu
        yield return new WaitForSeconds(1);
        cb = button.colors;
        cb.normalColor = Color.red;
        cb.pressedColor = Color.red;
        cb.highlightedColor = Color.red;
        cb.disabledColor = Color.red;
        button.colors = cb;



        yield return new WaitForSeconds(1);

        button.colors = defaultColorBlock;

        buttonA.interactable = true;
        buttonB.interactable = true;
        buttonC.interactable = true;
        buttonD.interactable = true;
        if (kayitDepo3.GetComponent<KayitUc>().jokerUsed == false) //sonraki scenler için aktif olmayabildiginden nerde bu diyor. Yoksa yoktur amk
        {
            jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
            jokerButton.interactable = true;
        }
        yield return null;

    }

    IEnumerator YeniSceneStart()
    {


        buttonA.GetComponent<Button>().gameObject.SetActive(true);
        buttonB.GetComponent<Button>().gameObject.SetActive(true);
        buttonC.GetComponent<Button>().gameObject.SetActive(true);
        buttonD.GetComponent<Button>().gameObject.SetActive(true);
        cevapA.GetComponent<Text>().gameObject.SetActive(true);
        cevapB.GetComponent<Text>().gameObject.SetActive(true);
        cevapC.GetComponent<Text>().gameObject.SetActive(true);
        cevapD.GetComponent<Text>().gameObject.SetActive(true);
        sceneDegisimi.GetComponent<SceneDegisimi>().SceneGec();


        yield return null;
    }

    public void ButtonAclick()
    {
        if (dogruCevapMap[cevapA.text] == true)
        {
            StartCoroutine(CevapEkraniDogru(buttonA));

        }
        else
        {

            StartCoroutine(CevapEkraniYanlis(buttonA));
        }
    }
    public void ButtonBclick()
    {
        if (dogruCevapMap[cevapB.text] == true)
        {
            StartCoroutine(CevapEkraniDogru(buttonB));

        }
        else
        {
            StartCoroutine(CevapEkraniYanlis(buttonB));
        }
    }
    public void ButtonCclick()
    {
        if (dogruCevapMap[cevapC.text] == true)
        {
            StartCoroutine(CevapEkraniDogru(buttonC));

        }
        else
        {
            StartCoroutine(CevapEkraniYanlis(buttonC));
        }
    }
    public void ButtonDclick()
    {
        if (dogruCevapMap[cevapD.text] == true)
        {
            StartCoroutine(CevapEkraniDogru(buttonD));
        }
        else
        {
            StartCoroutine(CevapEkraniYanlis(buttonD));
        }
    }

    public void JokerButtonClick()
    {
        string[] buttonTexts = { cevapA.text, cevapB.text, cevapC.text, cevapD.text };


        foreach (string item in buttonTexts)
        {

            if (dogruCevapMap[item] == true)
            {

                buttonTexts = buttonTexts.Where(x => x != item).ToArray();
            }
        }

        List<string> buttonTextsList = buttonTexts.ToList<string>();
        buttonTextsList.RemoveAt(Random.Range(0, 2));
        // buttonTexts = buttonTexts.Where(x => x != buttonTexts[Random.Range(0,2)]).ToArray();

        foreach (string item in buttonTextsList)
        {
            if (item == cevapA.text)
            {
                buttonA.GetComponent<Button>().gameObject.SetActive(false);
            }
            if (item == cevapB.text)
            {
                buttonB.GetComponent<Button>().gameObject.SetActive(false);
            }
            if (item == cevapC.text)
            {
                buttonC.GetComponent<Button>().gameObject.SetActive(false);
            }
            if (item == cevapD.text)
            {
                buttonD.GetComponent<Button>().gameObject.SetActive(false);
            }
        }


        jokerButton.GetComponent<Button>().gameObject.SetActive(false);
        kayitDepo3.GetComponent<KayitUc>().JokerKullanildi();
        kayitDepo3.GetComponent<KayitUc>().JokerNerdeKullanildi(SceneManager.GetActiveScene().buildIndex - 1); //her sezon farklı bi ara bak

    }
    public void YeniSceneSerp()
    {

        SoruSerp();
        ButtonSerp();

    }


    void ButtonSerp()
    {
        buttonA = GameObject.FindGameObjectWithTag("ButtonA").GetComponent<Button>();
        buttonB = GameObject.FindGameObjectWithTag("ButtonB").GetComponent<Button>();
        buttonC = GameObject.FindGameObjectWithTag("ButtonC").GetComponent<Button>();
        buttonD = GameObject.FindGameObjectWithTag("ButtonD").GetComponent<Button>();

        //joker game objekt
        buttonKontrol = GameObject.FindGameObjectWithTag("ButtonKontrol3");
        sceneDegisimi = GameObject.FindGameObjectWithTag("SceneDegisimi");

        if (kayitDepo3.GetComponent<KayitUc>().jokerUsed == false) //sonraki scenler için aktif olmayabildiginden nerde bu diyor. Yoksa yoktur amk
        {
            jokerButton = GameObject.FindGameObjectWithTag("JokerButton").GetComponent<Button>();
            jokerButton.GetComponent<Button>().onClick.AddListener(buttonKontrol.GetComponent<ButtonKontrolUc>().JokerButtonClick);
        }

        buttonA.GetComponent<Button>().onClick.AddListener(buttonKontrol.GetComponent<ButtonKontrolUc>().ButtonAclick);
        buttonB.GetComponent<Button>().onClick.AddListener(buttonKontrol.GetComponent<ButtonKontrolUc>().ButtonBclick);
        buttonC.GetComponent<Button>().onClick.AddListener(buttonKontrol.GetComponent<ButtonKontrolUc>().ButtonCclick);
        buttonD.GetComponent<Button>().onClick.AddListener(buttonKontrol.GetComponent<ButtonKontrolUc>().ButtonDclick);


        buttonA.GetComponent<Button>().gameObject.SetActive(true);
        buttonB.GetComponent<Button>().gameObject.SetActive(true);
        buttonC.GetComponent<Button>().gameObject.SetActive(true);
        buttonD.GetComponent<Button>().gameObject.SetActive(true);

    }
    void SoruSerp()
    {

        soru = GameObject.FindGameObjectWithTag("SoruText").GetComponent<Text>();
        cevapA = GameObject.FindGameObjectWithTag("CevapAText").GetComponent<Text>();
        cevapB = GameObject.FindGameObjectWithTag("CevapBText").GetComponent<Text>();
        cevapC = GameObject.FindGameObjectWithTag("CevapCText").GetComponent<Text>();
        cevapD = GameObject.FindGameObjectWithTag("CevapDText").GetComponent<Text>();
        cevapA.GetComponent<Text>().gameObject.SetActive(true);
        cevapB.GetComponent<Text>().gameObject.SetActive(true);
        cevapC.GetComponent<Text>().gameObject.SetActive(true);
        cevapD.GetComponent<Text>().gameObject.SetActive(true);
        kayitDepo3 = GameObject.FindGameObjectWithTag("KayitDepo3");
        sorular = kayitDepo3.GetComponent<KayitUc>().SoruCek();
        cevaplar = kayitDepo3.GetComponent<KayitUc>().CevapCek();
        //  dogruCevap = kayitDepo.GetComponent<Kayit>().dogruCevap;

        dogruCevapMap = kayitDepo3.GetComponent<KayitUc>().dogruCevapMapiVer();
        soruDuzeniMap = kayitDepo3.GetComponent<KayitUc>().soruDuzeniMapiVer();




        randomSoru = Random.Range(0, sorular.Length - 1);
        soru.text = sorular[randomSoru];

        randomCevap = Random.Range(0, 3);

        cevapA.text = soruDuzeniMap[soru.text][randomCevap];
        soruDuzeniMap[soru.text].RemoveAt(randomCevap);
        randomCevap = Random.Range(0, 2);
        cevapB.text = soruDuzeniMap[soru.text][randomCevap];
        soruDuzeniMap[soru.text].RemoveAt(randomCevap);
        randomCevap = Random.Range(0, 1);
        cevapC.text = soruDuzeniMap[soru.text][randomCevap];
        soruDuzeniMap[soru.text].RemoveAt(randomCevap);

        cevapD.text = soruDuzeniMap[soru.text][0];


        // sorular = sorular.Where(x => x != sorular[randomSoru]).ToArray();
        kayitDepo3.GetComponent<KayitUc>().SoruSil(randomSoru);
    }
}
