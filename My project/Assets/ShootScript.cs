using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
	[SerializeField] GameObject PinPrefab;
	[SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot(float x, float y){

	Vector2 position = new Vector2(x, y);
	Instantiate(PinPrefab, position, Quaternion.identity);
	
    }
}
