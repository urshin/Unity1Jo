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
    private void Start()
    {
        StartCoroutine(CoGenerateStar());
        Destroy(gameObject, 5);      
        //CreateStars();
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

        for (int i = 0; i < starList.Length; i++)
        {
            GameObject starobj = Instantiate(starList[i], transform.position, Quaternion.identity);
            SkillTest starCompoenent = starobj.GetComponent<SkillTest>();
            starCompoenent.SetPathType(pathType);
            starCompoenent.SetDist(length);
            starCompoenent.SetFrequency(freq);
            starCompoenent.SetSpeed(speed);
            starCompoenent.transform.SetParent(gameObject.transform);

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
}
