using ExamProvider.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface IExamRepositary
    {
        Task<List<Exam>> get_ALLExams();
        Task<Exam> getExamById(int id);
        Task create_Exam(Exam exam);
        Task update_Exam(Exam exam);
        Task delete_Exam(int id);
        Task<List<Exam> >search_between_interval(DateTime firstDate,DateTime secondDate);
        Task<List<Exam>> search_specifec_Date(DateTime specificDate);
       

    }
}
