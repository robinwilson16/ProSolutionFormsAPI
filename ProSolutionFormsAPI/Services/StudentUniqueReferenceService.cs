using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProSolutionFormsAPI.Services
{
    public class StudentUniqueReferenceService
    {
        private readonly ApplicationDbContext _context;


        public List<StudentUniqueReference>? StudentUniqueReferences { get; }

        public StudentUniqueReferenceService(ApplicationDbContext context)
        {
            _context = context;

            StudentUniqueReferences = _context.StudentUniqueReference!
                .ToList();
        }

        public List<StudentUniqueReference>? GetAll() => StudentUniqueReferences;

        public StudentUniqueReference? Get(string studentRef) => StudentUniqueReferences?.FirstOrDefault(s => s.StudentRef == studentRef);

        public StudentUniqueReference? GetByID(Guid studentUniqueReferenceID) => StudentUniqueReferences?.FirstOrDefault(s => s.StudentUniqueReferenceID == studentUniqueReferenceID);

        public async Task Add(StudentUniqueReference studentUniqueReference)
        {
            _context.StudentUniqueReference?.Add(studentUniqueReference);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StudentUniqueReference? studentUniqueReference)
        {
            StudentUniqueReference? studentUniqueReferenceDB = _context.StudentUniqueReference!
                .FirstOrDefault(s => s.StudentUniqueReferenceID == studentUniqueReference!.StudentUniqueReferenceID);

            if (_context.StudentUniqueReference == null)
            {
                return;
            }

            _context.Entry(studentUniqueReferenceDB!).CurrentValues.SetValues(studentUniqueReference!);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string studentRef)
        {
            var studentUniqueReference = Get(studentRef);
            if (studentUniqueReference is null)
                return;

            _context.StudentUniqueReference!.Remove(studentUniqueReference);
            await _context.SaveChangesAsync();
        }
    }
}
