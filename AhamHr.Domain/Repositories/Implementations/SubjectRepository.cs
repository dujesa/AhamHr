using AhamHr.Data.Entities;
using AhamHr.Data.Entities.Models;
using AhamHr.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhamHr.Domain.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        public SubjectRepository(AhamHrContext context)
        {
            _context = context;
        }

        private readonly AhamHrContext _context;

        public bool AddSubject(Subject subjectToAdd)
        {
            var doesSubjectExist = _context.Subjects.Any(subject => 
                string.Equals(subject.Name, subjectToAdd.Name, StringComparison.CurrentCultureIgnoreCase));

            if (subjectToAdd.Name.Length < 3 || doesSubjectExist)
                return false;

            _context.Subjects.Add(subjectToAdd);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteSubject(int idOfSubjectToDelete)
        {
            var subjectToDelete = _context.Subjects.Find(idOfSubjectToDelete);

            if (subjectToDelete == null)
                return false;

            _context.Remove(subjectToDelete);
            _context.SaveChanges();

            return true;
        }

        public bool EditSubject(Subject edittedSubject)
        {
            var doesEdittedSubjectExist = _context.Subjects.Any(subject =>
                string.Equals(subject.Name, edittedSubject.Name, StringComparison.CurrentCultureIgnoreCase));

            if (edittedSubject.Name.Length < 3 || doesEdittedSubjectExist)
                return false;

            var subjectToEdit = _context.Subjects.Find(edittedSubject.Id);

            if (subjectToEdit == null)
                return false;

            subjectToEdit.Name = edittedSubject.Name;

            _context.SaveChanges();

            return true;
        }

        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetSubjectById(int id)
        {
            var subjectWithSearchingId = _context.Subjects.Find(id);

            return subjectWithSearchingId;
        }
    }
}
