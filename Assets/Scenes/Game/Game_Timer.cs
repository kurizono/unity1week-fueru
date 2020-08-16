using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Timer : MonoBehaviour
{
    Game_Controll controllcs;

    public Text timewatch;
    float starttime, timer;
    //制限時間
    int MaxTime = 20;

    private void Start()
    {
        controllcs = GetComponent<Game_Controll>();
    }

    //スタートの合図
    public void TimerView_Start()
    {
        StartCoroutine("TimerView_Start_C");
    }
    //おわりの合図
    public void TimerView_Finish()
    {
        StartCoroutine("TimerView_Finish_C");
    }
    //スタートの合図
    IEnumerator TimerView_Start_C()
    {
        timewatch.text = "スタート";
        yield return new WaitForSeconds(1);
        controllcs.Game_situation = 2;
    }
    //おわりの合図
    IEnumerator TimerView_Finish_C()
    {
        timewatch.text = "オワリ";
        yield return new WaitForSeconds(1);
        controllcs.Game_situation = 4;
    }

    //タイマーの計測はじめ
    public void TimerStart()
    {
        starttime = Time.time;
    }

    //タイマーの表示
    public void TimerCanvas()
    {
        timer = Mathf.Ceil(starttime + MaxTime - Time.time);
        timewatch.text = "ノコリ　" +　timer.ToString() + "　ビョウ";
        if(timer == 0)
        {
            controllcs.Game_situation = 3;
        }
    }
}
