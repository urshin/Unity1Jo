using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStar : MonoBehaviour
{
    [SerializeField] GameObject[] starList;
    [SerializeField] float maxLength;
    [SerializeField] float maxFrequency;
    [SerializeField] float maxSpeed;
    [SerializeField] float parentPosX;
    public PathType pathType = PathType.Sin;
    float maxHeight;
    private void Start()
    {
        StartCoroutine(DestryGeneratorObj(2.5f));  
        StartCoroutine(CoGenerateStar()); 
        //Destroy(gameObject, 2.5f);

    }
    IEnumerator DestryGeneratorObj(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
        GameObject.FindWithTag("Player")?.GetComponent<MoonLight>().SetActiveRotateStars(true);  
    }
    IEnumerator CoGenerateStar()
    {

        WaitForSeconds seconds = new WaitForSeconds(0.001f);  
        float length = maxLength;
        float perLenth = maxLength / starList.Length;
        float freq = maxFrequency;
        float perFreq = maxFrequency / starList.Length;

        float speed = maxSpeed;
        float perSpeed = maxSpeed / (starList.Length);
        float alpha = 1;
        float size = 1;  

        for (int i = 0; i < starList.Length; i++)
        {
            GameObject starobj = Instantiate(starList[i], transform.position, Quaternion.identity);
            SkillTest starCompoenent = starobj.GetComponent<SkillTest>();
            starCompoenent.SetPathType(pathType);
            starCompoenent.SetDist(length);
            starCompoenent.SetFrequency(freq);
            starCompoenent.SetSpeed(speed);
            starCompoenent.SetHeight(maxHeight);  
            starCompoenent.transform.SetParent(gameObject.transform);
            starCompoenent.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            if (i == 0)
            {
                starCompoenent.transform.localScale = new Vector3(1.5f, 1.5f, 1);        

            }
            else
            {
                starCompoenent.transform.localScale = new Vector3(size, size, 1);

            }
            alpha -= 0.02f;      
            size -= 0.015f;      

            length -= perLenth;
            freq -= perFreq / starList.Length;
            speed -= perSpeed / (starList.Length * 2);

            yield return seconds;
        }
    }


    void CreateStars()
    {
        float length = maxLength;
        float perLenth = maxLength / starList.Length;
        float freq = maxFrequency;
        float perFreq = maxFrequency / starList.Length;

        float speed = maxSpeed;
        float perSpeed = maxSpeed / (starList.Length);

        for (int i = 0; i < starList.Length; i++)
        {
            GameObject starobj = Instantiate(starList[i], transform.position, Quaternion.identity);
            SkillTest starCompoenent = starobj.GetComponent<SkillTest>();
            starCompoenent.SetParentPosX(parentPosX);
            starCompoenent.SetDist(length);
            starCompoenent.SetFrequency(freq);
            starCompoenent.SetSpeed(speed);
            starCompoenent.transform.SetParent(gameObject.transform);

            length -= perLenth;
            freq -= perFreq / starList.Length;
            speed -= perSpeed / (starList.Length * 2);


        }
    }  

    public void SetParentPosX(float x)
    {
        parentPosX = x;
    }

    public void SetHeight(float h)
    {
        maxHeight = h;
    }
    public void MaxFrequency(float f)
    {
        maxFrequency = f;
    }
}
