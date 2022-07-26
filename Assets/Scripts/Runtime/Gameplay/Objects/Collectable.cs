using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Egg,
    Apple,
    Rat
}

public class Collectable : MonoBehaviour
{
    #region Fields

    private ConsumableType type = ConsumableType.Apple; 
    [SerializeField] ConsumableInfo info;

    #endregion

    #region Methods

    public void ResetBehaviour()
    {
        int random = Random.Range(0, System.Enum.GetNames(typeof(ConsumableType)).Length);
        type = (ConsumableType) random; 
    }

    #endregion

    #region Build-in Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        HeadBehaviour hb = other.GetComponent<HeadBehaviour>();
        if(hb != null)
        {
            Debug.Log("x");
            other.GetComponentInParent<SnakeController>().ExtendBody(info);

            // in here, we disable object.
            gameObject.SetActive(false);
        }
    }

    #endregion
}
