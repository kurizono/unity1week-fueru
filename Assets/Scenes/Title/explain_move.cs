using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//「ねこゲーム」のストーリ―用スクリプト(コピペで使用可能)
public class explain_move : MonoBehaviour
{
    public GameObject[] Paperstory = new GameObject[3];
    public int PaperstoryNum;
    int storytextNum;

    //動かす前と動かした後の値を入れる
    private List<Vector3> PaperstoryFirstPosi = new List<Vector3> { new Vector3(-17, 18, 0), new Vector3(-17, 18, 0), new Vector3(-17, 18, 0), new Vector3(-17, 18, 0) };
    private List<Vector3> PaperstoryFirstRote = new List<Vector3> { new Vector3(0, 0, 90), new Vector3(0, 0, 90), new Vector3(0, 0, 90), new Vector3(0, 0, 90) };
    private List<Vector3> PaperstorySecondPosi = new List<Vector3> { new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0) };
    private List<Vector3> PaperstorySecondRote = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };

    public float nowtime = 0;
    private Vector3 vectorposi;
    private float vectorinfo;
    public int papernum = -1;
    private int movingnow = 0;

    // Start is called before the first frame update
    void Awake()
    {
        PaperstoryNum = Paperstory.Length;
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
