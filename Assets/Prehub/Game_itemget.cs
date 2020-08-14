using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_itemget : MonoBehaviour
{
    //ねこにぶつかったら消滅する
    private void OnTriggerEnter2D(Collider2D cat)
    {
        if (cat.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
