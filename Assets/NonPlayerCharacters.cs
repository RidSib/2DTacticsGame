using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonPlayerCharacters : MonoBehaviour {

    public int x, y;
    public bool hasMoved = false;
    public int charType = 0;
    public string name = "Knight of the fifth dawns";
    public int moveRange;
    public int health;
    public int damage;
    public int defence;
    public GameObject highlightedTile;

    void clearHighlights()
    {
        GameObject[] highlightedFields = GameObject.FindGameObjectsWithTag("Movement");
        foreach (GameObject obj in highlightedFields)
        {
            Destroy(obj);
        }
    }

    void setHighlightedFields()
    {
        clearHighlights();
        int startx, endx;
        int starty, endy;

        if (x - moveRange > 0)
        {
            startx = x - moveRange;
        }
        else
        {
            startx = 0;
        }

        if (x + moveRange < 29)
        {
            endx = x + moveRange;
        }
        else
        {
            endx = 29;
        }

        if (y - moveRange > 0)
        {
            starty = y - moveRange;
        }
        else
        {
            starty = 0;
        }

        if (y + moveRange < 19)
        {
            endy = y + moveRange;
        }
        else
        {
            endy = 19;
        }

        int loopy = starty;
        while (startx < endx + 1)
        {
            while (loopy < endy + 1)
            {
                
                    HighlightedFields ht = highlightedTile.GetComponent<HighlightedFields>();
                    ht.x = startx;
                    ht.y = loopy;
                    Instantiate(highlightedTile, new Vector3(startx, loopy, 0f), Quaternion.identity);
                loopy++;
            }
            loopy = starty;
            startx++;
        }

    }

    private void OnMouseOver()
    {
        GameObject textObject = GameObject.Find("Stats");
        Text textField = (Text)textObject.GetComponent(typeof(Text));
        textField.text = name + "\nHealth: " + health + "\nDamage: " + damage + "\nMove-Range: " + moveRange + "\nDefence: " + defence;
        if (charType == 0)
        {
            textField.text += "\nSpecial: Form a shield wall. Fight as brothers. Multiple of this units can occupy the same field. If you attack such a field, you will hit a random unit.";
        }
    }

    private void OnMouseExit()
    {
        GameObject textObject = GameObject.Find("Stats");
        Text textField = (Text)textObject.GetComponent(typeof(Text));
        textField.text = "";
    }

    public void setCharacter(int type)
    {
        charType = type;
        if (type == 0)
        {
            name = "Knight of the fifth dawn";
            moveRange = 3;
            health = 3;
            damage = 2;
            defence = 1;
        }
        else if (type == 1)
        {
            name = "Priest";
            moveRange = 3;
        }
        else if (type == 2)
        {
            name = "Foot-Soldier";
            moveRange = 5;
        }
    }

    public string getName()
    {
        return name;
    }
}
