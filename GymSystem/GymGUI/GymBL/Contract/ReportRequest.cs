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
        private DateTime m_start;
        private DateTime m_end;
        private ReportType m_reportType;

        public DateTime Start
        {
            get
            {
                return m_start;
            }
            set
            {
                m_start = value;
                OnPropertyChanged("Start");
            }
        }

        public DateTime End
        {
            get
            {
                return m_end;
            }
            set
            {
                m_end = value;
                OnPropertyChanged("End");
            }
        }

        public ReportType ReportType
        {
            get
            {
                return m_reportType;
            }
            set
            {
                m_reportType = value;
                OnPropertyChanged("ReportType");
            }
        }

    }

    public enum ReportType
    {
        ActiveTrainersReport


    }
}
