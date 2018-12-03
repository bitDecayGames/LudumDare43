using System;
using System.Collections.Generic;
using UnityEngine;

namespace UserStats {
    public static class ScoreStats {

        private static List<LevelScore> _levelScores;
        public static List<LevelScore> GetLevelScores() {
            if (_levelScores == null) {
                var levelScoreStrs = PlayerPrefs.GetString("level_scores", "").Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                _levelScores = new List<LevelScore>();
                foreach (var lvlScoreStr in levelScoreStrs) {
                    _levelScores.Add(new LevelScore(lvlScoreStr));
                }
            }

            return _levelScores;
        }

        public static void AddLevelScore(string name, int stars, int score, bool bonus) {
            var lvlScores = GetLevelScores();
            var s = new LevelScore(name, stars, score, bonus);
            var existing = lvlScores.Find(lvl => lvl.name == name);
            if (existing != null) {
                if (existing.stars < s.stars) existing.stars = s.stars;
                if (existing.score < s.score) existing.score = s.score;
                if (!existing.bonus && s.bonus) existing.bonus = s.bonus;
            } else lvlScores.Add(s);
            PlayerPrefs.SetString("level_scores", string.Join(",", lvlScores.ConvertAll(l => l.ToString()).ToArray()));
        }

        public static int GetTotalScore() {
            return PlayerPrefs.GetInt("total_score", 0);
        }

        public static int GetTotalStars() {
            return PlayerPrefs.GetInt("total_stars", 0);
        }

        public static int GetTotalBonuses() {
            return PlayerPrefs.GetInt("total_bonuses", 0);
        }

        private static void TallyTotalScoreAndSave() {
            var lvlScores = GetLevelScores();
            var scoreTally = 0;
            var starTally = 0;
            var bonusTally = 0;
            lvlScores.ForEach(lvl => {
                scoreTally += lvl.score;
                starTally += lvl.stars;
                bonusTally += lvl.bonus ? 1 : 0;
            });
            PlayerPrefs.SetInt("total_score", scoreTally);
            PlayerPrefs.SetInt("total_stars", starTally);
            PlayerPrefs.SetInt("total_bonuses", bonusTally);
        }

        public class LevelScore {
            public string name;
            public int stars;
            public int score;
            public bool bonus;

            public LevelScore(string name, int stars, int score, bool bonus) {
                this.name = name;
                this.stars = stars;
                this.score = score;
                this.bonus = bonus;
            }

            public LevelScore(string serialized) {
                var split = serialized.Split('|');
                try {
                    name = split[0];
                } catch (Exception e) {
                    Debug.LogError("Error when parsing level score name: " + e);
                }
                try {
                    stars = Int32.Parse(split[1]);
                } catch (Exception e) {
                    Debug.LogError("Error when parsing level score stars: " + e);
                }
                try {
                    score = Int32.Parse(split[2]);
                } catch (Exception e) {
                    Debug.LogError("Error when parsing level score score: " + e);
                }
                try {
                    bonus = Boolean.Parse(split[3]);
                } catch (Exception e) {
                    Debug.LogError("Error when parsing level score bonus: " + e);
                }
            }

            public override string ToString() {
                return name + "|" + stars + "|" + score + "|" + bonus;
            }
        }
        
    }
}