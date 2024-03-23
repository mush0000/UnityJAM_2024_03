using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{

    public void OnPlayLoadScene()
    {
        StartCoroutine("PlayLoadScene");//正解音を流す
    }

    public IEnumerator PlayLoadScene()//シーン遷移
    {
        yield return new WaitForSeconds(0.4f);
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
