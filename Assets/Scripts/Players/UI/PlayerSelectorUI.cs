using UnityEngine;
using UnityEngine.UI;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerSelectorUI : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Image front;
        [SerializeField] private Image back;
        [SerializeField] private Image backfill;

        private void OnEnable()
        {
            settings.OnPlayerSpawned += SpawnPlayer;
            settings.OnSwitchCooldownUpdated += UpdateBackfillAmount;
            settings.OnSwitchCooldownFinished += PlaySwitchCooldownFinishSound;
        }

        private void OnDisable()
        {
            settings.OnPlayerSpawned -= SpawnPlayer;
            settings.OnSwitchCooldownUpdated -= UpdateBackfillAmount;
            settings.OnSwitchCooldownFinished -= PlaySwitchCooldownFinishSound;
        }

        private void SpawnPlayer()
        {
            front.sprite = settings.Current.Selector;
            SetBackSelector(settings.Last.Selector);
        }

        private void SetBackSelector(Sprite selector)
        {
            back.sprite = selector;
            backfill.sprite = selector;
        }

        private void UpdateBackfillAmount(float amount) => backfill.fillAmount = amount;

        private void PlaySwitchCooldownFinishSound() => audioSource.Play();
    }
}