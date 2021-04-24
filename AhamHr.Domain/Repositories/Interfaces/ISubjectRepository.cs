using AhamHr.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        List<Subject> GetAllSubjects();
        bool AddSubject(Subject subjectToAdd);
        bool EditSubject(Subject edittedSubject);
        bool DeleteSubject(int idOfSubjectToDelete);
        Subject GetSubjectById(int id);
    }
}
