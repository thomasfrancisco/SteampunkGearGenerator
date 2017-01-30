using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteampunkWallGenerator : MonoBehaviour {

    public int numberOfGears;
    public Transform gear;
    public Transform structureMesh;
    public Material gearMaterial;
    public Vector2 scaleMinMax;
    public Vector2 speedMinMax;

    private BoxCollider col;
    private MeshRenderer mesh;

	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider>();
        mesh = GetComponent<MeshRenderer>();
        //Destroy(mesh);

        for(int i = 0; i < numberOfGears; i++)
        {
            //Random Position inside the bounds
            float randX = Random.Range(col.bounds.min.x, col.bounds.max.x);
            float randY = Random.Range(col.bounds.min.y, col.bounds.max.y);
            float randZ = Random.Range(col.bounds.min.z, col.bounds.max.z);
            
            GameObject obj = Instantiate(gear.gameObject, new Vector3(randX, randY, randZ), transform.localRotation);

            //Random rotation speed
            obj.AddComponent<RotateGear>();
            obj.GetComponent<RotateGear>().speed = Random.Range(speedMinMax.x, speedMinMax.y);

            //Random scale
            float scale = Random.Range(scaleMinMax.x, scaleMinMax.y);
            obj.transform.localScale = new Vector3(scale, scale, 1);

            //give Material
            obj.GetComponent<Renderer>().material = gearMaterial;
            
            
        }
        
	}
    
	// Update is called once per frame
	void Update () {


	}
}
