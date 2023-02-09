using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro counterText;
    [SerializeField] private Transform runnersParent;

    void Start()
    {
        
    }

    void Update()
    {
        counterText.text = runnersParent.childCount.ToString();

        if (runnersParent.childCount <=0)
        {
            Destroy(gameObject);
        }
    }
}
