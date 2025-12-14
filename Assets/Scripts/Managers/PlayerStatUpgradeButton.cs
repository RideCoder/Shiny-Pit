using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerStatUpgradeButton : MonoBehaviour
{
    public TMP_Text text;
    public PlayerStats stats;

    [Header("Config")]
    [SerializeField] private float minMultiplier = 1.05f;
    [SerializeField] private float maxMultiplier = 1.25f;

    [SerializeField]
    private StatType[] excludedStats =
    {
        StatType.Xp,
        StatType.XpRequired
    };

    private StatType chosenStat;
    private float amountChosen;

    public event Action OnClicked;

    private void Start()
    {
        ChooseRandomStat();
        UpdateText();
    }

    private void ChooseRandomStat()
    {
        var validStats = Enum.GetValues(typeof(StatType))
                             .Cast<StatType>()
                             .Except(excludedStats)
                             .ToArray();

        chosenStat = validStats[UnityEngine.Random.Range(0, validStats.Length)];
        amountChosen = UnityEngine.Random.Range(minMultiplier, maxMultiplier);
    }

    private void UpdateText()
    {
        float percent = (amountChosen - 1f) * 100f;
        text.text = $"+{percent:0}% {chosenStat}";
    }

    public void SelectedButton()
    {
        stats.ModifyStatMultiplicative(chosenStat, amountChosen);
        OnClicked?.Invoke();

        Destroy(gameObject);
    }
}
