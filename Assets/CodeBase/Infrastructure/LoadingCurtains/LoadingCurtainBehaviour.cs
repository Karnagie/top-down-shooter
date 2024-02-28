using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Infrastructure.LoadingCurtains
{
    public class LoadingCurtainBehaviour : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvas;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public async UniTask Show(float duration)
        {
            gameObject.SetActive(true);
            await _canvas.DOFade(1, duration).AsyncWaitForCompletion();
        }

        public async UniTask Hide(float duration)
        {
            await _canvas.DOFade(0, duration).AsyncWaitForCompletion();
            gameObject.SetActive(false);
        }
    }
}