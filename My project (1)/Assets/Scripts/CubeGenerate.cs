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
                GameObject tile = Instantiate(boardPrefab, new Vector3(horiz, 0, vertic), Quaternion.identity);
                // Define o objeto pai do cubo como o transform atual (provavelmente o objeto que possui esse script)
                tile.transform.SetParent(transform);

                // Verifica se a célula está em uma linha horizontal par ou ímpar e em uma coluna vertical par ou ímpar
                bool isOnHoriz = horiz % 2 == 0;
                bool isOnVertic = vertic % 2 == 0;

                // Define a cor do material do cubo com base na posição da célula
                if ((isOnHoriz && isOnVertic) || (!isOnHoriz && !isOnVertic))
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
