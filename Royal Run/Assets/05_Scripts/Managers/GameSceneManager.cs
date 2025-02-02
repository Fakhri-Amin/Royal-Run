using UnityEngine;
using MoreMountains.Feedbacks;
using Farou.Utility;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private MMFeedbacks loadMainMenuSceneFeedbacks;
    [SerializeField] private MMFeedbacks loadCutsceneSceneFeedbacks;
    [SerializeField] private MMFeedbacks loadVisualNovelSceneFeedbacks;
    [SerializeField] private MMFeedbacks loadShopSceneFeedbacks;
    [SerializeField] private MMFeedbacks loadGatheringSceneFeedbacks;
    [SerializeField] private MMFeedbacks loadCreditSceneFeedbacks;

    public void LoadMainMenuScene()
    {
        loadMainMenuSceneFeedbacks.PlayFeedbacks();
    }

    public void LoadCutsceneScene()
    {
        loadCutsceneSceneFeedbacks.PlayFeedbacks();
    }

    public void LoadVisualNovelScene()
    {
        loadVisualNovelSceneFeedbacks.PlayFeedbacks();
    }

    public void LoadShopScene()
    {
        loadShopSceneFeedbacks.PlayFeedbacks();
    }

    public void LoadGatheringScene()
    {
        loadGatheringSceneFeedbacks.PlayFeedbacks();
    }

    public void LoadCreditScene()
    {
        loadCreditSceneFeedbacks.PlayFeedbacks();
    }
}
