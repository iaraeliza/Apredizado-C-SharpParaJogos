using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MaiorNumero : MonoBehaviour
{
   [SerializeField] int a, b, c;
  
    void Start()
    {
        List<int> lista = new List<int> { a, b, c };
        int maiorValor = lista.Max();
        Debug.Log($"O maior número é : {maiorValor}");
    }

}
