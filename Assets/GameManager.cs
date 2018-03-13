using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public BoardManager boardScript;
    NavMeshAgent agent;
    public Button endTurn;


    // Use this for initialization
    void Awake () {
        boardScript = GetComponent<BoardManager>();
        InitGame();
        GameObject endButtonObject = GameObject.Find("EndTurn");
        Button endButton = (Button)endButtonObject.GetComponent(typeof(Button));
        endButton.onClick.AddListener(EndTurnFunction);
        agent = GetComponent<NavMeshAgent>();

        GameObject attackButtonObject = GameObject.Find("Attack");
        Button attackButton = (Button)attackButtonObject.GetComponent(typeof(Button));
        attackButton.interactable = false;
        attackButton.onClick.AddListener(AttackFunction);
        
    }

    void EndTurnFunction()
    {
        boardScript.EndTurn();
    }

    void AttackFunction()
    {
        boardScript.Attack();
    }

    void AbilityFunction()
    {
        boardScript.Ability();
    }

    void InitGame()
    {
        boardScript.LoadMap();
    }
	
	// Update is called once per frame
	void Update () {
            //text.text = Input.mousePosition.ToString();
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //GameObject obj = hit.collider.gameObject;
            /*
            if (obj.)
            {

            }
            else { text.text = obj.ToString(); }
            */
    }
}
