using Agava.YandexGames;

namespace YandexSDK
{
    public sealed class VideoAdShower : AdShower
    {
        public override void Show()
        {
            VideoAd.Show(OnOpenCallBack, onCloseCallback: OnCloseCallBack);
        }
    }
}