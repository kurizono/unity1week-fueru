using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_controller : MonoBehaviour
{
    story_move movecs;

    public Button Button_story;
    //start, story, example, library, credit
    int[] flug = new int[5];

    public float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        movecs = GetComponent<story_move>();
        Button_story.onClick.AddListener(Button_story_Click);
    }

    // Update is called once per frame
    void Update()
    {        

            movecs.Storymove();
        

        nowtime += Time.deltaTime;
    }

    private void Button_story_Click()
    {
        flug[1] = 1;
    }
}
