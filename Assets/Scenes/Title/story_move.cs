using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//「ねこゲーム」のストーリ―用スクリプト(コピペで使用可能)
public class story_move : MonoBehaviour
{
    public GameObject[] Paperstory = new GameObject[4];
    public Text[] storytext = new Text[7];
    public int PaperstoryNum;
    int storytextNum;

    //動かす前と動かした後の値を入れる
    private List<Vector3> PaperstoryFirstPosi = new List<Vector3> { new Vector3(-17, 18, 0), new Vector3(-17, 18, 0), new Vector3(-17, 18, 0), new Vector3(-17, 18, 0) };
    private List<Vector3> PaperstoryFirstRote = new List<Vector3> { new Vector3(0, 0, 90), new Vector3(0, 0, 90), new Vector3(0, 0, 90), new Vector3(0, 0, 90) };
    private List<Vector3> PaperstorySecondPosi = new List<Vector3> { new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0) };
    private List<Vector3> PaperstorySecondRote = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
    //セリフを入れる
    private List<string> storytextst = new List<string> { "ぼらんてぃあで" + "\r\n" + "おそうじにゃ", "てきとうに" + "\r\n" + "おいたにゃ", "なにかが" + "\r\n" + "できたにゃ", "なにかをいっぱいふやすにゃ", "がんばるねこ" + "\r\n" + "かわいいにゃ", "にゃー", "ぶらっくほーる" +　"\r\n" + "つよいにゃ" };

    public float nowtime = 0;
    private Vector3 vectorposi;
    private float vectorinfo;
    public int papernum = -1;
    private int movingnow = 0;

    // Start is called before the first frame update
    void Awake()
    {
        PaperstoryNum = Paperstory.Length;
        storytextNum = storytext.Length;
    }

    void Start()
    {
        firstposi();
    }

    //最初の場所
    private void firstposi()
    {
        for (int i = 0; i < PaperstoryNum; i++)
        {
            Paperstory[i].transform.localPosition = PaperstoryFirstPosi[i];
            Paperstory[i].transform.eulerAngles = PaperstoryFirstRote[i];
        }
        for (int i = 0; i < storytextNum; i++)
        {
            storytext[i].text = "";
        }
        nowtime = 0;
        papernum = -1;
        movingnow = 0;
    }

    //ボタンを押した時に動かす
    public void Story_Button()
    {
        if (movingnow == 0)
        {
            if (papernum < PaperstoryNum)
            {
                //画像の移動を始める
                StartMove();
            }
        }
    }

    //ストーリを動かす(常にここを通す)
    public void Storymove()
    {
        if (movingnow == 1)
        {
            if (papernum < PaperstoryNum)
            {
                MoveControll();
            }
            else if (papernum == PaperstoryNum)
            {
                EndMoveControll();
            }
        }
    }

    public void StartMove()
    {
        movingnow++;
        nowtime = 0;
        papernum++;
    }
    public void MoveControll()
    {
        Moving();
        if (nowtime > 1 && papernum < PaperstoryNum)
        {
            Paperstory[papernum].transform.localPosition = PaperstorySecondPosi[papernum];
            Paperstory[papernum].transform.eulerAngles = new Vector3(0, 0, 0);

            //ここでテキストを入れる場所とかをいじる
            switch (papernum)
            {
                case 0:
                    storytext[0].text = storytextst[0];
                    break;
                case 1:
                    storytext[1].text = storytextst[1];
                    storytext[2].text = storytextst[2];
                    break;
                case 2:
                    storytext[3].text = storytextst[3];
                    storytext[4].text = storytextst[4];
                    break;
                case 3:
                    storytext[5].text = storytextst[5];
                    storytext[6].text = storytextst[6];
                    break;
            }
            movingnow = 0;
        }
    }

    //
    public void EndMoveControll()
    {
        Moveend();
        if (nowtime > 1)
        {
            firstposi();
            movingnow = 0;
        }
        for (int j = 0; j < storytextNum; j++)
        {
            storytext[j].text = "";
        }
    }

    private void Moving()
    {
        vectorposi.x = nowtime * (PaperstorySecondPosi[papernum].x - PaperstoryFirstPosi[papernum].x) / 1 + PaperstoryFirstPosi[papernum].x;
        vectorposi.y = nowtime * (PaperstorySecondPosi[papernum].y - PaperstoryFirstPosi[papernum].y) / 1 + PaperstoryFirstPosi[papernum].y;
        vectorposi.z = nowtime * (PaperstorySecondPosi[papernum].z - PaperstoryFirstPosi[papernum].z) / 1 + PaperstoryFirstPosi[papernum].z;
        Paperstory[papernum].transform.position = vectorposi;

        vectorinfo = nowtime * (PaperstorySecondRote[papernum].z - PaperstoryFirstRote[papernum].z) / 1 + PaperstoryFirstRote[papernum].z;
        Paperstory[papernum].transform.eulerAngles = new Vector3(0, 0, vectorinfo);
        nowtime += Time.deltaTime;
    }

    private void Moveend()
    {
        for (int i = 0; i < PaperstoryNum; i++)
        {
            vectorposi.x = nowtime * (PaperstoryFirstPosi[i].x - PaperstorySecondPosi[i].x) / 1 + PaperstorySecondPosi[i].x;
            vectorposi.y = nowtime * (PaperstoryFirstPosi[i].y - PaperstorySecondPosi[i].y) / 1 + PaperstorySecondPosi[i].y;
            vectorposi.z = nowtime * (PaperstoryFirstPosi[i].z - PaperstorySecondPosi[i].z) / 1 + PaperstorySecondPosi[i].z;
            Paperstory[i].transform.position = vectorposi;

            vectorinfo = nowtime * (PaperstoryFirstRote[i].z - PaperstorySecondRote[i].z) / 1 + PaperstorySecondRote[i].z;
            Paperstory[i].transform.eulerAngles = new Vector3(0, 0, vectorinfo);
        }
        nowtime += Time.deltaTime;
    }
}
