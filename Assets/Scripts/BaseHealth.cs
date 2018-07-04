using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{

    [SerializeField] private int baseHealth = 10;
    [SerializeField] private Text healthText;

    void Start()
    {
        healthText.text = baseHealth.ToString();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        baseHealth -= 1;
        healthText.text = baseHealth.ToString();
    }
}
