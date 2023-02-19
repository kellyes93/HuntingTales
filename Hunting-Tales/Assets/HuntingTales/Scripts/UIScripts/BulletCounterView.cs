using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCounterView : MonoBehaviour
{
    public TextMeshProUGUI textBulletPro;
    public BulletCount currentBullets;
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = FindObjectOfType<BulletCount>();
    }

    // Update is called once per frame
    void Update()
    {
       textBulletPro.text = currentBullets.amountBullets.ToString("F0");
    }
}
