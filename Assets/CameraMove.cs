using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //初期カメラ位置(±10.25,　±5.75, -10.0)
    //ゲーム開始カメラ位置

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

    //最初のムービーの秒数
    float movie_second = 2.0f;
    //動く速度
    float move_speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Camera_startposi();
    }

    // Update is called once per frame
    void Update()
    {
        Player_moving();
    }

    void Camera_startposi()
    {
        rightup_camera.transform.localPosition = cameraposi["rightup_first"];
        leftup_camera.transform.localPosition = cameraposi["leftup_first"];
        rightdown_camera.transform.localPosition = cameraposi["rightdown_first"];
        leftdown_camera.transform.localPosition = cameraposi["leftdown_first"];
    }

    void Camera_moving()
    {
        int a = 0;
        while(a == 0)
        {
            rightup_camera.transform.localPosition += (cameraposi["rightup_first"] - cameraposi["rightup_finish"])/movie_second;
            leftup_camera.transform.localPosition += (cameraposi["leftup_first"] - cameraposi["leftup_finish"]);
            rightdown_camera.transform.localPosition += (cameraposi["rightdown_first"] - cameraposi["rightdown_finish"])/movie_second;
            leftdown_camera.transform.localPosition += (cameraposi["leftdown_first"] - cameraposi["leftdown_finish"])/movie_second;
        }
        rightup_camera.transform.localPosition = cameraposi["rightup_finish"];
        leftup_camera.transform.localPosition = cameraposi["leftup_finish"];
        rightdown_camera.transform.localPosition = cameraposi["rightdown_finish"];
        leftdown_camera.transform.localPosition = cameraposi["leftdown_finish"];
    }

    //カメラを十字キーで動かす
    void Player_moving()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += new Vector3(0, move_speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position += new Vector3(0, -move_speed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position += new Vector3(move_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position += new Vector3(move_speed, 0, 0);
        }
    }
}
