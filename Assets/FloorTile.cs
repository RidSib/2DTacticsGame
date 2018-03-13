using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorTile : MonoBehaviour {

    public int x, y;

    private void OnMouseDown()
    {
            GameObject text = GameObject.Find("Info");

            Text t2 = (Text)text.GetComponent(typeof(Text));
            t2.text += "\nClicked on "+ x + ", " + y;
    }
}
