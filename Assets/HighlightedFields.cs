using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightedFields : MonoBehaviour {
    public int x, y;


    public void clearHighlights()
    {
        GameObject[] highlightedFields = GameObject.FindGameObjectsWithTag("Movement");
        foreach (GameObject obj in highlightedFields)
        {
            Destroy(obj);
        }
    }

    private void OnMouseDown()
    {
        GameObject text = GameObject.Find("Info");
        Text t2 = (Text)text.GetComponent(typeof(Text));
        GameObject pc = GameObject.FindWithTag("SelectedPlayer");
        PlayerCharacters pcc = pc.GetComponent<PlayerCharacters>();
        pcc.hasMoved = true;
        t2.text += "\n<color=#008000ff>" + pcc.getName() + "</color> moved to " + x + ", " + y;
        pcc.x = x;
        pcc.y = y;
        pc.transform.position = new Vector3(x, y, 0);
        clearHighlights();


    }
}
