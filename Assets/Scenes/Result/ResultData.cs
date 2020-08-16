using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultData : MonoBehaviour
{

    public int[] GameItemNum;
    public int SumItem;

    private void Awake()
    {
        GameItemNum = new int[GameData.item.Length];
        SaveData();
        NowGameData();
    }
    void Start()
    {
        
    }

    //データを更新
    private void SaveData()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < GameData.item.Length; j++)
            {
                if(GameData.itemcount[i,j] > 0)
                {
                    GameData.itemnum[j] = 1;
                }
            }
        }
    }

    public void NowGameData()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < GameData.item.Length; j++)
            {
                GameItemNum[j] += GameData.itemcount[i, j];
                SumItem += GameData.itemcount[i, j];
            }
        }
    }
}
