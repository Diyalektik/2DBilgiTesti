using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class KayitIki : MonoBehaviour {

    GameObject kayitDepo;

    public string[] sorular;
    public string[] cevaplar;

    bool dogruCevap;

    string nameOfPlayer;

    public bool jokerUsed;

    public string jokerNerdeKullandi;

    public Dictionary<string, bool> dogruCevapMap;
    public Dictionary<string, List<string>> soruDuzeniMap;

    int i;//sorudüzeni oluşturda kullanmak üzre


    List<string> cevaplarDortlu;
    string[] tempCevaplarDortlu;

    void Start () {
        DontDestroyOnLoad(this);
        kayitDepo = GameObject.FindGameObjectWithTag("KayitDepo");
        nameOfPlayer = kayitDepo.GetComponent<Kayit>().GetNameofPlayer();
        // jokerNerdeKullandi = kayitDepo.GetComponent<Kayit>().GetJokerNerdeKullanildi();
        jokerUsed = kayitDepo.GetComponent<Kayit>().jokerUsed;
        if (jokerUsed==false)
        {
            jokerNerdeKullandi = "Jokeriniz hala duruyor, güzel.Kullanmaktan çekinin, diğer bölümlerde lazım olacağına eminim.";
        }
        else
        {
            jokerNerdeKullandi = "";
        }
        sorular = System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\sorularSezon2.txt");
        cevaplar = System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\cevaplarSezon2.txt");

        SezonIkiSoruDuzeniOlustur();
        Destroy(kayitDepo.gameObject);
        
    }

    public void SezonIkiSoruDuzeniOlustur()
    {
        cevaplarDortlu = new List<string>();
        tempCevaplarDortlu = new string[4];
        dogruCevapMap = new Dictionary<string, bool>();
        soruDuzeniMap = new Dictionary<string, List<string>>();

        i = 0;
        for (int j = 0; j < sorular.Length; j++)
        {

            cevaplarDortlu.Add(cevaplar[i]);
            cevaplarDortlu.Add(cevaplar[i + 1]);
            cevaplarDortlu.Add(cevaplar[i + 2]);
            cevaplarDortlu.Add(cevaplar[i + 3]);

            tempCevaplarDortlu[0] = cevaplar[i];
            tempCevaplarDortlu[1] = cevaplar[i + 1];
            tempCevaplarDortlu[2] = cevaplar[i + 2];
            tempCevaplarDortlu[3] = cevaplar[i + 3];



            soruDuzeniMap.Add(sorular[j], tempCevaplarDortlu.ToList<string>());
            cevaplarDortlu.Clear();

            i = i + 4;
        }

        //dogruCevapları sınıflandırma:
        //dogruCevapların valueları true, yanlışların false

        for (int a = 0; a < cevaplar.Length; a = a + 4)
        {
            dogruCevapMap.Add(cevaplar[a], true);
            dogruCevapMap.Add(cevaplar[a + 1], false);
            dogruCevapMap.Add(cevaplar[a + 2], false);
            dogruCevapMap.Add(cevaplar[a + 3], false);
        }
        Debug.Log(dogruCevapMap.ElementAt(1).Key);
    }




    public void JokerKullanildi()
    {
        jokerUsed = true;
        //  jokerNerdeKullandi="soru2de";
    }

    public string[] SoruCek()
    {
        return sorular;
    }
    public string[] CevapCek()
    {
        return cevaplar;
    }

    public Dictionary<string, bool> dogruCevapMapiVer()
    {
        return dogruCevapMap;
    }
    public Dictionary<string, List<string>> soruDuzeniMapiVer()
    {
        return soruDuzeniMap;
    }
    public void SoruSil(int sil)
    {
        sorular = sorular.Where(x => x != sorular[sil]).ToArray();
        cevaplar = cevaplar.Where(x => x != (cevaplar[sil * 4]) && (x != cevaplar[sil * 4 + 1]) && (x != cevaplar[sil * 4 + 2]) && (x != cevaplar[sil * 4 + 3])).ToArray();
        List<string> todelete = soruDuzeniMap.Keys.Where(k => k == soruDuzeniMap.ElementAt(sil).Key).ToList();
        foreach (string key in todelete)
        {
            soruDuzeniMap.Remove(key);
        }
    }
    public void JokerNerdeKullanildi(int kacinciSoru)
    {
        jokerNerdeKullandi = kacinciSoru + ". soruda kullandığınız joker gelecek sezonlarda başınızı ağrıtabilir. Ağrıtacak...";
    }

    public string RaporVer()
    {
        return "Bu sezonu da atlattınız. " + jokerNerdeKullandi;
    }
    public string GetNameofPlayer()
    {
        return nameOfPlayer;
    }
    public string GetJokerNerdeKullanildi()
    {
        return jokerNerdeKullandi;
    }
}
