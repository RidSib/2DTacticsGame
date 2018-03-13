using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackFields : MonoBehaviour {

    public NonPlayerCharacters enemy;
    public PlayerCharacters player;
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
        Text info = (Text)text.GetComponent(typeof(Text));
        float roll = Random.Range(0.0f, 100.0f);
        if(roll >= 20)
        {
            int damage = (player.damage - enemy.defence);
            enemy.health -= damage;
            if (enemy.health > 0) {
                info.text += "\n<color=#008000ff>" + player.name + "</color> attacked <color=#F62D2DFF>" + enemy.name + "</color> and did <b>" + damage + "</b>";
            } else {
                info.text += "\nIn a viscious attack<color=#008000ff>" + player.name + "</color> kills <color=#F62D2DFF>" + enemy.name + "</color>. You hear an agonized scream: \"My servive was ending tommorooow...\" " + player.name + " has a post-carnage cigarrete!";

                enemy.tag = "Untagged";
                Destroy(enemy.gameObject);
                if (player.charType == 2)
                {
                    info.text += "\nThe Vampire does unspiccable things to his enemy. I mean really nasty. He gains +1 Health!";
                    player.health += 1;
                }

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemies.Length == 0)
                {
                    info.text += "\n With all servants of the light dead, dying or worse there is nothing stopping you from claiming the church. You defile it the worst ways imaginable, your soverigns are proud. You win! You loyal! You awesome!";
                }
            }
        }
        else
        {
            info.text += "\nWow you missed!";
        }
        player.hasActed = true;
        GameObject attackButtonObject = GameObject.Find("Attack");
        Button attackButton = (Button)attackButtonObject.GetComponent(typeof(Button));
        attackButton.interactable = false;
        clearHighlights();
    }
}
