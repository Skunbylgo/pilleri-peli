using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Update(17);
    }

    // Update is called once per frame
    void Update(int n)
    {
        int a = 0, b = 1;

        for (int i = 0; i < n; i++)
        {
            Debug.Log(a);
            int temp = a;
            a = b;
            b = temp + b;
        }
    }
}
