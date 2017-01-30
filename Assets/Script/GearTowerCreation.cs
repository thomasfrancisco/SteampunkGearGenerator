using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTowerCreation : MonoBehaviour {

    public int height = 0;
    public Vector2 speedMinMax;
    public float shiftMax;
    public Transform gearTower;

    private BoxCollider coll;
    private float ownSpeed;
    


	// Use this for initialization
	void Start () {
        Destroy(GetComponent<MeshRenderer>());
        coll = GetComponent<BoxCollider>();
        for (int i=0; i < height; i++)
        {
            GameObject obj = Instantiate(gearTower.gameObject);
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-shiftMax, shiftMax), i * coll.size.y, transform.position.z + Random.Range(-shiftMax, shiftMax));
            obj.GetComponent<RotateGear>().speed = Random.Range(speedMinMax.x, speedMinMax.y);
            obj.transform.localScale = transform.localScale;
        }
		
	}

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {
	}
}
