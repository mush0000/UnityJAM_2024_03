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
    public List<CharacterData> allCharas = new List<CharacterData>();// キャラ一覧(アタッチで格納)
    public static List<CharacterData> selectCharas;//一覧から問題を抜き出す箱

    public void SelectQuiz()//[1]リストからランダムで三つ子を３人選んで格納
    {
        // 抽選結果を入れるリストのインスタンスを作成
        selectCharas = new List<CharacterData>();
        for (int i = 0; i < 3; i++)
        {
            // ランダムな内容を１つ抽選、取得
            int index = Random.Range(0, allCharas.Count);
            CharacterData quiz = allCharas[index];//quizに一つ問題を入れる
            selectCharas.Add(quiz);//selectCharasに問題を加える
        }
        Display();
    }


    public void Display()//[2]三つ子を表示する
    {

    }

    public void OnDisplayClick()//[3]クリックで次に進む→暗転
    {
        //Displayの三つ子を消す
        //暗転
        //AnswerScreenを呼ぶ

        AnswerScreen();
    }

    public void AnswerScreen()//[4]回答画面
    {
        //上に選んだ三つ子の画像
        //下には選択用スクロール式の三つ子(allCharas)を表示、畑画面が使えるはず…！
    }

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

        if (judg == 3)//[7]三人ともあってたら得点を加算して[1]へ(問題を消す)
        {
            //selectCharas[quizCount-1].gameObject.SetActive(false);
            //回答画面を非表示にする
            //リストの中身を空にする
            //スコアを加点
            scores += ADDSCORE;

        }
        //[8]一人でも間違ってたらリザルトを表示(問題を消す)


        //[9]リザルトはスコア、ハイスコア表示
        //selectCharas[quizCount-1].gameObject.SetActive(true);

        //[10]ハイスコアの書き換え
        if (GameDirector.hiScore < PlayDirector.scores)
        {
            GameDirector.hiScore = PlayDirector.scores;
        }
    }

    //[7]三人ともあってたら得点を加算して[1]へ(問題を消す)
    public void OnNextQuizClick()
    {
        SelectQuiz();
    }

    //[11]クリックしたらタイトルへ戻るボタン
    public void OnTitleClick()
    {
        SceneManager.LoadScene("Title");
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
