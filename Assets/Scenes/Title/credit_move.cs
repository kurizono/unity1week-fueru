using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credit_move : MonoBehaviour
{
    public GameObject credit;

    // Start is called before the first frame update
    void Start()
    {
        credit.SetActive(false);
    }

    public void Credit_Active(bool check)
    {
        credit.SetActive(check);
    }
}
