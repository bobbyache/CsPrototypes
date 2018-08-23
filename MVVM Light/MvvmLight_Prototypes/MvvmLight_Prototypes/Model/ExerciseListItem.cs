using GalaSoft.MvvmLight;

namespace MvvmLight_Prototypes.Model
{
    public class ExerciseListItem : ObservableObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged(() => Title);
                }
            }
            
        }

        private int suggestedDuration;

        public int SuggestedDuration
        {
            get { return suggestedDuration; }
            set
            {
                if (suggestedDuration != value)
                {
                    suggestedDuration = value;
                    RaisePropertyChanged(() => SuggestedDuration);
                }
            }
        }

        private int difficultyRating;

        public int DifficultyRating
        {
            get { return difficultyRating; }
            set
            {
                if (difficultyRating != value)
                {
                    difficultyRating = value;
                    RaisePropertyChanged(() => DifficultyRating);
                }
            }
        }

        private int favouriteRating;

        public int FavouriteRating
        {
            get { return favouriteRating; }
            set
            {
                if (favouriteRating != value)
                {
                    favouriteRating = value;
                    RaisePropertyChanged(() => FavouriteRating);
                }
            }
        }

        private bool scribed;

        public bool Scribed
        {
            get { return scribed; }
            set
            {
                if (scribed != value)
                {
                    scribed = value;
                    RaisePropertyChanged(() => Scribed);
                }
            }
        }


        private string notes;

        public string Notes
        {
            get { return notes; }
            set
            {
                if (notes != value)
                {
                    notes = value;
                    RaisePropertyChanged(() => Notes);
                }
            }
        }
    }
}
