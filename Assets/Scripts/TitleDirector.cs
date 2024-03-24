using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    //カーテン演出
    private Animator animator;
    public GameObject Canvas_curtain;

    public void OnPlayLoadScene()
    {
        //カーテン演出
        // animator = gameObject.GetComponent<Animator>();
        // animator.SetBool("blRot", true);
        Canvas_curtain.gameObject.SetActive(true);
        StartCoroutine("PlayLoadScene");
    }



    public IEnumerator PlayLoadScene()//シーン遷移
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("01_Play");
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }






}
