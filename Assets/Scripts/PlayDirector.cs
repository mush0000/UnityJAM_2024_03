using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Text hiScoresText;//ハイスコアを画面に表示
    public static int scores;//現在の得点を表示
    public Text scoresText;//ハイスコアを画面に表示
    public int ADDSCORE = 100;//正解時の加算点
    public Text ResultScoresText;//スコアをリザルト画面に表示

    public List<Sprite> allCharasA = new List<Sprite>();// キャラA一覧(アタッチで格納)
    public List<Sprite> allCharasB = new List<Sprite>();// キャラB一覧(アタッチで格納)
    public List<Sprite> allCharasC = new List<Sprite>();// キャラC一覧(アタッチで格納)
    public static List<Sprite> selectCharas;//一覧から問題を抜き出す箱

    public Sprite CharaAQuiz;//正解のキャラA画像
    int indexA;//正解のキャラA画像番号
    public Image Image_CharacterA;//クイズ画面に表示
    public Sprite CharaAAnser;//プレイヤーが選択したキャラA画像
    public int CharaAAnserIndex = 0;//プレイヤーが選択したキャラA画像番号
    public Image Image_CharacterA_Anser;//プレイヤーが選択したキャラA画面に表示
    [SerializeField] public Image CharaAcross;//不正解時に対象キャラに×を表示

    public Sprite CharaBQuiz;//正解のキャラB画像
    int indexB;//正解のキャラB画像番号
    public Image Image_CharacterB;//クイズ画面に表示
    public Sprite CharaBAnser;//プレイヤーが選択したキャラB画像
    public int CharaBAnserIndex = 0;//プレイヤーが選択したキャラB画像番号
    public Image Image_CharacterB_Anser;//プレイヤーが選択したキャラB画面に表示
    [SerializeField] public Image CharaBcross;//不正解時に対象キャラに×を表示

    public Sprite CharaCQuiz;//正解のキャラC画像
    int indexC;//正解のキャラA画像番号
    public Image Image_CharacterC;//クイズ画面に表示
    public Sprite CharaCAnser;//プレイヤーが選択したキャラC画像
    public int CharaCAnserIndex = 0;//プレイヤーが選択したキャラC画像番号
    public Image Image_CharacterC_Anser;//プレイヤーが選択したキャラC画面に表示
    [SerializeField] public Image CharaCcross;//不正解時に対象キャラに×を表示

    public Image resultImage;//リザルトでのコメント表示用
    public Sprite resultImageS;//結果ごとの表示画像
    public Sprite resultImageA;//結果ごとの表示画像
    public Sprite resultImageB;//結果ごとの表示画像
    public Sprite resultImageC;//結果ごとの表示画像
    public Sprite resultImageD;//結果ごとの表示画像

    public GameObject Canvas_base;
    public GameObject Canvas_Display;
    public GameObject Canvas_AnswerScreen;
    public GameObject Canvas_AnswerLook;
    public GameObject Canvas_NextQuiz;
    public GameObject Canvas_Anser;
    public GameObject Canvas_Result;
    public GameObject Canvas_CrossA;
    public GameObject Canvas_CrossB;
    public GameObject Canvas_CrossC;
    public GameObject Canvas_CircleA;
    public GameObject Canvas_CircleB;
    public GameObject Canvas_CircleC;



    //音声用
    // public AudioClip UiSe00Ok;
    // public AudioClip UiSe01Select;
    // public AudioClip Se00CorrectAnswer;
    // public AudioClip Se01InCorrectAnswer;
    // public AudioClip Se02Cutain;
    // AudioSource audioSource;

    public void SelectQuiz()//[1]リストからランダムで三つ子を３人選んで格納
    {
        //ハイスコアの表示
        this.hiScoresText.text = GameDirector.hiScore.ToString("00000");


        //抽選結果を入れるリストのインスタンスを作成
        selectCharas = new List<Sprite>();

        // キャラAをランダムに１つ抽選、取得
        indexA = Random.Range(0, allCharasA.Count);
        CharaAQuiz = allCharasA[indexA];
        this.Image_CharacterA.sprite = CharaAQuiz;
        //Sprite quiz = allCharasA[indexA];//quizに一つ問題を入れる
        //selectCharas.Add(quiz);//selectCharasに問題を加える

        // キャラBをランダムに１つ抽選、取得
        indexB = Random.Range(0, allCharasB.Count);
        CharaBQuiz = allCharasB[indexB];
        this.Image_CharacterB.sprite = CharaBQuiz;
        //quiz = allCharasB[indexB];//quizに一つ問題を入れる
        //selectCharas.Add(quiz);//selectCharasに問題を加える

        // キャラCをランダムに１つ抽選、取得
        indexC = Random.Range(0, allCharasC.Count);
        CharaCQuiz = allCharasC[indexC];
        this.Image_CharacterC.sprite = CharaCQuiz;
        //quiz = allCharasC[indexC];//quizに一つ問題を入れる
        //selectCharas.Add(quiz);//selectCharasに問題を加える

        //選択した数値の初期化
        CharaAAnserIndex = 0;
        CharaBAnserIndex = 0;
        CharaCAnserIndex = 0;
        //選択した画像の初期化
        CharaAAnser = allCharasA[CharaCAnserIndex];
        this.Image_CharacterA_Anser.sprite = CharaAAnser;
        CharaBAnser = allCharasB[CharaBAnserIndex];
        this.Image_CharacterB_Anser.sprite = CharaBAnser;
        CharaCAnser = allCharasC[CharaCAnserIndex];
        this.Image_CharacterC_Anser.sprite = CharaCAnser;

        Display();
    }


    public void Display()//[2]Canvas_Displayを表示する
    {
        Canvas_Display.gameObject.SetActive(true);
    }

    public void OnDisplayClick()//[3]クリックで次に進む→暗転
    {
        //暗転
        //Displayの三つ子を消す
        Canvas_Display.gameObject.SetActive(false);
        //AnswerScreenを呼ぶ
        Canvas_AnswerScreen.gameObject.SetActive(true);//[4]Canvas_AnswerScreenを表示
        Canvas_AnswerLook.gameObject.SetActive(true);
        //音声
        //audioSource.PlayOneShot(UiSe00Ok);
    }

    //ボタン設定ブロック
    #region ArrowButtonSetting
    public void CharaALeftArrow()//index-1の画像へ書き換える
    {
        CharaAAnserIndex -= 1;
        CharaAAnserIndex = Mathf.Clamp(CharaAAnserIndex, 0, allCharasA.Count - 1);
        // Debug.Log(CharaAAnserIndex);
        CharaAAnser = allCharasA[CharaAAnserIndex];
        this.Image_CharacterA_Anser.sprite = CharaAAnser;
        //audioSource.PlayOneShot(UiSe01Select);
    }
    public void CharaARightArrow()//index+1の画像へ書き換える
    {
        CharaAAnserIndex += 1;
        CharaAAnserIndex = Mathf.Clamp(CharaAAnserIndex, 0, allCharasA.Count - 1);
        // Debug.Log(CharaAAnserIndex);
        CharaAAnser = allCharasA[CharaAAnserIndex];
        this.Image_CharacterA_Anser.sprite = CharaAAnser;
        //audioSource.PlayOneShot(UiSe01Select);
    }
    public void CharaBLeftArrow()
    {
        CharaBAnserIndex -= 1;
        CharaBAnserIndex = Mathf.Clamp(CharaBAnserIndex, 0, allCharasB.Count - 1);
        // Debug.Log(CharaBAnserIndex);
        CharaBAnser = allCharasB[CharaBAnserIndex];
        this.Image_CharacterB_Anser.sprite = CharaBAnser;
        //audioSource.PlayOneShot(UiSe01Select);
    }
    public void CharaBRightArrow()
    {
        CharaBAnserIndex += 1;
        CharaBAnserIndex = Mathf.Clamp(CharaBAnserIndex, 0, allCharasB.Count - 1);
        // Debug.Log(CharaBAnserIndex);
        CharaBAnser = allCharasB[CharaBAnserIndex];
        this.Image_CharacterB_Anser.sprite = CharaBAnser;
        //audioSource.PlayOneShot(UiSe01Select);
    }
    public void CharaCLeftArrow()
    {
        CharaCAnserIndex -= 1;
        CharaCAnserIndex = Mathf.Clamp(CharaCAnserIndex, 0, allCharasC.Count - 1);
        CharaCAnser = allCharasC[CharaCAnserIndex];
        this.Image_CharacterC_Anser.sprite = CharaCAnser;
        //audioSource.PlayOneShot(UiSe01Select);
    }
    public void CharaCRightArrow()
    {
        CharaCAnserIndex += 1;
        CharaCAnserIndex = Mathf.Clamp(CharaCAnserIndex, 0, allCharasC.Count - 1);
        CharaCAnser = allCharasC[CharaCAnserIndex];
        this.Image_CharacterC_Anser.sprite = CharaCAnser;
        //audioSource.PlayOneShot(UiSe01Select);
    }
    #endregion

    public void OnAnserScreenClick()//[5]着替えるボタンで
    {
        //audioSource.PlayOneShot(Se02Cutain);
        int judg = 0;
        //[6]正答判定(true false)
        if (indexA == CharaAAnserIndex)//問題のAと回答したAが一致してたら
        {
            Canvas_CircleA.SetActive(true);
            judg += 1;
        }
        else
        {
            // Debug.Log("はいったかどうか");
            // CharaAcross.enabled = true;
            Canvas_CrossA.SetActive(true);
        }
        if (indexB == CharaBAnserIndex)//問題のBと回答したBが一致してたら)
        {
            Canvas_CircleB.SetActive(true);
            judg += 1;
        }
        else
        {
            Canvas_CrossB.SetActive(true);
        }
        if (indexC == CharaCAnserIndex)//問題のCと回答したCが一致してたら)
        {
            Canvas_CircleC.SetActive(true);
            judg += 1;
        }
        else
        {
            Canvas_CrossC.SetActive(true);
        }

        Canvas_AnswerScreen.gameObject.SetActive(false);

        if (judg == 3)//[7]三人ともあってたら得点を加算して[1]へ
        {
            Canvas_NextQuiz.gameObject.SetActive(true);
            StartCoroutine("CorrectAnswer");//正解音を流す

            //回答画面を非表示にする
            //リストの中身を空にする
            //スコアを加点
            scores += ADDSCORE;
            this.scoresText.text = scores.ToString("00000");
            //[11]ハイスコアの書き換え
            if (GameDirector.hiScore < scores)
            {
                GameDirector.hiScore = scores;
                this.hiScoresText.text = GameDirector.hiScore.ToString("00000");
            }
        }
        else
        {//[8]一人でも間違ってたらリザルトを表示
            Canvas_Anser.gameObject.SetActive(true);
            this.ResultScoresText.text = scores.ToString("00000");//スコアをリザルト画面に表示
            StartCoroutine("InCorrectAnswer");//不正解音を流す
        }
    }

    public AudioClip sound_CorrectAnswer;
    public AudioClip sound_InCorrectAnswer;
    AudioSource audioSource;
    public IEnumerator CorrectAnswer()//正解音を流す
    {
        yield return new WaitForSeconds(0.1f);
        this.audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound_InCorrectAnswer);
    }
    public IEnumerator InCorrectAnswer()//不正解音を流す
    {
        yield return new WaitForSeconds(0.1f);
        this.audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound_CorrectAnswer);
    }

    //[7]三人ともあってたら得点を加算して[1]へ(問題を消す)
    public void OnNextQuizClick()
    {
        //audioSource.PlayOneShot(UiSe00Ok);
        Canvas_AnswerLook.gameObject.SetActive(false);
        Canvas_NextQuiz.gameObject.SetActive(false);
        Canvas_CircleA.SetActive(false);
        Canvas_CircleB.SetActive(false);
        Canvas_CircleC.SetActive(false);
        SelectQuiz();
    }

    public void OnAnserClick()
    {
        Canvas_base.gameObject.SetActive(false);//ハイスコアの文字消す
        JudeResultScores(); //リザルトのコメント画像をスコアに応じて書き換える
        Canvas_Result.gameObject.SetActive(true);//リザルトの表示
    }

    public void JudeResultScores()//スコアに応じてコメント画像を書き換える
    {
        if (scores >= 10000)
        {
            this.resultImage.sprite = resultImageS;

        }
        else if (scores >= 1000)
        {
            this.resultImage.sprite = resultImageA;
        }
        else if (scores >= 600)
        {
            this.resultImage.sprite = resultImageB;
        }
        else if (scores >= 300)
        {
            this.resultImage.sprite = resultImageC;
        }
        else if (scores >= 0)
        {
            this.resultImage.sprite = resultImageD;
        }
    }

    //[10]クリックしたらタイトルへ戻るボタン
    public void OnTitleClick()
    {

        //audioSource.PlayOneShot(UiSe00Ok);
        //[11]ハイスコアの書き換え
        if (GameDirector.hiScore < scores)
        {
            GameDirector.hiScore = scores;
            this.hiScoresText.text = GameDirector.hiScore.ToString("00000");
        }
        //スコアの初期化
        scores = 0;
        SceneManager.LoadScene("00_Title");
    }


    //カーテンを動かす
    //X1920(開いてる) → 0.05秒 → X-1920(閉まる)0.1秒 → 0.05秒 →　X1920(開く)
    // public RectTransform Curtain;
    // private int counter = 1920;
    // private int Default = 0;
    // private float move = -1f;
    // public void CurtainSlide()
    // {
    //     Curtain.position += new Vector3(move, 0, 0);
    //     counter++;
    //     if (counter == 100)
    //     {
    //         counter = 0;
    //         move *= -1f;
    //     }
    //     // counter--;
    //     // if (counter == -1920)
    //     // {
    //     //     counter = 0;
    //     //     move *= 1;
    //     // }

    //     // if (counter == -1920)
    //     // {
    //     //     counter = 0;
    //     //     move *= 1;
    //     // }

    // }


    // Start is called before the first frame update
    void Start()
    {
        //カーテン演出
        //CurtainSlide();
        SelectQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        //CurtainSlide();
        // Curtain.position += new Vector3(move, 0, 0);
        // counter++;
        // if (counter == 100)
        // {
        //     counter = 0;
        //     move *= 1;
        // }
    }
}
