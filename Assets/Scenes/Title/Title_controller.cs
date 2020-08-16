using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_controller : MonoBehaviour
{
    story_move movecs;
    explain_move explaincs;
    credit_move creditcs;

    public Button Button_start, Button_story, Button_collect, Button_explain, Button_credit;
    public Button Button_arrow, Button_exarrow, Button_return;
    //start, story, example, library, credit

    public GameObject next_arrow, return_arrow, ex_arrow;

    public float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        movecs = GetComponent<story_move>();
        explaincs = GetComponent<explain_move>();
        creditcs = GetComponent<credit_move>();

        next_arrow.SetActive(false);
        ex_arrow.SetActive(false);
        return_arrow.SetActive(false);

        Button_start.onClick.AddListener(Button_start_Click);
        Button_story.onClick.AddListener(Button_story_Click);
        Button_collect.onClick.AddListener(Button_collect_Click);
        Button_explain.onClick.AddListener(Button_explain_Click);
        Button_credit.onClick.AddListener(Button_credit_Click);

        Button_arrow.onClick.AddListener(Button_arrow_Click);
        Button_exarrow.onClick.AddListener(Button_exarrow_Click);
        Button_return.onClick.AddListener(Button_return_Click);
    }

    // Update is called once per frame
    void Update()
    {
        movecs.Storymove();
        explaincs.Storymove();
        nowtime += Time.deltaTime;
    }

    private void Button_start_Click()
    {
        SceneManager.LoadScene("Game");
    }

    private void Button_story_Click()
    {
        movecs.Story_Button();
        next_arrow.SetActive(true);
        Button_NoActive();
    }

    private void Button_collect_Click()
    {
        SceneManager.LoadScene("Collection");
    }

    private void Button_explain_Click()
    {
        explaincs.Story_Button();
        ex_arrow.SetActive(true);
        Button_NoActive();
    }

    private void Button_credit_Click()
    {
        creditcs.Credit_Active(true);
        return_arrow.SetActive(true);
        Button_NoActive();
    }

    private void Button_arrow_Click()
    {
        movecs.Story_Button();
        if (movecs.papernum == movecs.PaperstoryNum)
        {
            next_arrow.SetActive(false);
            Button_YesActive();
        }
    }

    private void Button_exarrow_Click()
    {
        explaincs.Story_Button();
        if (explaincs.papernum == explaincs.PaperstoryNum)
        {
            ex_arrow.SetActive(false);
            Button_YesActive();
        }
    }

    private void Button_return_Click()
    {
        creditcs.Credit_Active(false);
        return_arrow.SetActive(false);
        Button_YesActive();
    }

    private void Button_YesActive()
    {
        Button_start.interactable = true;
        Button_story.interactable = true;
        Button_collect.interactable = true;
        Button_explain.interactable = true;
        Button_credit.interactable = true;
    }

    private void Button_NoActive()
    {
        Button_start.interactable = false;
        Button_story.interactable = false;
        Button_collect.interactable = false;
        Button_explain.interactable = false;
        Button_credit.interactable = false;
    }
}
