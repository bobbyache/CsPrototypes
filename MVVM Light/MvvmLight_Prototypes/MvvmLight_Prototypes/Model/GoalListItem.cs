using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight_Prototypes.Model
{
    public class GoalListItem : ObservableObject
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
                    RaisePropertyChanged("Title");
                }

            }
        }

        private int progress;
        public int Progress
        {
            get { return progress; }
            set
            {
                if (progress != value)
                {
                    progress = value;
                    RaisePropertyChanged("Progress");
                }

            }
        }

        private int days;
        public int Days
        {
            get { return days; }
            set
            {
                if (days != value)
                {
                    days = value;
                    RaisePropertyChanged("Days");
                }

            }
        }

        private bool onSchedule;
        public bool OnSchedule
        {
            get { return onSchedule; }
            set
            {
                if (onSchedule != value)
                {
                    onSchedule = value;
                    RaisePropertyChanged("OnSchedule");
                }
                
            }
        }

        public override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            base.RaisePropertyChanged(propertyExpression);
        }

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}
