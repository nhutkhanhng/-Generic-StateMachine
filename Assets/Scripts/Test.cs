using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public CStateController controller;
    public CCharacter Data;
    // Start is called before the first frame update
    void Start()
    {
        controller?.Init(Data);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Data.A = 5;
        }
    }
}
