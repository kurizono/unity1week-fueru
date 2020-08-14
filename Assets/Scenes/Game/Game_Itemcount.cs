using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Itemcount : MonoBehaviour
{
    Game_Itemdrop Itemdropcs;

    int[] Item_num;

    // Start is called before the first frame update
    void Start()
    {
        Itemdropcs = GetComponent<Game_Itemdrop>();

        //アイテムの数をカウント
        Item_num = new int[Itemdropcs.item_sorse];
    }

    public void Itemget(string Itemname)
    {
        for(int i = 0; i < Itemdropcs.item_sorse; i++)
        {
            if(Itemname == Itemdropcs.item[i].name)
            {
                Item_num[i]++;
                break;
            }
        }
    }
}
