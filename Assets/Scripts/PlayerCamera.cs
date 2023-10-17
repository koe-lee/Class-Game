using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform[] playerTransforms;
    private float xMin, xMax;

    public float minDistance = 7.5f;
    private void Start()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        playerTransforms = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            playerTransforms[i] = allPlayers[i].transform;
        }
    }
    private void LateUpdate()
    {
        if(playerTransforms.Length == 0)
        {
            Debug.Log("No player found, ensure player tag is set to 'Player'");
            return;
        }
        xMin = xMax = playerTransforms[0].position.x;
        for(int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.x < xMin)
                xMin = playerTransforms[i].position.x;
            if (playerTransforms[i].position.x > xMax)
                xMax = playerTransforms[i].position.x;
        }
        float xMiddle = (xMin + xMax) / 2;
        float distance = xMax - xMin;
        if (distance < minDistance)
            distance = minDistance;

        transform.position = new Vector3(xMiddle, distance/2, -distance);
    }
    
}
