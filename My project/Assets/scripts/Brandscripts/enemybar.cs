using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemybar : MonoBehaviour
{

    Slider eslider;

    private void Awake()
    {
        eslider = GetComponent<Slider>();
    }

    public void SetSlide(int hp, int maxhp)
    {
        eslider.value = hp;
        eslider.maxValue = maxhp;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
