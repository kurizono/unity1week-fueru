using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controll : MonoBehaviour
{
    Game_CameraMove cameramovecs;
    Game_Timer timercs;

    //0:始まったばかり(プレイヤー移動できない)　1:ゲームスタート  2:ゲーム中　3:ゲーム終了
    public int Game_situation = 0;

    void Start()
    {
        cameramovecs = GetComponent<Game_CameraMove>();
        timercs = GetComponent<Game_Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Game_situation)
        {
            case 0:
                cameramovecs.Main_Firstmove();
                break;
            case 1:
                timercs.TimerStart();
                timercs.TimerView_Start();
                break;
            case 2:
                cameramovecs.Main_Player_moving();
                timercs.TimerCanvas();
                break;
            case 3:
                timercs.TimerView_Finish();
                break;
            case 4:
                SceneManager.LoadScene("Result");
                break;
        }
    }
}
