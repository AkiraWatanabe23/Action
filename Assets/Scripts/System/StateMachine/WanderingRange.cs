using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingRange : MonoBehaviour
{
    /// <summary> 円周を計算する </summary>
    public float SetCircumference(int radius)
    {
        return 2 * radius * Mathf.PI;
    }

    private void OnGUI()
    {
        
    }
}
