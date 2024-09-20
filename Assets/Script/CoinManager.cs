using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI giftText;
    private int coin;

    public void GiftCount()
    {
        coin++;
        giftText.text = coin.ToString();
    }
}
