using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singlton
    public static UIManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }
    #endregion



    [SerializeField] private Slider slider;
    [SerializeField] private Text bonusText;
    [SerializeField] private Text winBonusText;

    public void ChangeSliderValue(float value)
    {
        slider.value = value;
    }

    public void ChangeBonusValue(float value)
    {
        bonusText.text = value.ToString();
    }

    public void ChangeWinBonusValue(float value, int count)
    {
        winBonusText.text = value.ToString() + "\n" + count.ToString();
    }
}
