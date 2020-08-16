using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Itemcount : MonoBehaviour
{
    public GameObject gameobject;
    Game_Itemdrop Itemdropcs;

    int Item_sum = 0;

    // Start is called before the first frame update
    void Start()
    {
        Itemdropcs = gameobject.GetComponent<Game_Itemdrop>();
        Itemcount_reset();
    }

    public void Itemcount_reset()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < GameData.item.Length; j++)
            {
                GameData.itemcount[i, j] = 0;
            }           
        }
    }

    //アイテムを手に入れた時の動作
    public void Itemget(string Itemtag, int catnum)
    {
        //当たったのがブラックホールなら
        if (Itemtag == Itemdropcs.brack.tag)
        {
            Item_sum = 0;
            //アイテムの半分を飛ばす
            for(int j = 0; j < GameData.item.Length; j++)
            {
                Item_sum += GameData.itemcount[catnum, j];
                GameData.itemcount[catnum, j] -= Item_sum / 2;
                for(int m = 0; m < Item_sum/2; m++)
                {
                    Itemdropcs.Item_make(Itemdropcs.item[j]);
                }
                Item_sum = Item_sum / 2;
            }
        }
        //当たったのがブラックホールでないのなら
        else {
            for (int i = 0; i < GameData.item.Length; i++)
            {
                //ここまでは通る
                if (Itemtag == Itemdropcs.item[i].tag)
                {
                    GameData.itemcount[catnum, i]++;
                    break;
                }
            }
        }
    }
}
