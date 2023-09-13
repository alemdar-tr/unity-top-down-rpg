using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class setdepth : MonoBehaviour
{
    public int maxdepth;
    // Start is called before the first frame update
    void Start()
    {
        Recursion.defaultMaxDepth = maxdepth;
        Debug.Log(Recursion.defaultMaxDepth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
