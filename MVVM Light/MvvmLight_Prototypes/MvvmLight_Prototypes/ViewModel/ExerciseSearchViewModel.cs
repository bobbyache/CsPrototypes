using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLight_Prototypes.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MvvmLight_Prototypes.ViewModel
{
    public class ExerciseSearchViewModel : ViewModelBase
    {

        //public ExerciseSearchViewModel(IExerciseService exerciseService, IDialogService dialogService, INavigationService navigationService)
        //{
        //    this.exerciseService = exerciseService;
        //    this.dialogService = dialogService;
        //    this.navigationService = navigationService;
        //}

        // for blend:
        //public ExerciseSearchViewModel() : this(new ExerciseService(), new DialogService(), new NavigationService())
        //{
        //    ...
        //}

        public ExerciseSearchViewModel()
        {
            AddExerciseCommand = new RelayCommand(AddExercise, (() => true));
        }

        private void AddExercise()
        {
            ExerciseList.Add(new ExerciseListItem
            {
                Title = $"Added Exercise Item - {DateTime.Now}",
                DifficultyRating = 3,
                PracticalityRating = 4,
                Scribed = false,
                SuggestedDuration = 120,
                Notes = $"Here is a sample note - {DateTime.Now}"
            });
        }

        public RelayCommand AddExerciseCommand
        {
            get; private set;
        }

        private ExerciseListItem selectedExercise;
        public ExerciseListItem SelectedExercise
        {
            get { return selectedExercise; }
            set
            {
                Set(() => SelectedExercise, ref selectedExercise, value);
            }
        }

        public ObservableCollection<ExerciseListItem> ExerciseList { get; } = new ObservableCollection<ExerciseListItem>()
        {
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 2: Building Melodies - 2d",
                DifficultyRating = 3, PracticalityRating = 4, Scribed = false, SuggestedDuration = 120, Notes="Here is a sample note" },
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 3: Slides - 3d",
                DifficultyRating = 3, PracticalityRating = 2, Scribed = false, SuggestedDuration = 120, Notes="Get those fingers working, start from 60 to 80 BPM."  },
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 4: Core Bending Licks - Bends around the E String - 4t",
                DifficultyRating = 3, PracticalityRating = 1, Scribed = false, SuggestedDuration = 120, Notes = "Start at 80 BPM, you really want to get to 120 BPM."  },
            new ExerciseListItem { Title = "Guitar Solo School: Beginner Lead Guitar Method - Chapter 5: Legato - One Fret Pull Off - 5i",
                DifficultyRating = 3, PracticalityRating = 4, Scribed = false, SuggestedDuration = 120  }
        };
    }
}
