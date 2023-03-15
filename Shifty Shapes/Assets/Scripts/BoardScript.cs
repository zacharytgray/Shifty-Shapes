using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoardScript : MonoBehaviour
{

    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;

    public TilesScript[] tiles; 
    private int emtpySpaceIndex = 24;

    public TilesScript[] solution;

    private float timeRemaining;


    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        ScrambleBoard();

        for(int i = 0; i < tiles.Length; i++) {
            if (tiles[i] != null) tiles[i].ID = i;
        }


        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0)) {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); // returns true when raycast hits an object
            if (hit) {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 2.5) {
                    Vector2 lastEmptySpacePosition = emptySpace.position;

                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();

                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    

                    TilesScript temp = tiles[emtpySpaceIndex];
                    tiles[emtpySpaceIndex] = tiles[thisTile.ID]; //swap tiles in array
                    tiles[thisTile.ID] = temp;
                    emtpySpaceIndex = thisTile.ID;

                    for(int i = 0; i < tiles.Length; i++) {
                        if (tiles[i] != null) tiles[i].ID = i;
                    }
                    
                    
                }


            }
        }

        timeRemaining = PlayerPrefs.GetFloat("timeRemaining");

        if (timeRemaining <= 0) {
            PlayerPrefs.SetFloat("timeRemaining", 10f);
            SceneManager.LoadScene(4);
        }
        
        else if (checkSolved()) { 

            float highScoreValue = PlayerPrefs.GetInt("highScoreValue");
            float time = PlayerPrefs.GetInt("timeLimit") - timeRemaining;
            PlayerPrefs.SetFloat("Time", time);

            if (timeRemaining > highScoreValue) {
                PlayerPrefs.SetFloat("highScoreValue", time);
            }

            SceneManager.LoadScene(3);

        }

    }

    public void ScrambleBoard() {
        for(int i = 0; i < 24; i++) {
            var lastPos = tiles[i].targetPosition;
            int randomIndex = Random.Range(0,23);
            tiles[i].targetPosition = tiles[randomIndex].targetPosition;
            tiles[randomIndex].targetPosition = lastPos;

            TilesScript temp = tiles[i];
            tiles[i] = tiles[randomIndex]; //swap tiles in array
            tiles[randomIndex] = temp;
        }
    }

    public bool checkSolved() {

    
        if (tiles[6] == null || (solution[0].GetComponent<Renderer>().material.color != tiles[6].GetComponent<Renderer>().material.color)) {
            return false;
        }
        if (tiles[7] == null || (solution[1].GetComponent<Renderer>().material.color != tiles[7].GetComponent<Renderer>().material.color)) {
            return false;
        }
        if (tiles[8] == null || (solution[2].GetComponent<Renderer>().material.color != tiles[8].GetComponent<Renderer>().material.color)) {
            return false;
        }

        if (tiles[11] == null || (solution[3].GetComponent<Renderer>().material.color != tiles[11].GetComponent<Renderer>().material.color)) {
            return false;
        }
        if (tiles[12] == null || (solution[4].GetComponent<Renderer>().material.color != tiles[12].GetComponent<Renderer>().material.color)) {
            return false;
        }
        if (tiles[13] == null || (solution[5].GetComponent<Renderer>().material.color != tiles[13].GetComponent<Renderer>().material.color)) {
            return false;
        }

        if (tiles[16] == null || (solution[6].GetComponent<Renderer>().material.color != tiles[16].GetComponent<Renderer>().material.color)) {
            return false;
        }
        if (tiles[17] == null || (solution[7].GetComponent<Renderer>().material.color != tiles[17].GetComponent<Renderer>().material.color)) {
            return false;
        }
        if (tiles[18] == null || (solution[8].GetComponent<Renderer>().material.color != tiles[18].GetComponent<Renderer>().material.color)) {
            return false;
        }
        return true;
        




    }
}
