using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacters : MonoBehaviour {

    public int x, y;
    public bool hasMoved = false;
    public bool hasActed = false;
    // 0 for tank, 1 for mage, 2 for vampire
    public int charType;
    public string name = "";
    public int moveRange;
    public int health;
    public int damage;
    public int defence;
    public int attackRange;
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

        if(x - moveRange > 0)
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
        while(startx < endx+1)
        {
            while(loopy < endy+1)
            {
                int distance = System.Math.Abs(x - startx) + System.Math.Abs(y - loopy);
                if (distance <= moveRange)
                {
                    HighlightedFields ht = highlightedTile.GetComponent<HighlightedFields>();
                    ht.x = startx;
                    ht.y = loopy;
                    Instantiate(highlightedTile, new Vector3(startx, loopy, 0f), Quaternion.identity);
                }
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
        if(charType == 2)
        {
            textField.text += "\nSpecial: Heals by killing";
        } else if(charType == 1)
        {
            textField.text += "\nSpecial: Ranged attack (range 3)";
        }
    }

    private void OnMouseExit()
    {
        GameObject textObject = GameObject.Find("Stats");
        Text textField = (Text)textObject.GetComponent(typeof(Text));
        textField.text = "";
    }

    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("SelectedPlayer") != null)
        {
            GameObject previous = GameObject.FindWithTag("SelectedPlayer");
            previous.tag = "Player";
        }
        gameObject.tag = "SelectedPlayer";
        if (!hasMoved)
        {
            setHighlightedFields();
        }
        if (!hasActed)
        {
            GameObject attackButtonObject = GameObject.Find("Attack");
            Button attackButton = (Button)attackButtonObject.GetComponent(typeof(Button));
            attackButton.interactable = true;
            
        }

        if (hasActed)
        {
            GameObject attackButtonObject = GameObject.Find("Attack");
            Button attackButton = (Button)attackButtonObject.GetComponent(typeof(Button));
            attackButton.interactable = false;
        }
        
    }

    public void setCharacter(int type)
    {
        charType = type;
        if(type == 0)
        {
            name = "Grushak, the lumbering Hulk";
            moveRange = 2;
            health = 4;
            damage = 2;
            defence = 1;
            attackRange = 1;
        }
        else if(type == 1)
        {
            name = "Maleshu, the Firebringer";
            moveRange = 3;
            health = 3;
            damage = 2;
            defence = 0;
            attackRange = 3;
        }
        else if (type == 2)
        {
            name = "Alucard, Soul-Reaver";
            moveRange = 5;
            health = 3;
            damage = 2;
            defence = 0;
            attackRange = 1;
        }
    }

    public string getName()
    {
        return name;
    }
}
