using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatMove : MonoBehaviour
{
    ItemDrop itemdropcs;
    ResultData datacs;

    public GameObject cats, bug;
    public GameObject flame, resultcat;
    public Text result, catcomment;
    
    GameObject objectinfo;
    Vector3 vectorposi;
    Vector3[] vectorposiinfo;
    float vectorinfo;
    float timeinfo;

    //ねこの位置
    Vector3 catfirstposi = new Vector3(-5, 10, 0);
    Vector3 catfinalposi = new Vector3(-5, -25, 0);
    Vector3[] catposi = new Vector3[4] { new Vector3(-5, 0, 0), new Vector3(-5, -5, 0), new Vector3(-5, -10, 0), new Vector3(-5, -15, 0) };
    Vector3[] bugposi = new Vector3[2] { new Vector3(-3, 0, 0), new Vector3(6, 0, 0) };

    //フレームの大きさ
    Vector3[] flameposi = new Vector3[2] { new Vector3(3, 2, 0), new Vector3(3, 2, 0) };
    //ネコスタンプの大きさ
    Vector3[] catstampscale = new Vector3[2] { new Vector3(1, 1, 0), new Vector3(0.8f, 0.8f, 0) };

    //バッグが移動する時間
    float bugmovetime = 0.7f;

    //合計量を見る
    int SumItem;

    //いまうごいてるネコ
    int catnum;

    //時間関係 
    float timewatch = 0;


    private void Awake()
    {
        itemdropcs = GetComponent<ItemDrop>();
        First();
        NowGameData();
    }

    void Start()
    {
        StartCoroutine("catmove");
    }

    void First()
    {
        cats.transform.position = catfirstposi;
        bug.SetActive(false);
        flame.transform.localScale = flameposi[0];
        flame.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        resultcat.transform.localScale = catstampscale[0];
        resultcat.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        result.text = "";
        catcomment.text = "";
    }

    IEnumerator catmove()
    {
        //1のねこ
        timewatch = Time.time;
        while (Time.time -  timewatch < 2)
        {
            cats.transform.position = (catposi[0] - catfirstposi) * (Time.time - timewatch) / 2 + catfirstposi;
            yield return null;
        }
        catnum = 0;
        StartCoroutine("Bugmove");

        //2のねこ
        timewatch = Time.time;
        while (Time.time - timewatch < 1)
        {
            cats.transform.position = (catposi[1] - catposi[0]) * (Time.time - timewatch) / 1 + catposi[0];
            yield return null;
        }
        catnum = 1;
        StartCoroutine("Bugmove");

        //3のねこ
        timewatch = Time.time;
        while (Time.time - timewatch < 1)
        {
            cats.transform.position = (catposi[2] - catposi[1]) * (Time.time - timewatch) / 1 + catposi[1];
            yield return null;
        }
        catnum = 2;
        StartCoroutine("Bugmove");

        //4のねこ
        timewatch = Time.time;
        while (Time.time - timewatch < 1)
        {
            cats.transform.position = (catposi[3] - catposi[2]) * (Time.time - timewatch) / 1 + catposi[2];
            yield return null;
        }
        catnum = 3;
        StartCoroutine("Bugmove");
        
        //ねこさよなら
        timewatch = Time.time;
        while (Time.time - timewatch < 2)
        {
            cats.transform.position = (catfinalposi - catposi[3]) * (Time.time - timewatch) / 2 + catposi[3];
            yield return null;
        }
        yield return null;

        //フレームでる
        timewatch = Time.time;       
        timeinfo = 0.5f;
        objectinfo = flame;
        vectorposiinfo = flameposi;
        StartCoroutine("Result_show");
        yield return null;




        //結果でる
        result.text = SumItem + "ナニカ";

        yield return new WaitForSeconds(0.5f);

        //ネコでる
        timewatch = Time.time;
        timeinfo = 1f;
        objectinfo = resultcat;
        vectorposiinfo = catstampscale;
        StartCoroutine("Result_show");
        yield return null;

        StartCoroutine("CatTalk");
    }

    IEnumerator Bugmove()
    {
        bug.SetActive(true);
        bug.transform.position = bugposi[0];
        timewatch = Time.time;
        while (Time.time - timewatch < bugmovetime)
        {
            bug.transform.position = (bugposi[1] - bugposi[0]) * (Time.time - timewatch) / bugmovetime + bugposi[0];
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        bug.SetActive(false);
        itemdropcs.Cat_ItemDrop(catnum);
    }

    //timeinfoに制限時間、objectinfoに動かすオブジェクト、vectorposiinfoにオブジェクトの位置、
    IEnumerator Result_show()
    {
        while (Time.time - timewatch < timeinfo)
        {
            vectorposi = objectinfo.transform.localScale;
            vectorinfo = (Time.time - timewatch) * (vectorposiinfo[1].x - vectorposiinfo[0].x) / timeinfo;
            vectorposi.x = vectorinfo + vectorposiinfo[0].x;
            vectorinfo = (Time.time - timewatch) * (vectorposiinfo[1].y - vectorposiinfo[0].y) / timeinfo;
            vectorposi.y = vectorinfo + vectorposiinfo[0].y;
            objectinfo.transform.localScale = vectorposi;
            vectorinfo = (Time.time - timewatch) / timeinfo;
            objectinfo.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, vectorinfo);
            yield return null;
        }
    }

    IEnumerator CatTalk()
    {
        if (SumItem > 50)
        {
            catcomment.text = "かんぺきな" + "\r\n" + "ねこにゃ";
        }
        else if (SumItem > 40)
        {
            catcomment.text = "すごいにゃ";
        }
        else if(SumItem > 30)
        {
            catcomment.text = "もしかして"+ "\r\n" +"ひとにゃ？";
        }
        else if(SumItem > 20)
        {
            catcomment.text = "やすめにゃ";
        }
        else if(SumItem > 10)
        {
            catcomment.text = "ねろにゃ";
        }
        else
        {
            catcomment.text = "にゃー";
        }
        yield return null;
    }

    public void NowGameData()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < GameData.item.Length; j++)
            {
                SumItem += GameData.itemcount[i, j];
            }
        }
    }
}
