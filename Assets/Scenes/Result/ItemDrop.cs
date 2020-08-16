using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] item;

    //落とす広さ 
    float mapscale =  2;
    //落とす中心
    Vector3 mapcore = new Vector3(6, 0, 0);

    Vector3 item_posi;

    // Start is called before the first frame update
    void Start()
    {
        item = GameData.item;
    }

    public void Cat_ItemDrop(int catnum)
    {
        //アイテムの種類
        for(int i = 0; i < GameData.item.Length; i++)
        {
            //そのアイテムの数
            for (int j = 0; j < GameData.itemcount[catnum, i]; j++)
            {
                Item_make(i);
            }
        }
    }

    public void Item_make(int choose)
    {
        item_posi = new Vector3(Random.Range(-mapscale, mapscale) + mapcore.x, Random.Range(-mapscale, mapscale) + mapcore.y, 0 + mapcore.z);
        Instantiate(item[choose], item_posi, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

}
