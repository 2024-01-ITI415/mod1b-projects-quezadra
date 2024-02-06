using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;    //	a
    void Start()
    {
        //	Find	a	reference	to	the	ScoreCounter	GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");   //	b
                                                                //	Get	the	Text	Component	of	that	GameObject
        scoreGT = scoreGO.GetComponent<Text>(); //	c
                                                //	Set	the	starting	number	of	points	to	0
        scoreGT.text = "0";
    }

    void Update()
    {
        
        Vector3 mousePos2D = Input.mousePosition;  
        mousePos2D.z = -Camera.main.transform.position.z;   //	b
                                                            //	Convert	the	point	from	2D	screen	space	into	3D	game	world	space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);    //	c
                                                                            //	Move	the	x	position	of	this	Basket	to	the	x	position	of	the	Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {   //	a
        //	Find	out	what	hit	this	basket
        GameObject collidedWith = coll.gameObject;  //	b
        if (collidedWith.tag == "Apple")
        {   //	c
            Destroy(collidedWith);

            //	Parse	the	text	of	the	scoreGT	into	an	int
            int score = int.Parse(scoreGT.text);    //	d
                                                    //	Add	points	for	catching	the	apple
            score += 100;
            //	Convert	the	score	back	to	a	string	and	display	it
            scoreGT.text = score.ToString();

            //	Track	the	high	score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}