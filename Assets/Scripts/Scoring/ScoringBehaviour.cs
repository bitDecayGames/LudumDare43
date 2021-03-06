﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scoring {
	public class ScoringBehaviour : MonoBehaviour {

		public Text FinishReasonText;
		
		public StarBehaviour Star1;
		public StarBehaviour Star2;
		public StarBehaviour Star3;

		public Text Score;

		public StarBehaviour Bonus;
		public Text BonusText;

		public Transform Menu;
		public Button LevelSelectButton;
		public Button RestartButton;
		public Button NextButton;

		public FadeToBlack Fader;

		public float InitialWaitTime;

		private bool started;

		private const float timeToFlyIn = 1f;
		
		private const float timeToFill = 2f;
		private const float timeToBonus = timeToFill + 1;
		private float time = timeToFill;

		private float currentFill; // from 0 to 3
		private float previousFill; // from 0 to 3
		private float targetFill; // from 0 to 3

		private int currentScore;
		private int targetScore;

		private bool bonus;

		private Action onLevelSelect;
		private Action onRestart;
		private Action onNext;

		void Start() {			
			LevelSelectButton.onClick.AddListener(OnLevelSelect);
			RestartButton.onClick.AddListener(OnRestart);
			NextButton.onClick.AddListener(OnNext);
		}

		void Update() {
			if (started) {
				if (time < timeToFill) {
					time += Time.deltaTime;
					
					currentFill = targetFill * time / timeToFill;

					Star1.SetFill(currentFill);
					Star2.SetFill(currentFill - 1);
					Star3.SetFill(currentFill - 2);

					if (previousFill < 1 && currentFill >= 1) {
						// flash first star
//						Debug.Log("Flash first star");
						FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.ScoreScreenStarOne);
						Star1.Flash();
					} else if (previousFill < 2 && currentFill >= 2) {
						// flash second star
//						Debug.Log("Flash second star");
						FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.ScoreScreenStarTwo);
						Star2.Flash();
					} else if (previousFill < 3 && currentFill >= 3) {
						// flash third star
//						Debug.Log("Flash third star");
						FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.ScoreScreenStarThree);
						Star3.Flash();
					}

					previousFill = currentFill;

					currentScore = Mathf.Clamp((int) (targetScore * time / timeToFill), 0, targetScore);
					Score.text = "$" + IntToCurrency(currentScore);
				} else if (time < timeToBonus && bonus) {
					// just increment time here
					time += Time.deltaTime;
				} else {
					started = false;
					// turn on bonus if true
					if (bonus) {
						Bonus.SetFill(1);
//						Debug.Log("Flash bonus");
						FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.ScoreScreenBonusStamp);
						if (targetFill >= 3)
						{
							FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.ScoreScreenStarStarsAndBonus);
						}
						Bonus.Flash();
					}

					Menu.gameObject.SetActive(true);
				}
				
			}
		}

		/// <summary>
		/// Popup the score board with score animations and menu options
		/// </summary>
		/// <param name="targetFill"></param>
		/// <param name="targetScore"></param>
		/// <param name="bonus"></param>
		/// <param name="onLevelSelect"></param>
		/// <param name="onRestart"></param>
		/// <param name="onNext"></param>
		public void SetScore(string finishReason, float stars, int score, bool bonus, string bonusText, Action onLevelSelect, Action onRestart, Action onNext) {
			gameObject.SetActive(true);
			
			time = -InitialWaitTime;
			targetFill = stars;
			currentFill = 0;
			previousFill = 0;

			currentScore = 0;
			targetScore = score;

			this.bonus = bonus;

			this.onLevelSelect = onLevelSelect;
			this.onRestart = onRestart;
			this.onNext = onNext;

			FinishReasonText.text = finishReason;
			BonusText.text = bonusText;

			StartCoroutine(WaitThenStart(timeToFlyIn)); 
		}

		private void OnLevelSelect()
		{
			FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.MenuSelect2);
			if (onLevelSelect != null) onLevelSelect();
		}

		private void OnRestart() {
			FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.MenuSelect2);
			if (onRestart != null) onRestart();
		}

		private void OnNext() {
			FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.MenuSelect2);
			if (onNext != null) onNext();
		}

		private IEnumerator WaitThenStart(float secondsToWait) {
			yield return new WaitForSeconds(secondsToWait);
			started = true;
		}

		public static string IntToCurrency(int value) {
			var str = ReverseString(value + "");
			var parts = SplitStringInParts(str, 3);
			var list = new List<string>();
			list.AddRange(parts);
			return ReverseString(String.Join(",", list.ToArray()));
		}

		private static string ReverseString(string s) {
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		private static IEnumerable<String> SplitStringInParts(String s, int partLength) {
			if (s == null) throw new ArgumentNullException("s");
			if (partLength <= 0) throw new ArgumentException("Part length has to be positive.", "partLength");

			for (var i = 0; i < s.Length; i += partLength) yield return s.Substring(i, Math.Min(partLength, s.Length - i));
		}
	}
}
