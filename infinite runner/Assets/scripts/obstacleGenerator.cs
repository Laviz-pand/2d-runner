using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] roadPrefabs;
    float spawn = 0;
    [SerializeField]
    float roadLen = 20;
    float numofroad = 5;
    
    List<GameObject> activeroadlist = new List<GameObject>();

    [SerializeField]
    Transform player;

    void Start(){
        for (int i = 0; i < numofroad ; i++)
        {
            if (i==0)
            {
                InstantiateRoad(0);
            }
            else
            {
                InstantiateRoad(Random.Range(0, roadPrefabs.Length));
            }
        }
    }

    void Update(){
        if (player.position.x - 35 > spawn - (numofroad * roadLen))
        {
           InstantiateRoad(Random.Range(0, roadPrefabs.Length)); 
           DeleteRoad();
        }
        
    }

    public void InstantiateRoad(int index){
        GameObject activeroad = Instantiate(roadPrefabs[index], transform.right * spawn, transform.rotation);
        activeroadlist.Add(activeroad);
        spawn += roadLen;
    }

    void DeleteRoad(){
        Destroy(activeroadlist[0]);
        activeroadlist.RemoveAt(0);
    }
}
