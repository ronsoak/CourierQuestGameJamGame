using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreator : MonoBehaviour
{
    // Variables
    [Header("Objects")]
    public Transform cloudPrefab;
    private float waitNum = 3f;
    private float spawnNum = 1f;
    private int spawCount = 1;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(cloudPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        StartCoroutine(CloudSpawner());
        
    }

    // Update is called once per frame
    void Update()
    {
        waitNum = Random.Range(3, 11);
        spawnNum = Random.Range(1, 3);

        
    }

    IEnumerator CloudSpawner()
    {
        while (true) // this makes it last forever
        {
            yield return new WaitForSeconds(waitNum);
            if(spawnNum == 1)
            {
                var newCloud = Instantiate(cloudPrefab, new Vector3(10f, 3f, 0f), Quaternion.identity);
                newCloud.name = "SpeedCloud_"+ spawCount;
                spawCount++;
                Destroy(newCloud.gameObject, 12);                

            }
            if (spawnNum == 2)
            {
                var newCloud = Instantiate(cloudPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity);
                newCloud.name = "SpeedCloud_" + spawCount;
                spawCount++;
                Destroy(newCloud.gameObject, 12);

            }
            if (spawnNum == 3)
            {
                var newCloud = Instantiate(cloudPrefab, new Vector3(10f, -3f, 0f), Quaternion.identity);
                newCloud.name = "SpeedCloud_" + spawCount;
                spawCount++;
                Destroy(newCloud.gameObject, 12);

            }

        }
    }

    IEnumerator killCloud(GameObject cloudName)
    {
        yield return new WaitForSeconds(3);
        Destroy(cloudName);
    }
}
