using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_CameraMove : MonoBehaviour
{
    //初期カメラ位置(±10.25,　±5.75, -10.0)
    //ゲーム開始カメラ位置

    Game_Controll controllcs;

    public GameObject player;
    public GameObject rightup_camera, leftup_camera, rightdown_camera, leftdown_camera;

    Dictionary<string, Vector3> cameraposi = new Dictionary<string, Vector3>()
    {
        {"rightup_first", new Vector3(10.25f, 5.75f, -10)},
        {"rightup_finish", new Vector3(20.5f, 11.5f, -10)},
        {"leftup_first", new Vector3(-10.25f, 5.75f, -10)},
        {"leftup_finish", new Vector3(-20.5f, 11.5f, -10) },
        {"rightdown_first", new Vector3(10.25f, -5.75f, -10)},
        {"rightdown_finish", new Vector3(20.5f, -11.5f, -10)},
        {"leftdown_first", new Vector3(-10.25f, -5.75f, -10)},
        {"leftdown_finish", new Vector3(-20.5f, -11.5f, -10)},
    };

    //時間制御
    float time_maneger = 0;
    //リアルタイム制御
    float realtime_maneger = 0;
    //待ち時間
    float wait_time = 1.0f;

    //最初のムービーの秒数
    float movie_second = 1.0f;
    //動く速度
    float move_speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        controllcs = GetComponent<Game_Controll>();

        Camera_startposi();
        StartCoroutine("Camera_move");
    }
    
    public void Main_Firstmove()
    {
        time_maneger += Time.deltaTime;
    }

    //最初のカメラの位置
    void Camera_startposi()
    {
        rightup_camera.transform.localPosition = cameraposi["rightup_first"];
        leftup_camera.transform.localPosition = cameraposi["leftup_first"];
        rightdown_camera.transform.localPosition = cameraposi["rightdown_first"];
        leftdown_camera.transform.localPosition = cameraposi["leftdown_first"];
    }

    //カメラをはじめに動かす(ver.2)
    IEnumerator Camera_move()
    {
        yield return new WaitForSeconds(wait_time);
        realtime_maneger = Time.time;
        while(Time.time - realtime_maneger < movie_second)
        {
            rightup_camera.transform.localPosition = cameraposi["rightup_first"] + (cameraposi["rightup_finish"] - cameraposi["rightup_first"]) * (Time.time - realtime_maneger) / movie_second;
            leftup_camera.transform.localPosition = cameraposi["leftup_first"] + (cameraposi["leftup_finish"] - cameraposi["leftup_first"]) * (Time.time - realtime_maneger) / movie_second;
            rightdown_camera.transform.localPosition = cameraposi["rightdown_first"] + (cameraposi["rightdown_finish"] - cameraposi["rightdown_first"]) * (Time.time - realtime_maneger) / movie_second;
            leftdown_camera.transform.localPosition = cameraposi["leftdown_first"] + (cameraposi["leftdown_finish"] - cameraposi["leftdown_first"]) * (Time.time - realtime_maneger) / movie_second;
            yield return null;
        }

        rightup_camera.transform.localPosition = cameraposi["rightup_finish"];
        leftup_camera.transform.localPosition = cameraposi["leftup_finish"];
        rightdown_camera.transform.localPosition = cameraposi["rightdown_finish"];
        leftdown_camera.transform.localPosition = cameraposi["leftdown_finish"];
        controllcs.Game_situation = 1;
    }

    //カメラを十字キーで動かす
    public void Main_Player_moving()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += new Vector3(0, move_speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position += new Vector3(0, -move_speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position += new Vector3(move_speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position += new Vector3(-move_speed, 0, 0) * Time.deltaTime;
        }
    }
}
