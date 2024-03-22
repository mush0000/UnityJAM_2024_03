using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDirector : MonoBehaviour
{
    //このクラスの役割
    //[1]リストからランダムで三つ子を３人選んで格納
    //[2]三つ子を表示（クリックで次に進む）
    //[3]暗転
    //[4]回答画面
    //[5]着替えるボタンで
    //[6]正答判定(true false)
    //[7]あってたら得点を加算して[1]へ(問題を消す)
    //[8]間違ってたらリザルトを表示(問題を消す)
    //[9]リザルトはスコア、ハイスコア表示
    //[10]ハイスコアの書き換え
    //[11]タイトルへ戻る

    public static int scores;//現在の得点を表示
    public int ADDSCORE = 100;//正解時の加算点

    public List<Sprite> allCharasA = new List<Sprite>();// キャラ一覧(アタッチで格納)
    public List<Sprite> allCharasB = new List<Sprite>();// キャラ一覧(アタッチで格納)
    public List<Sprite> allCharasC = new List<Sprite>();// キャラ一覧(アタッチで格納)
    public static List<Sprite> selectCharas;//一覧から問題を抜き出す箱

    public GameObject Canvas_Display;
    public GameObject Canvas_AnswerScreen;
    public GameObject Canvas_NextQuiz;
    public GameObject Canvas_Title;

    public void SelectQuiz()//[1]リストからランダムで三つ子を３人選んで格納
    {
        //抽選結果を入れるリストのインスタンスを作成
        selectCharas = new List<Sprite>();

        // キャラAをランダムに１つ抽選、取得
        int indexA = Random.Range(0, allCharasA.Count);
        Sprite quiz = allCharasA[indexA];//quizに一つ問題を入れる
        selectCharas.Add(quiz);//selectCharasに問題を加える

        // キャラBをランダムに１つ抽選、取得
        int indexB = Random.Range(0, allCharasB.Count);
        quiz = allCharasB[indexB];//quizに一つ問題を入れる
        selectCharas.Add(quiz);//selectCharasに問題を加える

        // キャラCをランダムに１つ抽選、取得
        int indexC = Random.Range(0, allCharasC.Count);
        quiz = allCharasC[indexC];//quizに一つ問題を入れる
        selectCharas.Add(quiz);//selectCharasに問題を加える

        Display();
    }


    public void Display()//[2]Canvas_Displayを表示する
    {
        Canvas_Display.gameObject.SetActive(true);
    }

    public void OnDisplayClick()//[3]クリックで次に進む→暗転
    {
        Debug.Log("OnDisplayClick");
        //暗転
        //Displayの三つ子を消す
        Canvas_Display.gameObject.SetActive(false);
        //AnswerScreenを呼ぶ
        Canvas_AnswerScreen.gameObject.SetActive(true);//[4]Canvas_AnswerScreenを表示
        //AnswerScreen();
    }
    // public void AnswerScreen()//
    // {
    //     //上に選んだ三つ子の画像
    //     //下には選択用スクロール式の三つ子(allCharas)を表示、畑画面が使えるはず…！
    // }

    public void OnAnserScreenClick()//[5]着替えるボタンで
    {
        int judg = 0;
        //[6]正答判定(true false)
        for (int i = 0; i < 3; i++)
        {
            // if(//問題の三つ子と回答した三つ子があってたら)
            // {
            //     judg += 1;
            // }
        }

        Canvas_AnswerScreen.gameObject.SetActive(false);

        if (judg == 3)//[7]三人ともあってたら得点を加算して[1]へ
        {
            Canvas_NextQuiz.gameObject.SetActive(true);
            //回答画面を非表示にする
            //リストの中身を空にする
            //スコアを加点
            scores += ADDSCORE;

        }
        //[8]一人でも間違ってたらリザルトを表示
        Canvas_Title.gameObject.SetActive(true);
    }

    //[7]三人ともあってたら得点を加算して[1]へ(問題を消す)
    public void OnNextQuizClick()
    {
        Canvas_NextQuiz.gameObject.SetActive(false);
        SelectQuiz();
    }

    //[10]クリックしたらタイトルへ戻るボタン
    public void OnTitleClick()
    {
        //[11]ハイスコアの書き換え
        if (GameDirector.hiScore < PlayDirector.scores)
        {
            GameDirector.hiScore = PlayDirector.scores;
        }
        SceneManager.LoadScene("00_Title");
    }


    // Start is called before the first frame update
    void Start()
    {
        SelectQuiz();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
