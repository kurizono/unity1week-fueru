using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Itemdrop : MonoBehaviour
{
    public GameObject[] item;
    private int item_sorse;
    public GameObject brack;

    //マップの広さ(±100×±100) 
    float[] mapscale = new float[2] { 600, 600 };
    //落とすアイテムの数
    int item_sum = 10000;
    Vector3 item_posi;
    //落とすブラックホールの数
    int brack_sum = 1000;

    private void Awake()
    {
        item = GameData.item;
        item_sorse = GameData.item.Length;
        Item_set(item_sum);
    }

    //アイテムを設置する
    void Item_set(int dropitem)
    { 
        for(int i = 0; i < dropitem; i++)
        {
            int itemitem = Random.Range(0, item_sorse);
            Item_make(item[itemitem]);
        }
        for(int i = 0; i < brack_sum; i++)
        {
            Item_make(brack);
        }
    }
    public void Item_make(GameObject choose)
    {
        item_posi = new Vector3(Random.Range(-mapscale[0], mapscale[0]), Random.Range(-mapscale[1], mapscale[1]), 0);
        Instantiate(choose, item_posi, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
}
