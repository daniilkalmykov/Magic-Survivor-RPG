
using Agava.YandexGames;

namespace YandexSDK
{
    public sealed class InterstitialAdShower : AdShower
    {
        public override void Show()
        {
            InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
        }
    }
}