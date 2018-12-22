using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Contract
{
   public class ReportRequest : ObservableObject

    {
        private DateTime _start;
        private DateTime _end;
        private ReportType _reportType;

        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _start = value;
                OnPropertyChanged("End");
            }
        }

        public ReportType ReportType
        {
            get
            {
                return _reportType;
            }
            set
            {
                _reportType = value;
                OnPropertyChanged("ReportType");
            }
        }

    }

    public enum ReportType
    {
        ActiveTrainersReport


    }
}
