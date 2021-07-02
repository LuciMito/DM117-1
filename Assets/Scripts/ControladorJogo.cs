using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para controlar a parte principal do jogo
/// </summary>

public class ControladorJogo : MonoBehaviour {

    [Tooltip("Referencia para o TileBasico")]
    public Transform tile;

    [Tooltip("Ponto para se colocar o TileBasicoInicial")]
    public Vector3 pontoInicial = new Vector3(0, 0, -5);

    [Tooltip("Quantidade de Tiles iniciais")]
    [Range(1, 20)]
    public int numSpawnIni;

    /// <summary>
    /// Local para spawn do proximo Tile
    /// </summary>
    private Vector3 proxTilePos;

    /// <summary>
    /// Rotacao do proximo Tile
    /// </summary>
    private Quaternion proxTileRot;

    void Start(){

        // Preparando o ponto incial
        proxTilePos = pontoInicial;
        proxTileRot = Quaternion.identity;

        for(int i=0; i<numSpawnIni; i++) {

            SpawnProxTile();

        }

    }

    public void SpawnProxTile() {

        var novoTile = Instantiate(tile, proxTilePos, proxTileRot);

        //Detectar qual o local de spawn do prox tile
        var proxTile = novoTile.Find("PontoSpawn");
        proxTilePos = proxTile.position;
        proxTileRot = proxTile.rotation;

    }

}
