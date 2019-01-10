using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonKontrol : MonoBehaviour {


    //buttonların üstüne atanacak script
    Animator ButtonAnim;

    GameObject sceneDegisimi;

    
    private void Start()
    {
        ButtonAnim = this.GetComponent<Animator>();
        sceneDegisimi = GameObject.FindGameObjectWithTag("SceneDegisimi");
    }

    IEnumerator SceneGecButtonClick(Animator anim)
    {
        anim.SetTrigger("ButtonClick");
       
      
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("ButtonAnimStop");
        sceneDegisimi.GetComponent<SceneDegisimi>().SceneGec();
        yield return null;
    }

    IEnumerator commonButtonClick(Animator anim)
    {
        anim.SetTrigger("ButtonClick");


        yield return new WaitForSeconds(1f);
        anim.SetTrigger("ButtonAnimStop");

        yield return null;
    }



    public void sceneGecButtonClick()
    {
        
        StartCoroutine(SceneGecButtonClick(ButtonAnim));
    
    }
    public void commonButtonClick()
    {
        StartCoroutine(commonButtonClick(ButtonAnim));
    }
   
}
