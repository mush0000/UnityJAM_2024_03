using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    //このクラスの役割
    //ハイスコアを保存

    public static int hiScore;//合計得点(シーン切り替えても消えない)
    public static Text hiScoreText;//合計得点を表示

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
