using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MaiorNumero : MonoBehaviour
{
    [SerializeField] int numb1;
    [SerializeField] int numb2;

    void Start()
    {
        
        if (numb1 > numb2)
		{
            Debug.Log($"Number: {numb1}");
		}
        else
		{
            Debug.Log($"Number: {numb2}");
        };
    
    }
}