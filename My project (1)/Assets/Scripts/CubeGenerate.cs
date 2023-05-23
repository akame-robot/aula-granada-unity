using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerate : MonoBehaviour
{

    public GameObject boardPrefab; //prefab para instanciar os cubos
    public int boardSize = 8;  // tamanho do tabuleiro

    void Start()
    {
        CreateChessboard();
    }

    void CreateChessboard()
    {
        // Loop para criar as células do tabuleiro
        for (int horiz = 0; horiz < boardSize; horiz++)
        {
            for (int vertic = 0; vertic < boardSize; vertic++)
            {

                // Instancia um cubo usando o prefab fornecido, definindo sua posição e rotação
                GameObject tile = Instantiate(boardPrefab, new Vector3(horiz, vertic, 0), Quaternion.identity);

                // Define o objeto pai do cubo como o transform atual (provavelmente o objeto que possui esse script)
                tile.transform.SetParent(transform);

                // Define a cor do material do cubo com base na posição da célula
                if ((horiz + vertic) % 2 == 0)
                {
                    tile.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    tile.GetComponent<Renderer>().material.color = Color.black;
                }
            }
        }
    }

}
