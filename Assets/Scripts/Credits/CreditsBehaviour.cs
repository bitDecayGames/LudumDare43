using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace Credits {
    public class CreditsBehaviour : MonoBehaviour {
        public Text CreditTitlePrefab;
        public Text NameCreditPrefab;
        public Transform Content;
        public FadeToBlack Fader;
        
        public List<CreditsSection> Credits = new List<CreditsSection> {
            CreditsSection.GetNew().SetTItle("Programming").SetCreditList(CreditList.GetNew().Add("Jake Fisher", "Logan Moore", "Tanner Moore", "Mike Wingfield")),
            CreditsSection.GetNew().SetTItle("Art").SetCreditList(CreditList.GetNew().Add("Erik Meredith")),
            CreditsSection.GetNew().SetTItle("Music Composition").SetCreditList(CreditList.GetNew().Add("Tanner Moore")),
            CreditsSection.GetNew().SetTItle("SFX").SetCreditList(CreditList.GetNew().Add("Tanner Moore")),
            CreditsSection.GetNew().SetTItle("Level Design").SetCreditList(CreditList.GetNew().Add("Logan Moore", "Erik Meredith", "Jake Fisher")),
            CreditsSection.GetNew().SetTItle("Special Thanks").SetCreditList(CreditList.GetNew().Add("You!", "If you are reading", "this, this is it.", "No cutscenes...", "Sorry...", "", "...Ramshackle"))
        };

        void Start() {
            Credits.ForEach(cs => {
                var title = Instantiate(CreditTitlePrefab, Content);
                title.text = cs.title;
                cs.list.names.ForEach(n => {
                    var nameCredit = Instantiate(NameCreditPrefab, Content);
                    nameCredit.text = n;
                });
            });
        }

        public void ScrolledToBottom() {
            StartCoroutine(WaitThenGo());
        }

        private IEnumerator WaitThenGo() {
            yield return new WaitForSeconds(3);
            Fader.Fade(3, () => {
                SceneManager.LoadScene("WorldMap");
            });
        }
    }

    public class CreditsSection {
        public string title;
        public CreditList list; 
        
        public CreditsSection SetTItle(string title) {
            this.title = title;
            return this;
        }

        public CreditsSection SetCreditList(CreditList list) {
            this.list = list;
            return this;
        }

        public static CreditsSection GetNew() {
            return new CreditsSection();
        }
    }

    public class CreditList {
        public List<string> names;

        public CreditList() {
            names = new List<string>();
        }

        public CreditList Add(params string[] names) {
            this.names.AddRange(names);
            return this;
        }

        public static CreditList GetNew() {
            return new CreditList();
        }
    }
}