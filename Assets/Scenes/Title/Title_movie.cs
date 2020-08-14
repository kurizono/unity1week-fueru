using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_movie : MonoBehaviour
{
    public GameObject Cat_stamp;
    public GameObject Cats;

    //時間関係
    float time_maneger_sum = 0;
    float time_maneger_delta = 0;
    float run_time = 3;
    float wait_time = 0.7f;

    //ネコが移動する場所
    float[] Catposi_range_y = new float[2] {5, -5 };
    Vector3 Catposi_left = new Vector3(-25, 0, 0);
    Vector3 Catposi_right = new Vector3(25, 0, 0);
    //ねこが移動する向き
    int vec = -1;

    // Start is called before the first frame update
    void Start()
    {
        Cat_Leftset();
    }

    // Update is called once per frame
    void Update()
    {
        time_maneger_sum += Time.deltaTime;
        time_maneger_delta = Time.deltaTime;

        if (time_maneger_sum < run_time)
        {
            if (vec == -1)
            {
                Left_step();
            }
            else if(vec == 1)
            {
                Right_step();
            }
        }
        else
        {
            StartCoroutine("Catrun_Allset");
        }
    }

    //ネコが走る場所の初期設定(ランダムver)
    void Catrun_setting()
    {
        Catposi_right.y = Random.Range(Catposi_range_y[0], Catposi_range_y[1]);
        Catposi_left.y = Random.Range(Catposi_range_y[0], Catposi_range_y[1]);
        vec = Random.Range(0, 2);
        if(vec == 0)
        {
            vec = -1;
            Cat_Leftset();
        }
        else if(vec == 1)
        {
            Cat_Rightset();
        }
    }
    //ネコを初期位置に設置(左から右)
    void Cat_Leftset()
    {
        Cats.transform.position = Catposi_left;
        Cats.transform.rotation = new Quaternion(0, 0, 0, 0);
        Cat_stamp.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    //ネコを初期位置に設置(右から左)
    void Cat_Rightset()
    {
        Cats.transform.position = Catposi_right;
        Cats.transform.rotation = new Quaternion(0, 180, 0, 0);
        Cat_stamp.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    //一秒まって初期化
    IEnumerator Catrun_Allset()
    {
        yield return new WaitForSeconds(wait_time);
        Catrun_setting();
        time_maneger_sum = 0;
    }

    //ネコスタンプが転がるのを二人の猫が追いかけている(３秒)
    void Left_step()
    {
        Cats.transform.position += (Catposi_right - Catposi_left)*time_maneger_delta/run_time;
        Cat_stamp.transform.Rotate(new Vector3(0, 0, -1), 360*time_maneger_delta);
    }

    void Right_step()
    {
        Cats.transform.position += (Catposi_left - Catposi_right) * time_maneger_delta / run_time;
        Cat_stamp.transform.Rotate(new Vector3(0, 0, -1), 360 * time_maneger_delta);
    }
}
