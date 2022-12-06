using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    [SerializeField]
    GameObject cubePrefab;

    [SerializeField]
    GameObject cubeBorder;

    [SerializeField]
    int terrainSizeBorder;


    [SerializeField]
    int terrainSize;
    void Start()
    {   //Instanciando Cubos do Centro
        for (int column = 0; column < terrainSize; column++)
        {
            for (int line = 0; line < terrainSize; line++)
            {

                int randomHeight = Random.Range(1, 5);

                for (int heigth = 0; heigth < randomHeight; heigth++)

                    Instantiate(cubePrefab, new Vector3(line, heigth, column), Quaternion.identity);

                //Instanciando Cubos da Borda

                
                if (line == 0 || column == 0 || line == terrainSize - 1 || column == terrainSize - 1)
                {
                    for (int heigthBorder = 0; heigthBorder < 6; heigthBorder++)
                        cubeBorderDestroy.Add(Instantiate(cubeBorder, new Vector3(line, heigthBorder, column), Quaternion.identity));
                }
            }
        }
    }
    
    //Destruindo cubos da borda
    List<GameObject> cubeBorderDestroy = new List<GameObject>();
	void Update()
    { 

        if (Input.GetKeyDown(KeyCode.A))
	{ 
            {
                Destroy(cubeBorderDestroy[0]);
                cubeBorderDestroy.RemoveAt(0);

                Destroy(cubeBorderDestroy[cubeBorderDestroy.Count - 1]);
                cubeBorderDestroy.RemoveAt(cubeBorderDestroy.Count - 1);
            }

	}

    }
}
