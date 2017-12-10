using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour {

    public float currentHealth;
    public float maxHeath;

    private void Start()
    {
        currentHealth = maxHeath;
    }
}
