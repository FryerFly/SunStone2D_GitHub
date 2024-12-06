using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumTest : MonoBehaviour
{
    

    public triangle thisTriangle;

    SpriteRenderer triangleSprite;
    // Start is called before the first frame update
    void Start()
    {
        triangleSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisTriangle == triangle.even){triangleSprite.color = Color.blue;}
        if(thisTriangle == triangle.rightAngle){triangleSprite.color = Color.red;}
        if(thisTriangle == triangle.nonEuclidiean){triangleSprite.color = Color.green;}

    }

    
    public bool isDragging = false;
    
    void OnMouseDrag()
    {
        //stoneSprite.color += Color.white * Time.deltaTime;
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mouseScreenPosition;
        isDragging = true;

    }
}

public enum triangle {even, rightAngle, nonEuclidiean};

/* public enum weather
{
    sunny,
    windy,
    rainy,
    stormy
}; */
