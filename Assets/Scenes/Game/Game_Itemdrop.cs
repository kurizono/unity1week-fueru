using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Itemdrop : MonoBehaviour
{
    public GameObject[] item = new GameObject[10];
    public int item_sorse = 10;
    public GameObject barun;

    //マップの広さ(±100×±100) 
    float[] mapscale = new float[2] { 1000, 1000 };
    //落とすアイテムの数
    int item_sum = 10000;
    Vector3[] item_posi;
    //落とすバルンの数
    //int barun_sum = 1;

    void Start()
    {
        Item_set();
    }


    //アイテムを設置する
    void Item_set()
    {
        item_posi = new Vector3[item_sum];
        for(int i = 0; i < item_sum; i++)
        {
            item_posi[i] = new Vector3(Random.Range(-mapscale[0],mapscale[0]), Random.Range(-mapscale[1], mapscale[1]), 0);
            Instantiate(item[Random.Range(0,item_sorse - 1)], item_posi[i], Quaternion.identity);
        }
    }
}
