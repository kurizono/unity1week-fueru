using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //ゲームで使うデータ
    public GameObject[] iteming = new GameObject[18];
    static public GameObject[] item;
    static public int[] itemnum;
    static public int[,] itemcount;

    private void Start()
    {
        item = iteming;
        itemnum = new int[iteming.Length];
        itemcount = new int[4, iteming.Length];
    }
}
