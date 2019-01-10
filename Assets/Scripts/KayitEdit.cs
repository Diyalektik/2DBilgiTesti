using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class KayitEdit : MonoBehaviour {

    GameObject kayitDepo;
    GameObject buttonKontrol;
	void Start () {

        
        kayitDepo = GameObject.FindGameObjectWithTag("KayitDepo");
        buttonKontrol = GameObject.FindGameObjectWithTag("ButtonKontrol");
        kayitDepo.GetComponent<Kayit>().sorular= System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\sorularSezon2.txt");
        kayitDepo.GetComponent<Kayit>().cevaplar = System.IO.File.ReadAllLines(@"C:\udemy oyun\Soru-Cevap 2019\Assets\sorular-cevaplar\cevaplarSezon2.txt");
        kayitDepo.GetComponent<Kayit>().dogruCevapMap.Clear();
        kayitDepo.GetComponent<Kayit>().soruDuzeniMap.Clear();
        kayitDepo.GetComponent<Kayit>().SezonBirSoruDuzeniOlustur();
        Destroy(buttonKontrol.gameObject);
        
    
    }
	
	
}
