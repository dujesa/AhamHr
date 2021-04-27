using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Models.ViewModels.Subject;
using AhamHr.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AhamHrContext _dbContext;

        public SubjectRepository(AhamHrContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool AddSubject(Subject subjectToAdd)
        {
            var doesSubjectExist = _dbContext.Subjects.Any(subject =>
                string.Equals(subject.Name, subjectToAdd.Name, StringComparison.CurrentCultureIgnoreCase));

            if (subjectToAdd.Name.Length < 3 || doesSubjectExist)
                return false;

            _dbContext.Subjects.Add(subjectToAdd);
            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteSubject(int idOfSubjectToDelete)
        {
            var subjectToDelete = _dbContext.Subjects.Find(idOfSubjectToDelete);

            if (subjectToDelete == null)
                return false;

            _dbContext.Remove(subjectToDelete);
            _dbContext.SaveChanges();

            return true;
        }

        public bool EditSubject(Subject edittedSubject)
        {
            var doesEdittedSubjectExist = _dbContext.Subjects.Any(subject =>
                string.Equals(subject.Name, edittedSubject.Name, StringComparison.CurrentCultureIgnoreCase));

            if (edittedSubject.Name.Length < 3 || doesEdittedSubjectExist)
                return false;

            var subjectToEdit = _dbContext.Subjects.Find(edittedSubject.Id);

            if (subjectToEdit == null)
                return false;

            subjectToEdit.Name = edittedSubject.Name;

            _dbContext.SaveChanges();

            return true;
        }

        public ICollection<SubjectModel> GetAllSubjects()
        {
            return _dbContext.Subjects
                .AsNoTracking()
                .Select(s => new SubjectModel
                {
                    Name = s.Name,
                })
                .ToList();
        }

        public Subject GetSubjectById(int id)
        {
            var subjectWithSearchingId = _dbContext.Subjects.Find(id);

            return subjectWithSearchingId;
        }
    }
}
