using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    
    public float minX = -10;
    public float MaxX = 10;

    public float minZ = -10;
    public float MaxZ = 10;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX,MaxX), Random.Range(minZ,MaxZ));
        Vector3 SpawnPosition = new Vector3(randomPosition.x + transform.position.x, transform.position.y, randomPosition.y + transform.position.z);
        PhotonNetwork.Instantiate(playerPrefab.name, SpawnPosition,Quaternion.identity);
    }


}
