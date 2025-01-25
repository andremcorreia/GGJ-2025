using UnityEngine;

public class HideOnDeath : MonoBehaviour
{
    public GameObject menu;
    public void HideOnDeathFunction()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
