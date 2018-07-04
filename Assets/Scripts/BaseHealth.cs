using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{

    [SerializeField] private int baseHealth = 10;

    private void OnTriggerEnter(Collider other)
    {
        baseHealth -= 1;
        print("Base health is: " + baseHealth);
    }
}
