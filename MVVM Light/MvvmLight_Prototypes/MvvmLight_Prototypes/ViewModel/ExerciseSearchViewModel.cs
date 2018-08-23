using GalaSoft.MvvmLight;
using MvvmLight_Prototypes.Model;
using System.Collections.ObjectModel;

namespace MvvmLight_Prototypes.ViewModel
{
    public class ExerciseSearchViewModel : ViewModelBase
    {
        public ObservableCollection<ExerciseListItem> ExerciseList { get; } = new ObservableCollection<ExerciseListItem>()
        {
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 2: Building Melodies - 2d",
                DifficultyRating = 3, FavouriteRating = 4, Scribed = false, SuggestedDuration = 120 },
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 3: Slides - 3d",
                DifficultyRating = 3, FavouriteRating = 4, Scribed = false, SuggestedDuration = 120  },
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 4: Core Bending Licks - Bends around the E String - 4t",
                DifficultyRating = 3, FavouriteRating = 4, Scribed = false, SuggestedDuration = 120  },
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 5: Legato - One Fret Pull Off - 5i",
                DifficultyRating = 3, FavouriteRating = 4, Scribed = false, SuggestedDuration = 120  }
        };
    }
}
