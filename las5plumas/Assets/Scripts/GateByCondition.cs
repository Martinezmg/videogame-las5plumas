using System.Collections;
using UnityEngine;

public class GateByCondition : MonoBehaviour
{
    public float yAxis;
    [Range(0,1)]
    public float speed;
    public float delay = 0;

    public int openCode = 0;
    public int secretCode = 0;
    public int multiplier = 1;

    public GroundBotton[] conditions;

    private void Start()
    {
        multiplier = (int)Mathf.Pow(10, conditions.Length);
    }

    public void TryToOpen(int code)
    {
        multiplier /= 10;
        openCode += code * multiplier;

        if (multiplier == 1)
        {
            if (openCode == secretCode)
            {
                Open();
            }
            else
            {
                openCode = 0;
                multiplier = (int)Mathf.Pow(10, conditions.Length);

                foreach (var button in conditions)
                {
                    button.ResetButton();
                }
            }
        }

        /*if (conditions != null)
        {
            foreach (Conditioner condition in conditions)
            {
                if (!condition.condition)
                    return;


            }

            Open();
        }*/
    }

    private void Open()
    {
        StartCoroutine(OpenGate());
    }

    private IEnumerator OpenGate()
    {
        yield return new WaitForSeconds(delay);

        float sign = transform.position.y - yAxis;

        if (sign > 0)
        {
            while (transform.position.y > yAxis)
            {
                transform.position -= Vector3.up * Time.deltaTime * speed;

                yield return null;
            }
        }
        else
        {
            while (transform.position.y < yAxis)
            {
                transform.position += Vector3.up * Time.deltaTime * speed;

                yield return null;
            }
        }

        
    }

}
