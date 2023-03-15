using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubies : MonoBehaviour
{

    public TilesScript[] cubies; 
    [SerializeField] private Material[] materials;

    private int[] picks = {0, 0, 0, 0, 0, 0}; //used to ensure one color isn't picked >4 times
    
    // Start is called before the first frame update
    void Start()
    {
        ScrambleModel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScrambleModel() {
        for(int i = 0; i <= 8; i++) {

            bool flag = false;
            while (!flag) {

                int randomIndex = Random.Range(0,6);
                picks[randomIndex] ++;

                if (picks[randomIndex] <= 4) {
                    flag = true;
                    Material m = materials[randomIndex];
                    cubies[i].GetComponent<Renderer>().material = m;
                }

            }
        }
    }

    public TilesScript[] getSolution() {
        return cubies;
    }
}
