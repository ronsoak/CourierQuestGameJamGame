using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallpaperScroller : MonoBehaviour
{
    // Variables
    public float scrollSpeed = .5f;
    private float offSet;
    private Material backMat;
    GameProgress gameprog;

    // Start is called before the first frame update
    void Start()
    {
        backMat = GetComponent<Renderer>().material;
        ShipMovement.CollissionEvent += IncreaseSpeed; // listens for event.

        gameprog = GameObject.FindObjectOfType<GameProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        offSet += (Time.deltaTime * scrollSpeed) / 10f;
        backMat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }

    private void IncreaseSpeed()
    {
        //scrollSpeed = scrollSpeed * 2;
        //ShipMovement.CollissionEvent -= IncreaseSpeed; //unsibscribes from event.

        StartCoroutine(boostSpeed());
    }

    IEnumerator boostSpeed()
    {
        scrollSpeed = scrollSpeed * 2;
        gameprog.ChangeSpeedCounter(true); // doubles the tracker that is countind down
        yield return new WaitForSeconds(2f);
        scrollSpeed = scrollSpeed / 2;
        gameprog.ChangeSpeedCounter(false);
    }
}
