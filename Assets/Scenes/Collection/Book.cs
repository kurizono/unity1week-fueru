using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public Button Button_Left, Button_Right;

    public GameObject item;
    public GameObject[] items;

    int count = 0;
    public Text[] cattext = new Text[2];
    public Text No_label;

    //アイテムの位置関係
    float space = 100;
    Vector3 item_posi;

    List<string> catcoment1 = new List<string>
    {
        "えーがたのぱーつにゃ",
        "びーがたのぱーつにゃ",
        "おーがたのぱーつにゃ",
        "えーびーがたのぱーつにゃ",
        "おとこのからだにゃ",
        "むせいべつのからだにゃ",
        "おんなのからだにゃ",
        "ねこをおそうじしたにゃ",
        "しんせいなるねこすたんぷにゃ",
        "まぜまぜできるまぜまぜにゃ",
        "なにかをいれるふくろにゃ",
        "まっすぐなやじるしにゃ",
        "まがったやじるしにゃ",
        "なにかのすぺーすにゃ",
        "わくぐみというなのおりにゃ",
        "かみさまのなまえにゃ",
        "かこをふりかえるにゃ",
        "じゆうけんきゅうにゃ",
    };
    List<string> catcoment2 = new List<string>
    {
        "けつえきにいみはあるかにゃ？",
        "けつえきはただのじょうほうにゃ",
        "けつえきはてつのあじにゃ",
        "けつえきはオカルトにゃ",
        "おんなでげっとできるにゃ",
        "おとこでげっとできるにゃ？",
        "たぴおかでげっとできるにゃ",
        "ねこだってなにかにゃ",
        "ひかりかがやいてるにゃ",
        "ひとをまぜるあいてむにゃ",
        "ねこでももてるおおきさにゃ",
        "せかいじゅうでだいにんきにゃ",
        "こんじょうもまがってるにゃ",
        "なにかのためのなにかにゃ",
        "みんなこれにとらわれるにゃ",
        "かみさまふえたにゃ？",
        "ブラックホールぽいにゃ",
        "たのしかったにゃ"
    };
    string catnocoment1 = "しらないなにかにゃ";
    string catnocoment2 = "まだみつけてないにゃ";

    List<string> number_label = new List<string>
    {
        "ナンバー 01",
        "ナンバー 02",
        "ナンバー 03",
        "ナンバー 04",
        "ナンバー 05",
        "ナンバー 06",
        "ナンバー 07",
        "ナンバー 08",
        "ナンバー 09",
        "ナンバー 10",
        "ナンバー 11",
        "ナンバー 12",
        "ナンバー 13",
        "ナンバー 14",
        "ナンバー 15",
        "ナンバー 16",
        "ナンバー 17",
        "ナンバー 18",

    };

    // Start is called before the first frame update
    void Start()
    {
        First();
        BookRead();

        Button_Left.onClick.AddListener(BookLeftLook);
        Button_Right.onClick.AddListener(BookRightLook);
    }

    //最初に全て生成
    void First()
    {
        items = new GameObject[GameData.item.Length]; 
        for (int i = 0; i < GameData.item.Length; i++)
        {
            item_posi = new Vector3(i*space, 1.5f, 0);
            items[i] = Instantiate(GameData.item[i], item_posi, Quaternion.identity);
            items[i].transform.parent = item.transform;
        }
    }

    private void Update()
    {
        Booklook();
    }

    //次の図鑑に移るやつ(キーボード対応・常に回す)
    public void Booklook()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BookLeftLook();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BookRightLook();
        }
    }

    //左をみる
    public void BookLeftLook()
    {
        count = (count + items.Length - 1) % items.Length;
        BookRead();
    }
    //右を見る
    public void BookRightLook()
    {
        count = (count + 1) % items.Length;
        BookRead();
    }


    //本に載っているかどうかの判定
    private void BookRead()
    {
        if (GameData.itemnum[count] >= 1)
        {
            cattext[0].text = catcoment1[count];
            cattext[1].text = catcoment2[count];
            items[count].SetActive(true);
        }
        else
        {
            cattext[0].text = catnocoment1;
            cattext[1].text = catnocoment2;
            items[count].SetActive(false);
        }
        item.transform.position = new Vector3( count * (-space), item.transform.position.y, item.transform.position.z);
        No_label.text = number_label[count];
    }
}
