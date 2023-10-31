using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWater : MonoBehaviour
{
    [Header("���ٱ� �±�")]
    public string water_tag;
    [Header("����")]
    public Pot pot;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(water_tag))
        {
            pot.Fill();
        }
    }
}
