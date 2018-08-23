using GalaSoft.MvvmLight;

namespace MvvmLight_Prototypes.Model
{
    public class ExerciseListItem : ObservableObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { Set(() => Title, ref title, value); }            
        }

        private int suggestedDuration;
        public int SuggestedDuration
        {
            get { return suggestedDuration; }
            set { Set(() => SuggestedDuration, ref suggestedDuration, value); }
        }

        private int difficultyRating;
        public int DifficultyRating
        {
            get { return difficultyRating; }
            set { Set(() => DifficultyRating, ref difficultyRating, value); }
        }

        private int favouriteRating;
        public int FavouriteRating
        {
            get { return favouriteRating; }
            set { Set(() => FavouriteRating, ref favouriteRating, value); }
        }

        private bool scribed;
        public bool Scribed
        {
            get { return scribed; }
            set { Set(() => Scribed, ref scribed, value); }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set { Set(() => Notes, ref notes, value); }
        }
    }
}
