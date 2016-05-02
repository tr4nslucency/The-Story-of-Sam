using UnityEngine;
using System.Collections;

public class OrderInLayer : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer tempRend;

    public bool runOnlyAtStart;

	void Start () {
		tempRend = GetComponent<SpriteRenderer>();

        if (runOnlyAtStart)
        {
            SetOrderInLayer(transform.position.y);
        }

	}


	void LateUpdate () {

        if (!runOnlyAtStart)
        {
            SetOrderInLayer(transform.position.y);
            // (int)Camera.main.WorldToScreenPoint (tempRend.bounds.min).y * -10;
            // Debug.Log(tempRend.sortingOrder);
        }
	}

	void SetOrderInLayer (float input_y) {
		float y_pos = transform.position.y;
		int orderInLayer;
		orderInLayer = (int)(y_pos * (-20));
		tempRend.sortingOrder = orderInLayer;
		// Debug.Log (orderInLayer);
	}

}
