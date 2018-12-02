using Boo.Lang.Runtime;

namespace Level {
    public class LevelRating {
        public int oneStar;
        public int twoStar;
        public int threeStar;

        public LevelRating(int oneStar, int twoStar, int threeStar) {
            this.oneStar = oneStar;
            this.twoStar = twoStar;
            this.threeStar = threeStar;
            if (threeStar <= twoStar) throw new RuntimeException("Three star cannot be less than two star");
            if (twoStar <= oneStar) throw new RuntimeException("Two star cannot be less than one star");
            if (oneStar <= 0) throw new RuntimeException("One star cannot be less than 0");
        }

        public float StarRating(int score) {
            if (score <= 0) return 0;
            if (score > threeStar) return 3;
            if (score > twoStar) return 2 + (score - twoStar) / (float)(threeStar - twoStar);
            if (score > oneStar) return 1 + (score - oneStar) / (float)(twoStar - oneStar);
            return score / (float)oneStar;
        }
    }
}