using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ねこの一つ一つに付ける
public class Game_Catget : MonoBehaviour
{
    public GameObject gameobject, dontdestroygameobject;
    Game_Itemdrop Itemdropcs;
    Game_Itemcount Itemcountcs;

    AudioSource source;
    public AudioClip catsound;

    int mycatint;

    // Start is called before the first frame update
    void Start()
    {
        Itemdropcs = gameobject.GetComponent<Game_Itemdrop>();
        Itemcountcs = dontdestroygameobject.GetComponent<Game_Itemcount>();
        source = GetComponent<AudioSource>();

        string mycatname = transform.name;
        switch (mycatname)
        {
            case "PlayerCat1":
                mycatint = 0;
                break;
            case "PlayerCat2":
                mycatint = 1;
                break;
            case "PlayerCat3":
                mycatint = 2;
                break;
            case "PlayerCat4":
                mycatint = 3;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D cat)
    {
        Itemcountcs.Itemget(cat.gameObject.tag , mycatint);
        if(cat.gameObject.tag == "blackhole")
        {
            source.PlayOneShot(catsound);
            StartCoroutine("catroll");
        }
    }

    IEnumerator catroll()
    {
        float time = Time.time;
        while (Time.time - time < 1 )
        {
            this.gameObject.transform.eulerAngles = new Vector3(0,0, (Time.time - time)*360);
            yield return null;
        }
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }

}
