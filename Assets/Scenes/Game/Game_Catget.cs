using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Catget : MonoBehaviour
{
    public GameObject gameobject;
    Game_Itemdrop Itemdropcs;
    Game_Itemcount Itemcountcs;
    

    // Start is called before the first frame update
    void Start()
    {
        Itemdropcs = gameobject.GetComponent<Game_Itemdrop>();
        Itemcountcs = gameobject.GetComponent<Game_Itemcount>();
    }

    private void OnTriggerEnter2D(Collider2D cat)
    {
        Itemcountcs.Itemget(cat.gameObject.name);
    }
}
